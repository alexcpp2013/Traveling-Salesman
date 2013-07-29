using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aiGenetic
{
    class Genetic
    {
        List<Chromosome> population;
        TSP tsp;
        Settings settings;
        Rand r;

        /// <summary>
        /// Конструктор Genetic. Выбрасывает пойманные исключения Exception.
        /// </summary>
        /// <param name="population_size">Требуемый размер популяции.</param>
        /// <param name="task">Задача коммивояжера.</param>
        /// <param name="settings">Настройки.</param>
        public Genetic(int population_size, TSP task, Settings settings)
        {
            try
            {
                population = new List<Chromosome>(population_size);
                r = new Rand();
                this.tsp = task;
                this.settings = settings;
                this.Initialize(population_size);
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Создает / изменяет популяцию до нужного размера.
        /// </summary>
        /// <param name="size">Требуемый размер популяции.</param>
        public void Initialize(int size)
        {
            int d = population.Count - size;
            if (d < 0)
                d = -d;
            else
                population.RemoveRange(d, population.Count - d);

            while (d-- > 0)
                population.Add(new Chromosome(tsp));
        }

        /// <summary>
        /// Обновляет значение приспособленности.
        /// </summary>
        public void Update()
        {
            for (int i = 0; i != population.Count; ++i)
                population[i].Update();
        }

        /// <summary>
        /// Находит лучший экземпляр.
        /// </summary>
        /// <returns>Лучший экземпляр.</returns>
        public static Chromosome FindBest(List<Chromosome> pool)
        {
            try
            {
                int min, i, N = pool.Count;

                for (min = 0, i = 0; i != N; ++i)
                    if (pool[min].NonFitness > pool[i].NonFitness)
                        min = i;

                return pool[min];
            }
            catch (ArgumentOutOfRangeException)
            { return null; }
        }

        /// <summary>
        /// Находит лучший экземпляр.
        /// </summary>
        /// <returns>Лучший экземпляр.</returns>
        public Chromosome FindBest()
        {
            return FindBest(this.population);
        }

        /// <summary>
        /// Отвечает за жизненные процессы популяции.
        /// </summary>
        public void DoRecombination()
        {
            int psize = population.Count;
            int elite_size = (int)(psize * settings.elitePercent * 0.01);
            population.Sort();

            if (this.settings.eliminateTwins)
            {
                for (int i = 0; i != population.Count; ++i)
                    for (int j = 0; j != population.Count; ++j)
                        if (i != j && population[i] == population[j])
                            population.Remove(population[j]);
            }

            // selection and crossover
            if (settings.crossoverPercent == 0 ||
                (settings.crossoverPercent < 100 && r.Next(100) > settings.crossoverPercent))
            {
                int ds = psize - population.Count;
                while (ds-- > 0)
                    population.Add(new Chromosome(tsp));
                return;
            }

            List<Chromosome> children = new List<Chromosome>();
            DoSelection(population, children, psize - elite_size);

            int s = psize - children.Count;
            int selite = Math.Min(population.Count, elite_size);
            if (s > 0)
            {
                if (selite > 0)
                {
                    children.AddRange(population.GetRange(0, selite));
                    s -= selite;
                }

                for (int y = 0; y != s; ++y)
                    children.Add(new Chromosome(tsp));
            }
            population = children;
        }

        /// <summary>
        /// Мутация популяции.
        /// </summary>
        /// <returns>true, если произошла хотя бы одна мутация.</returns>
        public bool DoMutation()
        {
            bool m = false;
            foreach (Chromosome g in population)
            {
                if (r.Next(100) < settings.mutationPercent)
                {
                    g.Mutation();
                    m = true;
                }
            }
            return m;
        }

        /// <summary>
        /// Выбирает родителя методом рулетки
        /// </summary>
        /// <param name="d">Пары геном-приспособленность</param>
        /// <returns>Выбранный экземпляр</returns>
        Chromosome SpinRoulette(Dictionary<Chromosome, float> d)
        {
            float last = 0, val = 0;
            val = (float)r.Next(100);

            for (int i = 0; i != d.Count; ++i)
            {
                float value = d[population[i]];
                if (last <= val && val <= value)
                    return population[i];
                last = value;
            }
            return null;
        }

        /// <summary>
        /// Селекция родителей и кроссовер выбранных пар.
        /// </summary>
        /// <param name="parents">Популяция родителей.</param>
        /// <param name="children">Новая популяция детей.</param>
        /// <param name="size">Требуемый размер популяции детей.</param>
        private void DoSelection(List<Chromosome> parents, List<Chromosome> children, int size)
        {
            switch (settings.selection)
            {
                case Selection.Roulette:
                    {
                        // Создание пула возможных родителей
                        Dictionary<Chromosome, float> roulPool = new Dictionary<Chromosome, float>();
                        float multiInv = .0f, upperChance = .0f;
                        Chromosome g;

                        foreach (Chromosome gm in population)
                            multiInv += 1.0f / (float)gm.NonFitness;

                        for (int i = 0; i != population.Count; ++i)
                        {
                            g = population[i];
                            upperChance = upperChance + (float)((1.0f / g.NonFitness / multiInv) * 100.0f);
                            roulPool.Add(g, upperChance);
                        }

                        // Выбор родителей и скрещивание
                        int max_try = size * 4;

                        while ((children.Count < size) && (--max_try > 0))
                        {
                            // Выбор родителей из пула
                            Chromosome parent1 = SpinRoulette(roulPool);
                            Chromosome parent2 = SpinRoulette(roulPool);

                            if (parent1 != null && parent2 != null &&
                                parent1 != parent2)
                            {
                                // Кроссовер
                                children.Add(new Chromosome(parent1, parent2, settings.crossover));
                            }
                        }
                    }
                    break;
                case Selection.Tournament:
                    {
                        int max_try = size * 4;
                        while ((children.Count < size) && (--max_try > 0))
                        {
                            // Создание пула возможных родителей
                            List<Chromosome> tournPool = new List<Chromosome>();
                            int n;
                            do
                                n = r.Next(parents.Count);
                            while (n < 2);

                            for (int i = 0; i != n; ++i)
                            {
                                Chromosome g = parents[r.Next(parents.Count)];
                                tournPool.Add(g);
                            }

                            // Выбор родителей из пула
                            Chromosome parent1 = FindBest(tournPool);
                            tournPool.Remove(parent1);
                            Chromosome parent2 = FindBest(tournPool);

                            if (parent1 != null && parent2 != null
                                && parent1 != parent2)
                            {
                                // Кроссовер
                                children.Add(new Chromosome(parent1, parent2, settings.crossover));
                            }
                        }
                    }
                    break;
            }
        }
    }
}
