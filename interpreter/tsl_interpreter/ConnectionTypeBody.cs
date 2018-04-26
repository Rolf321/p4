using GoldParser;

namespace tsl_interpreter
{
	internal class ConnectionTypeBody : NonTerminalNode
	{
		private Parser m_parser;

		public ConnectionTypeBody(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}