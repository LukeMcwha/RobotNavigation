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
            // Create simulation manager passing in textfile in arguments 
            // TODO: (may change to be commandline command through sim manager)
            SimulationManager manager = new SimulationManager(args[0]);

            // Runs simulations
            manager.Run();
        }
    }
}
