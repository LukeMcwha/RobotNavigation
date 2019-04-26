using System;
using System.Collections.Generic;


namespace RobotNavigation
{
    public class Node
    {
        private Position _pos;
        private Node _upChild;
        private Node _rightChild;
        private Node _downChild;
        private Node _leftChild;
        private bool _blocked;
        private int _nodeCost;

        public Node(int x, int y)
        {
            _pos = new Position(x, y);
            _upChild = null;
            _rightChild = null;
            _downChild = null;
            _leftChild = null;
            _blocked = false;
        }

        public void AddDirectionNodes(Node up, Node right, Node down, Node left)
        {
            _upChild = up;
            _rightChild = right;
            _downChild = down;
            _leftChild = left;
        }

        public Position Pos
        {
            get { return _pos; }
        }

        public bool Blocked
        {
            get { return _blocked; }
            set { _blocked = value; }
        }

        public List<Node> GetChildren()
        {
            List<Node> childNodes = new List<Node>();

            if (_upChild != null)
                childNodes.Add(_upChild);
            if (_rightChild != null)
                childNodes.Add(_rightChild);
            if (_downChild != null)
                childNodes.Add(_downChild);
            if (_leftChild != null)
                childNodes.Add(_leftChild);
            
            return childNodes;
        }

        public Moves NodeDirection(Position parent)
        {
            if (UpChild != null && parent == UpChild.Pos)
                return Moves.Up;
            else if (RightChild != null && parent == RightChild.Pos)
                return Moves.Right;
            else if (DownChild != null && parent == DownChild.Pos)
                return Moves.Down;
            else if (LeftChild != null && parent == LeftChild.Pos)
                return Moves.Left;
            else
                return Moves.Invalid;
        }

        public Node UpChild
        {
            get { return _upChild; }
            set { _upChild = value; }
        }
        public Node RightChild
        {
            get { return _rightChild; }
            set { _rightChild= value; }
        }
        public Node DownChild
        {
            get { return _downChild; }
            set { _downChild= value; }
        }
        public Node LeftChild
        {
            get { return _leftChild; }
            set { _leftChild = value; }
        }
        public int NodeCost
        {
            get { return _nodeCost; }
            set { _nodeCost = value; }
        }
    }
}
