using GoldParser;

namespace tsl_interpreter
{
    internal class TestVehiclesBody : NonTerminalNode
    {
        private Parser m_parser;

        public TestVehiclesBody(Parser m_parser) : base(m_parser)
        {
            this.m_parser = m_parser;
        }
    }
}