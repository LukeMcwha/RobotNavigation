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
        Queue<Node> _frontierNode;
        Queue<Path> _frontierPath;
        List<Node> _explored;
        

        public BreadthFirstSearch()
        {
            _frontierNode = new Queue<Node>();
            _frontierPath = new Queue<Path>();
            _explored = new List<Node>();
        }

        public override bool Search(World world)
        {
            // Starting Node in the world
            Node currentNode = world.Start;
            // Starting path that contains only the node
            Path currentPath = new Path();
            List<Node> children;

            // If the goal node is the current Node, then return true with path of only that node
            if (world.Goal == currentNode)
            {
                CompletedSearchPath.NodePath.Add(currentNode);
                return true;
            }
            // Add Node to the frontier
            FrontierNode.Enqueue(currentNode);
            // Add initial Path to the frontier
            FrontierPath.Enqueue(currentPath);
            
            // while frontier is not empty
            while (FrontierNode.Count > 0 && FrontierPath.Count > 0)
            {
                // get next node
                currentNode = FrontierNode.Dequeue();
                // get next Path
                currentPath = FrontierPath.Dequeue();
                
                // add this node to explored list
                Explored.Add(currentNode);
                // add this node to the path
                currentPath.Add(currentNode);
                // Get children of the current node
                children = currentNode.GetChildren();

                foreach (Node n in children)
                {
                    if (!FrontierNode.Contains(n) && !Explored.Contains(n))
                    {
                        if (n is GoalNode)
                        {
                            currentPath.Add(n);
                            CompletedSearchPath = currentPath;
                            return true;
                        }
                        else
                        {
                            if (!(n is WallNode))
                            {
                                // Add 
                                FrontierNode.Enqueue(n);
                                FrontierPath.Enqueue(new Path(new List<Node>(currentPath.NodePath)));
                            }
                        }
                    }
                }
                // 0.5s between each loop to help visualise.
                //System.Threading.Thread.Sleep(500);
            }
            // if program gets there then there is no solution
            return false;
        }

        private Queue<Node> FrontierNode
        {
            get { return _frontierNode; }
        }
        private Queue<Path> FrontierPath
        {
            get { return _frontierPath; }
        }
        private List<Node> Explored
        {
            get { return _explored; }
        }
    }
}
