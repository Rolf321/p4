using GoldParser;

namespace tsl_interpreter
{
	internal class ConnectionIDList : NonTerminalNode
	{
		private Parser m_parser;

		public ConnectionIDList(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}