using System;
using System.Collections.Generic;
using System.Text;
using GoldParser;

namespace tsl_interpreter
{
	internal class TrafficStartEndTerminal : TerminalNode
	{
		public TrafficStart StartConnection { get; set; }
		public TrafficEnd EndConnection { get; set; }

		public TrafficStartEndTerminal(Parser theParser) : base(theParser)
		{
		}
	}
}
