using GoldParser;
namespace tsl_interpreter
{
    class Road : RoadElement
    {
        // Length of road (in meters).
        public double Length { get; set; }
        // Speed limit for vehicles (in Km pr. hour).
        public double SpeedLimit { get; set; }

        public Road(string name, double length, double speedLimit, Parser parser) : base(parser)
        { 
            Name = new string(name.ToCharArray());
            Length = length;
            SpeedLimit = speedLimit;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}