using System;
using System.Collections.Generic;


namespace RobotNavigation
{
    public abstract class Node
    {
        private Position _pos;

        public Node(Position pos)
        {
            _pos = pos;
        }

        public Position Pos
        {
            get { return _pos; }
        }

        public abstract int NodeCost();
    }
}
