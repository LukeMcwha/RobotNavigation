using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class GoalNode : Node
    {
        public GoalNode(Position pos, string s) : base(pos, s)
        {

        }

        public override int NodeCost()
        {
            throw new NotImplementedException();
        }
    }
}
