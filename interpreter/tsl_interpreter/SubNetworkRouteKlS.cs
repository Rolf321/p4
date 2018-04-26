using GoldParser;

namespace tsl_interpreter
{
	internal class SubNetworkRouteKlS : NonTerminalNode
	{
		private Parser m_parser;

		public SubNetworkRouteKlS(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}