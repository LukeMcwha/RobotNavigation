using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    
    public class Path
    {
        private List<Node> _nodePath;
        
        public Path()
        {
            _nodePath = new List<Node>();
        }
        public Path(Node node)
        {
            _nodePath = new List<Node>();
            _nodePath.Add(node);
        }
        public Path(List<Node> nList)
        {
            _nodePath = nList;
        }
        public Path(Path p)
        {
            _nodePath = new List<Node>(p.NodePath);
        }

        public void Add(Node n)
        {
            NodePath.Add(n);
        }

        public Node GetLast()
        {
            return _nodePath.Last();
        }

        public List<Node> NodePath
        {
            get { return _nodePath; }
        }

        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
                return false;
            Path p = (Path)other;
            return NodePath.Equals(p.NodePath);
        }

        public override int GetHashCode()
        {
            return NodePath.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Node n in NodePath)
            {
                sb.Append(n.Pos.ToString());
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
