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

        public List<Node> NodePath
        {
            get { return _nodePath; }
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
