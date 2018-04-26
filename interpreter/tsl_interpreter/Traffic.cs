using System;
using System.Collections.Generic;
using System.Text;
using GoldParser;
using tsl_interpreter;

namespace tsl_interpreter
{
    class Traffic : Vehicle
    {
		public Num Amount { get; set; }
		public Num TopSpeed { get; set; }
		public Num Acceleration { get; set; }
		public TrafficStartEndTerminal TSE { get; set; }

		public Traffic(Parser parser) : base(parser)
	    {
	    }
    }
}
