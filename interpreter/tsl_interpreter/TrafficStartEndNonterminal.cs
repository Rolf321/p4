using GoldParser;

namespace tsl_interpreter
{
    internal class TrafficStartEndNonterminal : NonTerminalNode
    {
        private Parser m_parser;

        public TrafficStartEndNonterminal(Parser m_parser) : base(m_parser)
        {
            this.m_parser = m_parser;
        }
    }
}