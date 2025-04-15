using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class HorizontalLine
    {
        List<Point> plist;
        public HorizontalLine(int xleft, int xright, int y, char sym)
        {
            plist = new List<Point>();
            for(int x = xleft; x <= xright; x++) 
            {
                Point p=new Point(x,y,sym);
                plist.Add(p);
            }
            
        }

        public void Draw()
        {
            foreach (Point p in plist)
            {
                p.Draw();
            }
        }
    }
}
