using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    public class Position
    {
        private int _x;
        private int _y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X
        {
            get { return _x; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                else if(value > 7)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                else
                {
                    _x = value;
                }
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                else if (value > 7)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                else
                {
                    _y = value;
                }
            }
        }
    }
}
