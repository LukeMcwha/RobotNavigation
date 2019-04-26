using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public abstract class Agent
    {
        private Node _startNode;
        private Node _goalNode;
        // Frontier is a list of paths
        private LinkedList<List<Node>> _frontier = new LinkedList<List<Node>>();
        // Path is a list of nodes
        private List<Node> _path = new List<Node>();
        // List of explored nodes
        private List<Node> _explored = new List<Node>();

        // Agent Constructor
        public Agent(Node startNode, Node goalNode)
        {
            _startNode = startNode;
            _goalNode = goalNode;
        }

        public abstract bool Search();

        public void AddNodePathsToFrontier(List<Node> currentNodeList, string position)
        {
            foreach (Node child in currentNodeList)
            {
                List<Node> newList = Path.ToList();
                if (!Path.Contains(child) && !Explored.Contains(child)) // if the path already contains the child. Do not add that path to the frontier
                {
                    newList.Add(child);
                    if (position == "f")
                        Frontier.AddFirst(newList);
                    else if(position == "l")
                        Frontier.AddLast(newList);
                }
            }
        }

        public void ResetLists()
        {
            // Reset all lists
            Frontier.Clear();
            Path.Clear();
            Explored.Clear();
        }

        public bool OutputPathFound(List<Node> winningPath, int explored, string method)
        {
            // print the number of iterations to find the goal
            Console.Write(String.Format("Robot Navigation {0} {1} {2}", method, explored, OutputFinalPath(winningPath)));
            // print the directions the agent moves to get to the goal
            OutputFinalPath(winningPath);
            return true;
        }

        private string OutputFinalPath(List<Node> winningPath) // Returns a list of moves that the agent takes to get to the final destination
        {
            string output = "";
            for(int i = 0; i < winningPath.Count; i++)
            {
                if (i == winningPath.Count - 1)
                    output += "Destination Found;\n";
                else
                    output += winningPath[i].NodeDirection(winningPath[i + 1].Pos) + "; ";
            }
            return output;
        }

        public Node StartNode
        {
            get { return _startNode; }
            set { _startNode = value; }
        }
        public Node GoalNode
        {
            get { return _goalNode; }
            set { _goalNode = value; }
        }
        public LinkedList<List<Node>> Frontier
        {
            get { return _frontier; }
        }
        public List<Node> Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public List<Node> Explored
        {
            get { return _explored; }
        }
    }
}
