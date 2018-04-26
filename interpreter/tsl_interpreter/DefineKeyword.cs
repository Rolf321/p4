using System;
using System.Collections.Generic;
using System.Text;
using GoldParser;

namespace tsl_interpreter
{
	internal class DefineKeyword : TerminalNode
	{
		public DefineKeyword(Parser theParser) : base(theParser)
		{
		}
	}
}
