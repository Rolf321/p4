using GoldParser;

namespace tsl_interpreter
{
	internal class RoadNameKlS : NonTerminalNode
	{
		private Parser m_parser;

		public RoadNameKlS(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}