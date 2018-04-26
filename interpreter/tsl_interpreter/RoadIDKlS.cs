using GoldParser;

namespace tsl_interpreter
{
	internal class RoadIDKlS : NonTerminalNode
	{
		private Parser m_parser;

		public RoadIDKlS(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}