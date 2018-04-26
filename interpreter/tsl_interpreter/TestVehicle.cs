using System;
using System.Collections.Generic;
using System.Text;
using GoldParser;
using tsl_interpreter;

namespace tsl_interpreter
{
    class TestVehicle : Vehicle
    {
	    public string Name { get; set; }

	    public TestVehicle(Parser parser) : base(parser)
	    {
	    }
    }
}
