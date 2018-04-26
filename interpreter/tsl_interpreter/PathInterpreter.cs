using GoldParser;

namespace tsl_interpreter
{
    internal class PathInterpreter : NonTerminalNode
    {
        private Parser m_parser;

        public PathInterpreter(Parser m_parser) : base(m_parser)
        {
            this.m_parser = m_parser;
        }
    }
}