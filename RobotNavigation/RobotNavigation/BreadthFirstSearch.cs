using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{

    /* Algorithm Pseduocode found from textbook 
     * Artifical Intellegence: A Modern Approach
     * by Stuart Russell and Peter Norvig
     * page 82
    */
    public class BreadthFirstSearch : SearchMethod
    {
        Queue<Node> _frontier;
        List<Node> _explored;
        

        public BreadthFirstSearch()
        {
            _frontier = new Queue<Node>();
            _explored = new List<Node>();
            
        }

        public override bool Search(World world)
        {
            Node currentNode = world.Start;
            List<Node> children;

            if (world.Goal == currentNode)
            {
                CompletedSearchPath.NodePath.Add(currentNode);
                return true;
            }
            Frontier.Enqueue(currentNode);
            
            // TODO: IMPLEMENT Paths into Search.
            
            // while frontier is not empty
            while (Frontier.Count > 0)
            {
                // get next node
                currentNode = Frontier.Dequeue();
                // add this node to explored list
                Explored.Add(currentNode);

                children = currentNode.GetChildren();

                foreach (Node n in children)
                {
                    if (!Frontier.Contains(n) || !Explored.Contains(n))
                    {
                        if (n is GoalNode)
                            return true;
                        else
                            if (!(n is WallNode))
                                Frontier.Enqueue(n);
                    }
                }
                // 0.5s between each loop to help visualise.
                //System.Threading.Thread.Sleep(500);
            }
            // if program gets there then there is no solution
            return false;
        }

        private Queue<Node> Frontier
        {
            get { return _frontier; }
        }
        private List<Node> Explored
        {
            get { return _explored; }
        }
    }
}
