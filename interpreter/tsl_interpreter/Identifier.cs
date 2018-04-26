using System;
using System.Collections.Generic;
using System.Text;
using GoldParser;

namespace tsl_interpreter
{
	internal class Identifier : TerminalNode
	{
		public string name { get; set; }
		public Identifier(Parser theParser) : base(theParser)
		{
			name = theParser.TokenString.ToString();
		}
	}
}
