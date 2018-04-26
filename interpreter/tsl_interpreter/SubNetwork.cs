using GoldParser;

namespace tsl_interpreter
{
	internal class SubNetwork : NonTerminalNode
	{
		private Parser m_parser;

		public SubNetwork(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}