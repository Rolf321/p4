using GoldParser;

namespace tsl_interpreter
{
	internal class ConnectionIDKlS : NonTerminalNode
	{
		private Parser m_parser;

		public ConnectionIDKlS(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}