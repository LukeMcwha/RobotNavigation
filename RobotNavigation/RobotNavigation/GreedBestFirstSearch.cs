using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class GreedBestFirstSearch : Agent
    {
        public GreedBestFirstSearch(Node startNode, Node goalNode) : base(startNode, goalNode)
        {

        }

        public override bool Search()
        {
            // Reset lists
            ResetLists();

            // add the first node to the path list
            Path.Add(StartNode);
            // add that path list to the frontier
            List<Node> subList = Path.ToList();
            Frontier.AddLast(subList);

            while (Frontier.Count != 0)
            {
                // reset path
                Path.Clear();
                // Get path list with least cost from the frontier and assign it to path and then remove it from the frontier
                foreach (List<Node> p in Frontier)
                {
                    if (!(Path.Count > 0))
                        Path = p;
                    else                    
                        if (Path.Last().NodeCost > p.Last().NodeCost)
                            Path = p;                    
                }
                Frontier.Remove(Path);

                // get the last node from the list
                Node currentNode = Path.Last();
                // Check whether the current node is the goal node
                if (currentNode == GoalNode)                
                    return OutputPathFound(Path, Explored.Count, "Greedy Best-First");                
                else
                {
                    // Iterates the number of paths explored.
                    Explored.Add(currentNode);                  
                    AddNodePathsToFrontier(currentNode.GetChildren(), "l");                    
                }
            }
            return false;
        }
    }
}
