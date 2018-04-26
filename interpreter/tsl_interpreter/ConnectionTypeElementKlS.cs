using GoldParser;

namespace tsl_interpreter
{
	internal class ConnectionTypeElementKlS : NonTerminalNode
	{
		private Parser m_parser;

		public ConnectionTypeElementKlS(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}