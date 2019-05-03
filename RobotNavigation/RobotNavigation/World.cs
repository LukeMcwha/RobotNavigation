using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RobotNavigation
{
    public class World
    {
        private List<Node> _world = new List<Node>();
        private StartNode _start;
        private GoalNode _goal;

        public World()
        {
            _start = null;
            _goal = null;
        }
        

        public void CreateWorldFromFile(string textfileName)
        {
            try
            {
                // formats string to look in "maps" folder
                string file = String.Format("..\\..\\maps\\{0}", textfileName);

                // If the file doesnt exist
                if (!File.Exists(file))
                {
                    // throw exception
                    throw new FileNotFoundException();
                }
                
                // Create an instance of StreamREader to read from a file
                // the using statement also closes the StreamReader
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    int x = 0;
                    int y = 0;
                    Position pos = null;
                    // Read and display lines from the file until the end of the file is met.
                    while ((line = sr.ReadLine()) != null)
                    {
                        List<string> mapLine = new List<string>(line.Split(' '));
                        
                        foreach (string s in mapLine)
                        {
                            pos = new Position(x, y);
                            _world.Add(NodeFactory(pos, s));
                            x++;
                        }
                        x = 0;
                        y++;
                    }
                }

                // Give Nodes Children
                foreach (Node n in WorldNodes)
                {
                    n.SetChildren(this);
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public Node FindNode(Position pos)
        {
            foreach (Node n in WorldNodes)
            {
                if (n.Pos.Equals(pos))
                    return n;
            }
            // else give them a wall indicating edge of map
            return new WallNode();
        }


        private Node NodeFactory(Position pos, string s)
        {
            s = s.ToUpper();
            switch (s)
            {
                case ".":
                    return new NeutralNode(pos, s);
                case "X":
                    return new WallNode(pos, s);
                case "G":
                    _goal = new GoalNode(pos, s);
                    return _goal;
                case "S":
                    _start = new StartNode(pos, "A");
                    return _start;
                default:
                    throw new ArgumentException();
            }
        }

        // Path will come from Agent.SearchMethod.CompleteSearchPath
        public void PrintPath(Path p)
        {
            foreach(Node n in p.NodePath)
            {
                if (!(n is GoalNode))
                    n.Symbol = "A";
            }

            Console.WriteLine(ToString());
            // get each node within the path, find the corresponding node 
            // Change the symbol of that node to either "A" or directional symbol
            // Call this.tostring() to print out the path.
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int y = 0;
            foreach(Node n in WorldNodes)
            {
                if (n.Pos.Y > y)
                {
                    sb.Append(Environment.NewLine);
                    y = n.Pos.Y;
                }
                sb.Append(n.ToString() + " ");
            }

            return sb.ToString();
        }


        private int ManhattanDistance(Position node, Position goalPos)
        {
            return (int)(Math.Abs(node.X - goalPos.X) + Math.Abs(node.Y - goalPos.Y));
        }

        public StartNode Start
        {
            get { return _start; }
        }
        public GoalNode Goal
        {
            get { return _goal; }
        }
        public List<Node> WorldNodes
        {
            get { return _world; }
        }
    }
}
