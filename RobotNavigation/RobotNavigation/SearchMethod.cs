using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public abstract class SearchMethod
    {
        public SearchMethod()
        {
        }

        public abstract Path Search(StartNode sN, GoalNode gN);

        public abstract string ToString();
    }
}
