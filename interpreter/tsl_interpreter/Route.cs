using GoldParser;

namespace tsl_interpreter
{
	internal class Route : NonTerminalNode
	{
		private Parser m_parser;

		public Route(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}