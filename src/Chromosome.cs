using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace aiGenetic
{
    class Chromosome : IComparable
    {
        private double nonFitness;
        private int[] path;
        private TSP problem;
        private Rand rand;

        public double NonFitness
        {
            get { return nonFitness; }
        }

        public int[] Path
        {
            get { return path; }
        }

        public TSP Problem
        {
            get { return problem; }
        }

        /// <summary>
        /// Конструктор генерации случайного Genome.
        /// </summary>
        /// <param name="tsp">Задача коммивояжера.</param>
        public Chromosome(TSP tsp)
        {
            this.problem = tsp;
            this.path = new int[tsp.cities.Count];

            this.rand = new Rand();
            for (int i = 0; i != tsp.cities.Count; ++i)
                path[i] = -1;

            problem.ResetMap();
            int city = 0;
            for (int i = 0; i != tsp.cities.Count; ++i)
            {
                do
                    city = rand.Next(tsp.cities.Count);
                while (problem.map[city] != 0);
                problem.map[city] = 1;
                path[i] = city;
            }
        }

        /// <summary>
        /// Конструктор кроссовера Genome.
        /// </summary>
        /// <param name="p1">Родитель 1.</param>
        /// <param name="p2">Родитель 2.</param>
        /// <param name="c">Способ скрещивания.</param>
        public Chromosome(Chromosome p1, Chromosome p2, Crossover c)
        {
            this.problem = p1.problem;
            this.rand = new Rand();
            List<int> cache = new List<int>();
            this.path = new int[problem.cities.Count];
            int i1, i2;

            if (c == Crossover.Greedy)      // Greedy Crossover
            {
                if (flip())
                    path[0] = p1.path[0];
                else
                    path[0] = p2.path[0];

                problem.ResetMap();
                problem.map[path[0]] = int.MaxValue;

                for (int i = 0; i != problem.cities.Count - 1; )
                {
                    int v = path[i++];

                    for (i1 = 0; i1 != p1.path.Length; ++i1)
                        if (v == p1.path[i1])
                            break;

                    for (i2 = 0; i2 != p2.path.Length; ++i2)
                        if (v == p2.path[i2])
                            break;

                    int v1 = (i1 == p1.path.Length - 1 ? p1.path[0] : p1.path[++i1]);
                    int v2 = (i2 == p2.path.Length - 1 ? p2.path[0] : p2.path[++i2]);

                    if (problem.map[v1] != 0)
                        v1 = int.MaxValue;

                    if (problem.map[v2] != 0)
                        v2 = int.MaxValue;

                    // Обработка занятости
                    if (v1 != int.MaxValue && v2 != int.MaxValue)
                    {
                        if (v1 == v2)
                            path[i] = v1;
                        else                // Сравнение претендентов
                        {
                            double c1 = problem.Distance(v, v1);
                            double c2 = problem.Distance(v, v2);
                            if (c1 == 0 || c2 == 0)
                                c1 = 0;
                            if (c1 < c2)
                            {
                                path[i] = v1;
                                cache.Add(v2);
                            }
                            else
                            {
                                path[i] = v2;
                                cache.Add(v1);
                            }
                        }
                    }
                    else if (v1 == int.MaxValue && v2 != int.MaxValue)
                        path[i] = v2;
                    else if (v1 != int.MaxValue && v2 == int.MaxValue)
                        path[i] = v1;
                    else
                    {
                        // Вставка города из кэша
                        for (int k = cache.Count - 1; k != -1; --k)
                            if (problem.map[cache[k]] == 0)
                            {
                                path[i] = cache[k];
                                break;
                            }
                    }
                    problem.map[path[i]] = int.MaxValue;
                }
            }
            else if (c == Crossover.Cycle)
            {
                if (flip())
                {
                    Chromosome s = p1;
                    p1 = p2;
                    p2 = s;
                }

                problem.ResetMap();
                int r1 = 0,
                    city,
                    N = problem.cities.Count,
                    d1 = 0, d2 = N - 1;

                for (int r2 = d2; r1 < (int)(0.5f * N); ++r1, --r2)
                {
                    do
                    {
                        city = p1.path[d1];
                        ++d1;
                    } while (problem.map[city] != 0);

                    path[r1] = city;
                    problem.map[city] = int.MaxValue;

                    do
                    {
                        city = p2.path[d2];
                        --d2;
                    } while (problem.map[city] != 0);

                    path[r2] = city;
                    problem.map[city] = int.MaxValue;
                }

                if (N % 2 != 0)
                {
                    do
                    {
                        city = p1.path[d1];
                        ++d1;
                    } while (problem.map[city] != 0);

                    path[r1] = city;
                    problem.map[city] = int.MaxValue;
                }
            }

            // Проверка корректности особи
            int sum1 = 0, sum2 = 0;
            for (int i = 0; i != problem.cities.Count; ++i)
            {
                sum1 += i;
                sum2 += path[i];
                if (problem.map[path[i]] == -1)
                    MessageBox.Show("Error 1");
                problem.map[path[i]] = -1;
            }

            if (sum1 != sum2)
                MessageBox.Show("Error 2");
        }

        /// <summary>
        /// Подбрасывание монеты
        /// </summary>
        /// <returns> true с вероятностью 50%</returns>
        private bool flip()
        {
            return rand.Next(100) < 50;
        }

        /// <summary>
        /// Обновление длины пути
        /// </summary>
        public void Update()
        {
            nonFitness = problem.Cost(path, 0, path.Length);
        }

        /// <summary>
        /// "Жадная" мутация
        /// </summary>
        public void Mutation()
        {
            foreach (int c in this.path)
            {
                int x1 = rand.Next(this.path.Length);
                int x2 = rand.Next(this.path.Length);
                double f = nonFitness;
                if (x1 != x2)
                {
                    int tmp = path[x1];
                    path[x1] = path[x2];
                    path[x2] = tmp;
                    this.Update();
                    if (nonFitness < f)
                        return;
                    else
                    {
                        tmp = path[x1];
                        path[x1] = path[x2];
                        path[x2] = tmp;
                    }
                }
            }
        }

        #region Перегруженные методы
        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;
            bool b = true;
            Chromosome g = (Chromosome)obj;
            for (int i = 0; i != path.Length; ++i)
                if (path[i] != g.path[i])
                    b = false;
            return b;
        }

        public int CompareTo(object other)
        {
            if (other == null)
                return 1;
            return nonFitness.CompareTo(((Chromosome)other).nonFitness);
        }

        public override string ToString()
        {
            string s = string.Empty;
            foreach (int a in this.path)
            {
                s += a.ToString();
                s += ", ";
            }
            return s.Substring(0, s.LastIndexOf(','));
        }
        #endregion
    }
}
