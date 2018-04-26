using System.Collections.Generic;

namespace SimShitty
{
    class Connection : RoadElement
    {
        // Time interval for light changes.
        public double Interval { get; set; }
        // Roads going to an from an intersection.
        public List<Road> Roads { get; set; }

        public Connection(string name)
        {
            Roads = new List<Road>();
            Name = new string(name.ToCharArray());
        }

        public override string ToString()
        {
            return Name;
        }
    }
}