using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class BreadthFirstSearch : Agent
    {
        public BreadthFirstSearch(Node startNode, Node goalNode) : base(startNode, goalNode)
        {

        }

        public override bool Search()
        {
            Node currentNode;
            // Reset lists
            ResetLists();
            // add the first node to the path list
            Path.Add(StartNode);
            // add that path list to the frontier
            Frontier.AddLast(Path);
            while (Frontier.Count != 0)
            {
                // Get first path list from the frontier and then remove it from the frontier
                Path = Frontier.First();
                Frontier.Remove(Path);
                // get the last node from the list
                currentNode = Path.Last();
                // Check whether the current node is the goal node
                if (currentNode == GoalNode)                
                    return OutputPathFound(Path, Explored.Count, "Breadth-First Search");                
                else
                {
                    // add node to explored nodes
                    Explored.Add(currentNode);
                    // Add new node paths to the end of the frontier, as per BFS
                    AddNodePathsToFrontier(currentNode.GetChildren(), "l"); 
                }
            }
            return false;
        }
    }
}
