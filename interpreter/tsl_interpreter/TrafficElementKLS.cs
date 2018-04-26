using System;
using System.Collections.Generic;
using System.Text;
using GoldParser;

namespace tsl_interpreter
{
	internal class TrafficElementKLS : NonTerminalNode
	{
		public TrafficElementKLS TEKLS { get; set; }
		public Traffic Traffic { get; set; }

		public TrafficElementKLS(Parser theParser) : base(theParser)
		{
		}
	}
}
