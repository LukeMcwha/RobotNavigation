using System;
using System.IO;
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
            if (File.Exists(String.Format("maps\\{0}", args[0])))
            {
               // World gameWorld = new World(args[0]);   // passes file name and constructor will initalise the world
               // if (!gameWorld.MovementAgent.Search())
               //     Console.WriteLine("No Solution Found");
            }
            else
            {
                Console.WriteLine("Invalid filepath to map");
            } 
        }
    }
}
