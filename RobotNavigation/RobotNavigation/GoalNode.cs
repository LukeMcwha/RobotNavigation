using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class GoalNode : Node
    {
        public GoalNode(Position pos) : base(pos)
        {

        }

        public override int NodeCost()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "G";
        }
    }
}
