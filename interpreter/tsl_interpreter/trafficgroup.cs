using System;
using System.Collections.Generic;
using System.Text;
using GoldParser;

namespace tsl_interpreter
{
    class TrafficGroup : TerminalNode
    {
	    public TrafficGroup(Parser theParser, List<Traffic> traffic) : base(theParser)
	    {
		    Traffic = traffic;
	    }

	    public List<Traffic> Traffic { get; set; }
    }
}
