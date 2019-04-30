using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class Agent
    {
        private SearchMethod _agentSearchMethod;

        public Agent()
        {
            _agentSearchMethod = null;
        }

        public Path Search(StartNode startNode, GoalNode goalNode)
        {
            try
            {
                return _agentSearchMethod.Search(startNode, goalNode);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                return new Path();
            }
        }
        
        public SearchMethod AgentSearchMethod
        {
            get { return _agentSearchMethod; }
            set { _agentSearchMethod = value; }
        }

        public override string ToString()
        {
            return _agentSearchMethod.ToString();
        }
    }
}
