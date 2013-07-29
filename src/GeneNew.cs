using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Gene(Gene p1, Gene p2)
        {
            this.problem = p1.problem;
            this.rand = new Rand();

            this.path = new int[problem.cities.Count];

            // Crossover

            if (flip())
                path = p1.path;
            else
                path = p2.path;

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

                int v1 = (i1 < p1.path.Length ? ++i1 : 0);
                int v2 = (i2 < p2.path.Length ? ++i2 : 0);

                if (problem.map[p1.path[v1]] != 0)
                    v1 = int.MaxValue;

                if (problem.map[p2.path[v2]] != 0)
                    v2 = int.MaxValue;

                if (v1 != int.MaxValue && v2 != int.MaxValue)
                {
                    if (v1 == v2)
                        path[i] = v1;
                    else
                    {
                        double c1 = problem.cost(path, v, v1);
                        double c2 = problem.cost(path, v, v2);
                        if (c1 > 0 && c1 < c2)
                        {
                            path[i] = v1;
                            cache.Add(v2);
                        }
                        else
                        {
                            if (c2 > 0 && c2 < c1)
                            {
                                path[i] = v2;
                                cache.Add(v1);
                            }
                            else
                            {
                                path[i] = v1;
                                cache.Add(v2);
                            }
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
                    for (int k = cache.Count - 2; k != -1; ++k)
                    {
                        if (problem.map[k] != 0)
                        {
                            path[i] = k;
                            break;
                        }
                    }
                }

                problem.map[path[i]] = int.MaxValue;
            }
        }

        private bool flip()
        {
            return (rand.Next(100) < 50);
        }

        public void update()
        {
            nonfitness = problem.cost(path, 0, path.Length);
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

        public static bool operator ==(Gene gn1, Gene gn2)
        {
            if (gn1.path == gn2.path)
                return true;
            return false;
        }

        public static bool operator !=(Gene gn1, Gene gn2)
        {
            if (gn1.path != gn2.path)
                return true;
            return false;
        }

        public int CompareTo(object obj)
        {
            if (this.nonfitness < ((Gene)obj).nonfitness)
                return -1;
            else
                return 1;
        }
    }
}
