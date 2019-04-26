using System;
using System.Collections.Generic;
using System.IO;

namespace RobotNavigation
{
    public enum Moves
    {
        Up,
        Down,
        Left,
        Right,
        Invalid
    }

    public class World
    {
        private List<Node> _nodeList = new List<Node>();
        private Agent _movementAgent;
        private string _agent;


        public World(string file)
        {
            ExtractFile(file);
        }
        

        private void ExtractFile(string file)
        {
            try
            {
                // Create an instance of StreamREader to read from a file
                // the using statement also closes the StreamReader
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    // Read and display lines from the file until the end of the file is met.
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }







        /*
        public void ExtractFile()
        {
            // Getting the width and height of the nodes in the world
            string[] line = FormatString(File[0]);
            int worldWidth = Convert.ToInt32(line[1]);
            int worldHeight = Convert.ToInt32(line[0]);

            // Getting the START VECTOR of the agent
            line = FormatString(File[1]);
            Position startPos = new Position(Convert.ToInt32(line[0]), Convert.ToInt32(line[1]));
          
            // Getting the GOAL VECTOR of the agent
            line = FormatString(File[2]);
            Position goalPos = new Position(Convert.ToInt32(line[0]), Convert.ToInt32(line[1]));
            
            // define the start and goal nodes
            Node startNode = null;
            Node goalNode = null;
            Node newNode;
            // Creates nodes with positions
            for (int i = 0; i < worldWidth; i++)
            {
                for (int j = 0; j < worldHeight; j++)
                {
                    // Creates new node at position [i,j]
                    newNode = new Node(i, j);
                    // Give the node a distance to goal (cost)
                    newNode.NodeCost = ManhattanDistance(newNode.Pos, goalPos);
                    
                    NodeList.Add(newNode); // adds new node to the node list
                    if (newNode.Pos == startPos) // checks whether node is the start position
                        startNode = newNode; 
                    else if (newNode.Pos == goalPos) // checks whether node is the goal position
                        goalNode = newNode;
                }
            }

            // Create agent using the start node and goal node
            if (startNode != null && goalNode != null)
                // Create agent
                switch (Agent)
                {
                    case "BFS":
                        MovementAgent = new BreadthFirstSearch(startNode, goalNode);
                        break;
                    case "DFS":
                        MovementAgent = new DepthFirstSearch(startNode, goalNode);
                        break;
                    case "GBFS":
                        MovementAgent = new GreedBestFirstSearch(startNode, goalNode);
                        break;
                    case "AS":
                        MovementAgent = new AStar(startNode, goalNode);
                        break;
                    case "CUS1":
                        MovementAgent = new BidirectionalSearch(startNode, goalNode);
                        break;
                    case "CUS2":
                        MovementAgent = new BidirectionalGreedySearch(startNode, goalNode);
                        break;
                    default:
                        break;
                }

            // Tell nodes whether they are blocked
            foreach (string l in File)
            {
                line = FormatString(l);

                if (line.Length < 4) // if string array is less then 4 it is not a wall
                    continue;
                else
                {
                    int x = Convert.ToInt32(line[0]); // Get xPos of wall
                    int y = Convert.ToInt32(line[1]); // Get yPos of wall
                    int wallWidth = x + Convert.ToInt32(line[2]); // Get total width of the wall
                    int wallHeight = y + Convert.ToInt32(line[3]); // Get total height of the wall

                    for(int i = x; i < wallWidth; i++) // i for each total width of the wall
                    {
                        for (int j = y; j < wallHeight; j++) // j for each total height of the wall
                        {
                            foreach (Node node in NodeList) // gets each node in a nodelist
                            {
                                if (node.Pos == new Position(i, j)) // if the current node position is == to the Vector position of the wall
                                {
                                    node.Blocked = true; // makes node == blocked
                                }
                            }
                        }
                    }
                }
            }
            // Create all node connections to each other
            CreateNodeConnections(NodeList, worldWidth, worldHeight); 
        }
        
        public void CreateNodeConnections(List<Node> list, int worldWidth, int worldHeight)
        {
            foreach (Node node1 in list)
            {
                Node up = null;
                Node right = null;
                Node down = null;
                Node left = null;
                // if node is blocked - therefore unreachable, skip it
                if (node1.Blocked)
                    continue;
                foreach (Node node2 in list)
                {
                    // if node is blocked - skip it
                    if (node2.Blocked)
                        continue;
                    // If node is the same object, skip rest of logic
                    else if (node1.Pos == node2.Pos)
                        continue;
                    // Check if node 1 is above node 2
                    else if (ChildCheck(node1, new Position(node2.Pos.X, node2.Pos.Y + 1)))
                    {
                        up = node2;
                    }
                    // check if node 2 is right of node 1
                    else if(ChildCheck(node1, new Position(node2.Pos.X - 1, node2.Pos.Y)))
                    {
                        right = node2;
                    }
                    // check if node 2 is down of node 1
                    else if(ChildCheck(node1, new Position(node2.Pos.X, node2.Pos.Y - 1)))
                    {
                        down = node2;
                    }
                    // check if node 2 is left of node 1
                    else if(ChildCheck(node1, new Position(node2.Pos.X + 1, node2.Pos.Y)))
                    {
                        left = node2;
                    }    
                }
                node1.AddDirectionNodes(up, right, down, left);
            } 
        }
        */

        public bool ChildCheck(Node node, Position childPos)
        {
            if (node.Pos == childPos)
                return true;
            else
                return false;
            
        }

        public int ManhattanDistance(Position node, Position goalPos)
        {
            return (int)(Math.Abs(node.X - goalPos.X) + Math.Abs(node.Y - goalPos.Y));
        }

        public string[] FormatString(string line)
        {
            string trimLine = line.Trim(new Char[] { '[', ']', '(', ')' });
            return trimLine.Split(',', ')');
        }

        public List<Node> NodeList
        {
            get { return _nodeList; }
        }

        public Agent MovementAgent
        {
            get { return _movementAgent; }
            set { _movementAgent = value; }
        }
        public string Agent
        {
            get { return _agent; }
            set { _agent = value; }
        }
    }
}
