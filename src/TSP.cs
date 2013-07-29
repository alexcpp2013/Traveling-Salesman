using System;
using System.Collections.Generic;
using System.Drawing;

namespace aiGenetic
{
    class TSP
    {
        // Список городов
        public List<Point> cities;

        // Матрица длин маршрутов
        float[,] routes;

        public int[] map;

        public TSP(int cityCnt)
        {
            cities = new List<Point>();
            Create(cityCnt);
        }

        public TSP(List<Point> cities)
        {
            this.cities = cities;
            Create(cities.Count);
        }

        private void Create(int cityCnt)
        {
            routes = new float[cityCnt, cityCnt];
            map = new int[cityCnt];
        }

        public void add(int x, int y)
        {
            cities.Add(new Point(x, y));
        }

        public void Init()
        {
            for (int iy = 0; iy < cities.Count; ++iy)
                for (int ix = 0; ix < cities.Count; ++ix)
                    routes[ix, iy] = (float)Cost(cities[ix], cities[iy]);
        }

        public void ResetMap()
        {
            for (int iy = 0; iy < cities.Count; ++iy)
                map[iy] = 0;
        }

        public double Cost(Point pt1, Point pt2)
        {
            int x = Math.Abs(pt1.X - pt2.X);
            int y = Math.Abs(pt1.Y - pt2.Y);
            if (x == 0)
                return y;
            if (y == 0)
                return x;
            return Math.Sqrt((double)(x * x + y * y));
        }


        public double Cost(int[] path, int idxC1, int idxC2)
        {
            if (idxC1 == idxC2)
                return 0.0;
            double c = 0;
            int i = idxC1, j = idxC1 + 1;
            if (idxC1 > idxC2)
            {
                idxC1 = idxC2;
                idxC2 = i;
            }
            for (; j != idxC2; ++i, ++j)
                c += routes[path[i], path[j]];

            c += routes[path[i], path[idxC1]];
            return c;
        }

        public double Distance(int City1, int City2)
        {
            if (City1 == City2)
                return 0.0;
            return routes[City1, City2]; ;
        }
    }
}
