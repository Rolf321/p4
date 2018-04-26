using GoldParser;

namespace tsl_interpreter
{
	internal class RoadList : NonTerminalNode
	{
		private Parser m_parser;

		public RoadList(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}