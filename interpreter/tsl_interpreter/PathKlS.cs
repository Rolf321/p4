using GoldParser;

namespace tsl_interpreter
{
    internal class PathKlS : NonTerminalNode
    {
        private Parser m_parser;

        public PathKlS(Parser m_parser) : base(m_parser)
        {
            this.m_parser = m_parser;
        }
    }
}