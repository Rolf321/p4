using GoldParser;

namespace tsl_interpreter
{
	internal class RoadLengthKlS : NonTerminalNode
	{
		private Parser m_parser;

		public RoadLengthKlS(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}