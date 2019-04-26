using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            // Create world by passing in file through constructor
            World gameWorld = new World(System.IO.File.ReadAllLines(String.Format(@"C:\Assignments\{0}", args[0])), args[1]);            
            // Extract data from the file and create objects from the data
            gameWorld.ExtractFile();
            if (!gameWorld.MovementAgent.Search())
                Console.WriteLine("No Solution Found");
            
        }
    }
}
