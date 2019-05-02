using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class NeutralNode : Node
    {
        public NeutralNode(Position pos, string s) : base(pos, s)
        { }

        public override int NodeCost()
        {
            throw new NotImplementedException();
        }
    }
}
