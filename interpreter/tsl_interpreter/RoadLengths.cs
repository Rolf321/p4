using GoldParser;

namespace tsl_interpreter
{
	internal class RoadLengths : NonTerminalNode
	{
		private Parser m_parser;

		public RoadLengths(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}