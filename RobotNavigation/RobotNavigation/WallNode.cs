using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class WallNode : Node
    {
        public WallNode() : base(new Position(), "")
        { }
        public WallNode(Position pos, string s) : base(pos, s)
        {

        }

        public override int NodeCost()
        {
            throw new NotImplementedException();
        }
    }
}
