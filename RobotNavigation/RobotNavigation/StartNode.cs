using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class StartNode : Node
    {
        public StartNode(Position pos, string s) : base(pos, s)
        {

        }
        public StartNode(Node n) : base(n)
        {

        }

        public override Node CopyNode()
        {
            return new StartNode(this);
        }

        public override int NodeCost()
        {
            throw new NotImplementedException();
        }
    }
}
