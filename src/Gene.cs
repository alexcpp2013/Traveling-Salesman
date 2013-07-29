using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace aiGenetic
{
    class Gene : IComparable
    {
        public int[] path;
        public TSP problem;
        public double nonfitness;
        Rand rand;

        public Gene(TSP p)
        {
            this.problem = p;
            this.path = new int[p.cities.Count];

            this.rand = new Rand();
            for (int i = 0; i != p.cities.Count; ++i)
            {
                path[i] = -1;
            }
            for (int i = 0; i != p.cities.Count; ++i)
            {
                byte[] bb = new byte[4];
                int city = 0;
                do
                {
                    city = rand.Next(p.cities.Count);
                } while (path.Contains(city));
                path[i] = city;
            }
        }

        public Gene(Gene p1, Gene p2, Crossover c)
        {
            this.problem = p1.problem;
            this.rand = new Rand();
            List<int> cache = new List<int>();
            this.path = new int[problem.cities.Count];

            if (c == Crossover.Greedy)
            {
                // Greedy Crossover

                if (flip())
                    path[0] = p1.path[0];
                else
                    path[0] = p2.path[0];

                problem.ResetMap();
                problem.map[path[0]] = int.MaxValue;

                for (int i = 0; i != problem.cities.Count - 1; )
                {
                    int v = path[i++];
                    int i1, i2;

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

                    if (v1 != int.MaxValue && v2 != int.MaxValue)
                    {
                        if (v1 == v2)
                            path[i] = v1;
                        else
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
                        // search a first unused point into a cache
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

        private bool flip()
        {
            return (rand.Next(100) < 50);
        }

        public void update()
        {
            nonfitness = problem.Cost(path, 0, path.Length);
        }

        public void mutation()
        {
            //if (rand.Next(100) < 20)
            //{

            //}
            int x1 = rand.Next(problem.cities.Count);
            int x2 = rand.Next(problem.cities.Count);
            if (x1 != x2)
            {
                int tmp = path[x1];
                path[x1] = path[x2];
                path[x2] = tmp;
                return;
            }
        }

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;
            bool b = true;
            Gene g = (Gene)obj;
            for (int i = 0; i != path.Length; ++i)
                if (path[i] != g.path[i])
                    b = false;
            return b;
        }

        public int CompareTo(object other)
        {
            if (other == null)
                return 1;

            return nonfitness.CompareTo(((Gene)other).nonfitness);
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
    }
}
