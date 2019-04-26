using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class DepthFirstSearch : Agent
    {
        public DepthFirstSearch(Node startNode, Node goalNode) : base(startNode, goalNode)
        {

        }

        public override bool Search()
        {
            Node currentNode;
            List<Node> reverse;
            // Reset Lists
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
                    return OutputPathFound(Path, Explored.Count, "Depth-First Search");                
                else
                {
                    // Iterates the number of paths explored.
                    Explored.Add(currentNode);            
                    // reverse the list and have that list added to the front of the frontier
                    reverse = currentNode.GetChildren();
                    reverse.Reverse();
                    AddNodePathsToFrontier(reverse, "f");                    
                }
            }
            return false;
        }
    }
}
