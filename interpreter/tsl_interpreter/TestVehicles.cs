using System;
using System.Collections.Generic;
using System.Text;
using GoldParser;

namespace tsl_interpreter
{
    class TestVehicles : NonTerminalNode
    {
	    public TestVehicles(Parser theParser, List<TestVehicle> traffic) : base(theParser)
	    {
		    Traffic = traffic;
	    }

	    public List<TestVehicle> Traffic { get; set; }

		public override string ToString()
		{
			return "testvehiclesgroup";
		}
	}
}
