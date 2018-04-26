using GoldParser;

namespace tsl_interpreter
{
	internal class ConnectionType : NonTerminalNode
	{
		private Parser m_parser;

		public ConnectionType(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}