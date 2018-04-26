using GoldParser;

namespace tsl_interpreter
{
    internal class TestVehicleRoute : TerminalNode
    {
        private Parser m_parser;

        public TestVehicleRoute(Parser m_parser) : base(m_parser)
        {
            this.m_parser = m_parser;
        }
    }
}