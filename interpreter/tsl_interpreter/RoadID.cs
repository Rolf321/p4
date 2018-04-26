using GoldParser;

namespace tsl_interpreter
{
	internal class RoadID : TerminalNode
	{
		private Parser m_parser;

		public RoadID(Parser m_parser) : base(m_parser)
		{
			this.m_parser = m_parser;
		}
	}
}