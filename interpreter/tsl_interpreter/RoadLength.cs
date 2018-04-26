using GoldParser;

namespace tsl_interpreter
{
	internal class RoadLength : NonTerminalNode
	{
		private Parser m_parser;

		public RoadLength(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}