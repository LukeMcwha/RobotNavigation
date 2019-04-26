using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class BidirectionalGreedySearch : Agent
    {
        // Frontier is a list of paths from goal
        private LinkedList<List<Node>> _gFrontier = new LinkedList<List<Node>>();
        // Path is a list of nodes from goal
        private List<Node> _gPath = new List<Node>();
        // List of explored nodes from goal
        private List<Node> _gExplored = new List<Node>();

        public BidirectionalGreedySearch(Node startNode, Node goalNode) : base(startNode, goalNode)
        { }

        public override bool Search()
        {
            List<Node> reverse;
            Node currentNode;
            Node gCurrentNode;
            // Reset Lists
            ResetLists();

            // add the first node to the path list
            Path.Add(StartNode);
            // add that path list to the frontier
            List<Node> subList = Path.ToList();
            Frontier.AddLast(subList);
            // add the first node to the goal path list
            GPath.Add(GoalNode);
            // add that path list to the goal Frontier
            subList = GPath.ToList();
            GFrontier.AddLast(subList);


            while (Frontier.Count != 0)
            {
                // Get path list with least cost from the frontier and assign it to path and then remove it from the frontier
                foreach (List<Node> p in Frontier)
                {
                    if (!(Path.Count > 0))
                        Path = p;
                    else
                    {
                        if (Path.Last().NodeCost > p.Last().NodeCost)
                            Path = p;
                    }
                }
                Frontier.Remove(Path);
                // GFrontier 
                foreach (List<Node> p in GFrontier)
                {
                    if (!(GPath.Count > 0))
                        GPath = p;
                    else
                    {
                        if (GPath.Last().NodeCost > p.Last().NodeCost)
                            GPath = p;
                    }
                }
                Frontier.Remove(Path);

                // get the last node from the list
                currentNode = Path.Last();
                gCurrentNode = GPath.Last();

                // Check whether the current node is the goal node
                foreach (List<Node> gPaths in GFrontier)
                {
                    if (gPaths.Contains(currentNode)) // any paths from GFrontier contains the current node
                    {
                        // get the current nodes path then add gPaths rest of nodes to goal.
                        List<Node> finalPath = Path;
                        List<Node> gPathReverse = gPaths.ToList();
                        gPathReverse.Reverse();

                        bool foundInPath = false;
                        foreach (Node node in gPathReverse)
                        {
                            if (foundInPath)
                                finalPath.Add(node);
                            else if (Object.ReferenceEquals(currentNode, node)) // need to find the intersection -----                            
                                foundInPath = true;
                        }
                        OutputPathFound(finalPath, Explored.Count + GExplored.Count, "Bi-directional Search");
                        return true;
                    }
                }
                foreach (List<Node> paths in Frontier)
                {
                    if (paths.Contains(gCurrentNode)) // any paths for frontier contains the current gnode.
                    {
                        // get the current nodes path then add gPaths rest of nodes to goal.
                        List<Node> finalPath = new List<Node>();
                        List<Node> gPathReverse = GPath.ToList();
                        gPathReverse.Reverse();

                        bool foundInPath = false;
                        foreach (Node n in paths)
                        {
                            if (Object.ReferenceEquals(gCurrentNode, n))
                                foundInPath = true;
                            else if (!foundInPath)
                                finalPath.Add(n);
                        }
                        foreach (Node gNode in gPathReverse)
                            finalPath.Add(gNode);
                        OutputPathFound(finalPath, Explored.Count + GExplored.Count, "Bi-directional Search");
                        return true;
                    }
                } 
                
                // Iterates the number of paths explored.
                Explored.Add(currentNode);
                GExplored.Add(gCurrentNode);

                reverse = currentNode.GetChildren();
                reverse.Reverse();
                AddNodePathsToFrontier(reverse, "f");

                reverse = gCurrentNode.GetChildren();
                reverse.Reverse();
                foreach (Node child in reverse)
                {
                    List<Node> newList = GPath.ToList();                    
                    if (!GPath.Contains(child) && !GExplored.Contains(child)) // if the path already contains the child. Do not add that path to the frontier
                    {
                        newList.Add(child);
                        GFrontier.AddLast(newList);
                    }
                }

                // reset path
                Path.Clear();
                reverse.Clear();
            }
            return false;
        }

        public bool PathFound()
        {
            foreach (Node forward in Explored)
            {
                if (GExplored.Contains(forward))
                {
                    return true;
                }
            }
            return false;
        }

        public LinkedList<List<Node>> GFrontier
        {
            get { return _gFrontier; }
        }
        public List<Node> GPath
        {
            get { return _gPath; }
            set { _gPath = value; }
        }
        public List<Node> GExplored
        {
            get { return _gExplored; }
            set { _gExplored = value; }
        }
    }
}
