using System;
using System.Collections.Generic;
using System.Text;
using GoldParser;

namespace tsl_interpreter
{
	internal class Start : NonTerminalNode
	{
		public Start(Parser theParser) : base(theParser)
		{
		}
	}
}
