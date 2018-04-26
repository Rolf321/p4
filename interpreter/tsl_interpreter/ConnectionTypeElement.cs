using GoldParser;

namespace tsl_interpreter
{
	internal class ConnectionTypeElement :NonTerminalNode
	{
		private Parser m_parser;

		public ConnectionTypeElement(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}