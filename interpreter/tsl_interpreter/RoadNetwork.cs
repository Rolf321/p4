using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldParser;
namespace tsl_interpreter
{
    class RoadNetwork : NonTerminalNode
    {
        public List<Road> Roads { get; set; }
        public List<Connection> Connections { get; set; }

        public RoadNetwork(Parser parser) : base(parser)
        {
            Roads = new List<Road>();
            Connections = new List<Connection>();
        }

    }
}
