using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulaTest2
{
    class RoadNetwork
    {
        public List<Road> Roads { get; set; }
        public List<Connection> Connections { get; set; }

        public RoadNetwork()
        {
            Roads = new List<Road>();
            Connections = new List<Connection>();
        }

    }
}
