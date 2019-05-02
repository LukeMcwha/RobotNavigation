using System;
using System.Collections.Generic;


namespace RobotNavigation
{
    public abstract class Node : IEquatable<Node>
    {
        private string _symbol;
        private Position _pos;
        private Node _up;
        private Node _right;
        private Node _down;
        private Node _left;


        public Node(Position pos, string s)
        {
            _symbol = s;
            _pos = pos;
            _up = null;
            _right = null;
            _down = null;
            _left = null;
        }

        public void SetChildren(World world)
        {
            // get up node
            // x == same y - 1
            _up = world.FindNode(new Position(Pos.X, Pos.Y - 1));
            // get right node
            // x + 1  y == same
            _right = world.FindNode(new Position(Pos.X + 1, Pos.Y));
            // get down node
            // x == same  y + 1
            _down= world.FindNode(new Position(Pos.X, Pos.Y + 1));
            // get left node
            // x - 1  y == same
            _left = world.FindNode(new Position(Pos.X - 1, Pos.Y));
        }

        public List<Node> GetChildren()
        {
            List<Node> children = new List<Node>();
            children.Add(Up);
            children.Add(Right);
            children.Add(Down);
            children.Add(Left);
            return children;
        }

        public override string ToString()
        {
            return Symbol.ToString();
        }

        public bool Equals(Node other)
        {
            if (other == null || GetType() != other.GetType())
                return false;
            return Pos.Equals(other.Pos);
        }

        public override int GetHashCode()
        {
            return Pos.GetHashCode();
        }

        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }
        public Position Pos
        {
            get { return _pos; }
        }
        public Node Up
        {
            get { return _up; }
        }
        public Node Right
        {
            get { return _right; }
        }
        public Node Down
        {
            get { return _down; }
        }
        public Node Left
        {
            get { return _left; }
        }
        public abstract int NodeCost();
    }
}
