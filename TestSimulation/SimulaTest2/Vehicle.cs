using System.Collections.Generic;
using System.Linq;

namespace SimShitty
{
    class Vehicle
    {
        public double Length { get; set; }
        public double Velocity { get; set; }
        public Connection StartLocation { get; set; }
        public Connection Destination { get; set; }
        public RoadElement CurrentLocation { get; set; }
        // Route to follow (not in use as of now).
        public Stack<Connection> Route { get; set; }

        // Only used in initial random-mode.
        public Connection PrevConnection { get; set; }

        public Vehicle(Connection start)
        {
            StartLocation = start;
            Route = new Stack<Connection>();
        }

        public string UpdateLocation(int random, List<Connection> connections)
        {
            //TODO: Make this method more accurate/realistic (distance travelled on road)
            if (CurrentLocation == null)
            {
                CurrentLocation = StartLocation;
                PrevConnection = StartLocation;
            } else if (CurrentLocation is Connection c)
            {
                PrevConnection = (Connection) CurrentLocation;
                CurrentLocation = c.Roads[random % c.Roads.Count];
            }
            else if (CurrentLocation is Road r)
            {
                CurrentLocation = connections.FindAll(con => con.Roads.Contains(r)).First(con => con != PrevConnection);
            }


            return ToString();
        }

        public override string ToString()
        {
            return "Car is at " + CurrentLocation + " going " + Velocity + " km/h.";
        }

        // TODO: add some acceleration property and -method

    }
}