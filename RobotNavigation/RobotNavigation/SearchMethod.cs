using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public abstract class SearchMethod
    {
        Path _completedSearchPath;

        public SearchMethod()
        {
            _completedSearchPath = new Path();
        }

        public abstract bool Search(World world);

        public Path CompletedSearchPath
        {
            get { return _completedSearchPath; }
            set { _completedSearchPath = value; }
        }
    }
}
