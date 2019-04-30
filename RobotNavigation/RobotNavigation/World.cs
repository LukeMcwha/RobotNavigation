using System;
using System.Collections.Generic;
using System.IO;

namespace RobotNavigation
{
    public class World
    {
        private List<Node> _world = new List<Node>();


        public World()
        { }
        

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
                    // Read and display lines from the file until the end of the file is met.
                    while ((line = sr.ReadLine()) != null)
                    {
                        List<string> mapLine = new List<string>(line.Split(' '));
                        
                        foreach (string s in mapLine)
                        {
                            _world.Add(NodeFactory(new Position(x, y), s));
                            x++;
                        }
                        x = 0;
                        y++;
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


        private Node NodeFactory(Position pos, string s)
        {
            s = s.ToUpper();
            switch (s)
            {
                case ".":
                    return new NeutralNode(pos);
                case "X":
                    return new WallNode(pos);
                case "G":
                    return new GoalNode(pos);
                case "S":
                    return new StartNode(pos);
                default:
                    throw new ArgumentException();
            }
        }

        private int ManhattanDistance(Position node, Position goalPos)
        {
            return (int)(Math.Abs(node.X - goalPos.X) + Math.Abs(node.Y - goalPos.Y));
        }


        public List<Node> GetWorldNodes
        {
            get { return _world; }
        }
    }
}
