using GoldParser;

namespace tsl_interpreter
{
	internal class RoadLengthsList : NonTerminalNode
	{
		private Parser m_parser;

		public RoadLengthsList(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}