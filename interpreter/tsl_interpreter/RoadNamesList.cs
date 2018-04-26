using GoldParser;

namespace tsl_interpreter
{
	internal class RoadNamesList : NonTerminalNode
	{
		private Parser m_parser;

		public RoadNamesList(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}