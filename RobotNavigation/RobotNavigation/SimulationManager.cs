using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class SimulationManager
    {
        private World _world;
        private Agent _worldAgent;

        public SimulationManager(string worldTextFile)
        {
            _world = new World();
            _world.CreateWorldFromFile(worldTextFile);
            _worldAgent = new Agent();
        }

        public void Run()
        {
            BreadthFirstSearch bfs = new BreadthFirstSearch();

            _worldAgent.AgentSearchMethod = bfs;

            Console.WriteLine(_worldAgent.Search(_world).ToString());
        }
    }
}
