using GoldParser;

namespace tsl_interpreter
{
    internal class PathsBody : NonTerminalNode
    {
        private Parser m_parser;

        public PathsBody(Parser m_parser) : base(m_parser)
        {
            this.m_parser = m_parser;
        }
    }
}