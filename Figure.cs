﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Figure
    {
        protected List<Point> pList;

        
        public void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsHit(Point p)
        {
            foreach (var point in pList)
            {
                if (p.IsHit(point))
                {
                    return true;
                }
            }
            return false;
        }
        public List<Point> GetPoints()
        {
            return pList;
        }
    }
}
