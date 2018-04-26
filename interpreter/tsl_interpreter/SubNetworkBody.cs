using GoldParser;

namespace tsl_interpreter
{
	internal class SubNetworkBody : NonTerminalNode
	{
		private Parser m_parser;

		public SubNetworkBody(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}