using System.Collections.Generic;
using System.Linq;
using GoldParser;
using tsl_interpreter;

namespace tsl_interpreter
{
    class Vehicle : NonTerminalNode
    {
        public double Length { get; set; }
        public double Velocity { get; set; }
        public Connection StartLocation { get; set; }
        public Connection Destination { get; set; }
        public RoadElement CurrentLocation { get; set; }
        // Route to follow (not in use as of now).
        public List<Connection> Route { get; set; }

        // Only used in initial random-mode.
        public Connection PrevConnection { get; set; }

        public Vehicle(Parser parser) : base(parser)
        {
            //StartLocation = start;
            Route = new List<Connection>();
        }

        public string UpdateLocation(int r, List<Connection> connections)
        {
            if (CurrentLocation == null)
            {
                CurrentLocation = StartLocation;
                PrevConnection = StartLocation;
            } else if (CurrentLocation is Connection)
            {
                var C = (Connection)CurrentLocation;
                PrevConnection = CurrentLocation as Connection;
                CurrentLocation = C.Roads[r % C.Roads.Count];
            } else if (CurrentLocation is Road)
            {
                var R = (Road) CurrentLocation;
                CurrentLocation = connections.FindAll(c => c.Roads.Contains(R)).First(c => c != PrevConnection);
            }
            

            return ToString();
        }

        public override string ToString()
        {
            return "Car is at " + CurrentLocation + " going " + Velocity + " km/h.";
        }
    }
}