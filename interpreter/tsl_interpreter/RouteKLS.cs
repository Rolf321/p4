using GoldParser;

namespace tsl_interpreter
{
	internal class RouteKLS : NonTerminalNode
	{
		private Parser m_parser;

		public RouteKLS(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}