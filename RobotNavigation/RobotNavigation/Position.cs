using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class Position
    {
        private int _x;
        private int _y;

        public Position()
        {}
        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public override string ToString()
        {
            return _x.ToString() + ' ' + _y.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Position pos = (Position)obj;
            return X.Equals(pos.X) && Y.Equals(pos.Y);
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }
    }
}
