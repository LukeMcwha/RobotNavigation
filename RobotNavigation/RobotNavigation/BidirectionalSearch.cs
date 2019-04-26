using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class BidirectionalSearch : Agent
    {
        // Frontier is a list of paths from goal
        private LinkedList<List<Node>> _gFrontier = new LinkedList<List<Node>>();
        // Path is a list of nodes from goal
        private List<Node> _gPath = new List<Node>();
        // List of explored nodes from goal
        private List<Node> _gExplored = new List<Node>();

        public BidirectionalSearch(Node startNode, Node goalNode) : base(startNode, goalNode)
        { }

        public override bool Search()
        {
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

            while (Frontier.Count != 0 | GFrontier.Count != 0)
            {
                // Get first path list from the frontier and then remove it from the frontier
                Path = Frontier.First();
                Frontier.Remove(Path);
                // do same for gFrontier
                GPath = GFrontier.First();                
                GFrontier.Remove(GPath);

                // get the last node from the list
                Node currentNode = Path.Last();
                Node gCurrentNode = GPath.Last();

                // Check whether path is found
                foreach(List<Node> gPaths in GFrontier)
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
                foreach(List<Node> paths in Frontier)
                {
                    if(paths.Contains(gCurrentNode)) // any paths for frontier contains the current gnode.
                    {
                        // get the current nodes path then add gPaths rest of nodes to goal.
                        List<Node> finalPath = new List<Node>();
                        List<Node> gPathReverse = GPath.ToList();
                        gPathReverse.Reverse();

                        bool foundInPath = false;
                        foreach(Node n in paths)
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

                // Adding to frontier from start
                Explored.Add(currentNode);
                GExplored.Add(gCurrentNode);
                
                AddNodePathsToFrontier(currentNode.GetChildren(), "l");                
                
                foreach (Node child in gCurrentNode.GetChildren())
                {
                    List<Node> newList = GPath.ToList();
                    if (!GPath.Contains(child) && !GExplored.Contains(child)) // if the path already contains the child. Do not add that path to the frontier
                    {
                        newList.Add(child);                       
                        GFrontier.AddLast(newList);                            
                    }
                } 
            }
            return false;
        }

        public bool PathFound()
        {
            foreach(Node forward in Explored)
            {
                if(GExplored.Contains(forward))
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
