using GoldParser;

namespace tsl_interpreter
{
    internal class TrafficElement : NonTerminalNode
    {
        private Parser m_parser;

        public TrafficElement(Parser m_parser) : base(m_parser)
        {
            this.m_parser = m_parser;
        }
    }
}