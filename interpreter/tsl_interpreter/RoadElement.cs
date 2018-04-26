using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldParser;

namespace tsl_interpreter
{
	public abstract class RoadElement : NonTerminalNode
    {
		public RoadElement(Parser parser) : base(parser)
		{
		}
		public string Name { get; set; }
    }
}
