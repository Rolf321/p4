using System;
using System.Collections.Generic;
using System.Text;
using GoldParser;

namespace tsl_interpreter
{
	internal class TrafficStart : TerminalNode
	{
		public Identifier Id { get; set; }

		public TrafficStart(Parser theParser) : base(theParser)
		{
			Id = new Identifier(theParser);
		}
	}
}
