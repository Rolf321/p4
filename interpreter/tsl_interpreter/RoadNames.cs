using GoldParser;

namespace tsl_interpreter
{
	internal class RoadNames : NonTerminalNode
	{
		private Parser m_parser;

		public RoadNames(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}