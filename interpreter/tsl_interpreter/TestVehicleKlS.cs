using GoldParser;

namespace tsl_interpreter
{
    internal class TestVehicleKlS : NonTerminalNode
    {
        private Parser m_parser;

        public TestVehicleKlS(Parser m_parser) : base(m_parser)
        {
            this.m_parser = m_parser;
        }
    }
}