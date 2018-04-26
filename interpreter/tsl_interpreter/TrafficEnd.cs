using System;
using System.Collections.Generic;
using System.Text;
using GoldParser;

namespace tsl_interpreter
{
	internal class TrafficEnd : TerminalNode
	{
		public Identifier Id { get; set; }

		public TrafficEnd(Parser theParser) : base(theParser)
		{
		}
	}
}
