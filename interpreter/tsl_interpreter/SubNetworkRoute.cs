using GoldParser;

namespace tsl_interpreter
{
	internal class SubNetworkRoute : NonTerminalNode
	{
		private Parser m_parser;

		public SubNetworkRoute(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}