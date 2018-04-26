using GoldParser;

namespace tsl_interpreter
{
	internal class RoadName : NonTerminalNode
	{
		private Parser m_parser;

		public RoadName(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}