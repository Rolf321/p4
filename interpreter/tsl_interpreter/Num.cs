using System;
using System.Collections.Generic;
using System.Text;
using GoldParser;

namespace tsl_interpreter
{
	internal class Num : TerminalNode
	{
		public int value { get; set; }
		public Num(Parser theParser) : base(theParser)
		{
		}
	}
}
