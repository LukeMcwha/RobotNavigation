using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class DepthFirstSearch : SearchMethod
    {
        Stack<Node> _frontierNode;
        Stack<Path> _frontierPath;
        List<Node> _explored;


        public DepthFirstSearch()
        {
            _frontierNode = new Stack<Node>();
            _frontierPath = new Stack<Path>();
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
            FrontierNode.Push(currentNode);
            // Add initial Path to the frontier
            FrontierPath.Push(currentPath);

            // while frontier is not empty
            while (FrontierNode.Count > 0 && FrontierPath.Count > 0)
            {
                // get next node
                currentNode = FrontierNode.Pop();
                // get next Path
                currentPath = FrontierPath.Pop();

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
                            Console.Clear();
                            return true;
                        }
                        else
                        {
                            if (!(n is WallNode))
                            {
                                // Add 
                                FrontierNode.Push(n);
                                FrontierPath.Push(new Path(currentPath));
                            }
                        }
                    }
                }
                Console.Clear();
                world.PrintPath(currentPath);
                // 0.5s between each loop to help visualise.
                System.Threading.Thread.Sleep(300);
            }
            // if program gets there then there is no solution
            return false;
        }

        private Stack<Node> FrontierNode
        {
            get { return _frontierNode; }
        }
        private Stack<Path> FrontierPath
        {
            get { return _frontierPath; }
        }
        private List<Node> Explored
        {
            get { return _explored; }
        }
    }
}
