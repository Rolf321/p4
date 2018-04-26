
using System;
using System.Reflection;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Collections;

using GoldParser;
using tsl_interpreter;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace tsl_interpreter
{
        
    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                      =  0, // (EOF)
        SYMBOL_ERROR                    =  1, // (Error)
        SYMBOL_WHITESPACE               =  2, // Whitespace
        SYMBOL_LPAREN                   =  3, // '('
        SYMBOL_RPAREN                   =  4, // ')'
        SYMBOL_COMMA                    =  5, // ','
        SYMBOL_SEMI                     =  6, // ';'
        SYMBOL_LBRACKET                 =  7, // '['
        SYMBOL_RBRACKET                 =  8, // ']'
        SYMBOL__                        =  9, // '_'
        SYMBOL_LBRACE                   = 10, // '{'
        SYMBOL_RBRACE                   = 11, // '}'
        SYMBOL_CONNECTIONSYMBOL         = 12, // connectionsymbol
        SYMBOL_CONNECTIONTYPEKEYWORD    = 13, // connectiontypekeyword
        SYMBOL_DEFINEKEYWORD            = 14, // definekeyword
        SYMBOL_DIRECTION                = 15, // direction
        SYMBOL_ID                       = 16, // id
        SYMBOL_LENGTHKEYWORD            = 17, // lengthkeyword
        SYMBOL_NAMEKEYWORD              = 18, // namekeyword
        SYMBOL_NUM                      = 19, // num
        SYMBOL_PATHSKEYWORD             = 20, // pathskeyword
        SYMBOL_RANDOMENDKEYWORD         = 21, // randomendkeyword
        SYMBOL_RANDOMSTARTKEYWORD       = 22, // randomstartkeyword
        SYMBOL_ROADNETWORKKEYWORD       = 23, // roadnetworkkeyword
        SYMBOL_SPEEDKEYWORD             = 24, // speedkeyword
        SYMBOL_SUBNETWORKKEYWORD        = 25, // subnetworkkeyword
        SYMBOL_TESTVEHICLESKEYWORD      = 26, // testvehicleskeyword
        SYMBOL_TRAFFICKEYWORD           = 27, // traffickeyword
        SYMBOL_CONNECTIONIDKLS          = 28, // <ConnectionIDKlS>
        SYMBOL_CONNECTIONIDLIST         = 29, // <ConnectionIDList>
        SYMBOL_CONNECTIONTYPE           = 30, // <ConnectionType>
        SYMBOL_CONNECTIONTYPEBODY       = 31, // <ConnectionTypeBody>
        SYMBOL_CONNECTIONTYPEELEMENT    = 32, // <ConnectionTypeElement>
        SYMBOL_CONNECTIONTYPEELEMENTKLS = 33, // <ConnectionTypeElementKlS>
        SYMBOL_DEFINE                   = 34, // <Define>
        SYMBOL_DEFINEKLS                = 35, // <DefineKlS>
        SYMBOL_PATH                     = 36, // <Path>
        SYMBOL_PATHKLS                  = 37, // <PathKlS>
        SYMBOL_PATHS                    = 38, // <Paths>
        SYMBOL_PATHSBODY                = 39, // <PathsBody>
        SYMBOL_ROADID                   = 40, // <RoadID>
        SYMBOL_ROADIDKLS                = 41, // <RoadIDKlS>
        SYMBOL_ROADLENGTH               = 42, // <RoadLength>
        SYMBOL_ROADLENGTHKLS            = 43, // <RoadLengthKlS>
        SYMBOL_ROADLENGTHS              = 44, // <RoadLengths>
        SYMBOL_ROADLENGTHSLIST          = 45, // <RoadLengthsList>
        SYMBOL_ROADLIST                 = 46, // <RoadList>
        SYMBOL_ROADNAME                 = 47, // <RoadName>
        SYMBOL_ROADNAMEKLS              = 48, // <RoadNameKlS>
        SYMBOL_ROADNAMES                = 49, // <RoadNames>
        SYMBOL_ROADNAMESLIST            = 50, // <RoadNamesList>
        SYMBOL_ROADNETWORK              = 51, // <RoadNetwork>
        SYMBOL_ROADNETWORKBODY          = 52, // <RoadNetworkBody>
        SYMBOL_ROADSPEED                = 53, // <RoadSpeed>
        SYMBOL_ROADSPEEDKLS             = 54, // <RoadSpeedKlS>
        SYMBOL_ROADSPEEDS               = 55, // <RoadSpeeds>
        SYMBOL_ROADSPEEDSLIST           = 56, // <RoadSpeedsList>
        SYMBOL_ROUTE                    = 57, // <Route>
        SYMBOL_ROUTEKLS                 = 58, // <RouteKlS>
        SYMBOL_START                    = 59, // <Start>
        SYMBOL_SUBNETWORK               = 60, // <SubNetwork>
        SYMBOL_SUBNETWORKBODY           = 61, // <SubNetworkBody>
        SYMBOL_SUBNETWORKKLS            = 62, // <SubNetworkKlS>
        SYMBOL_SUBNETWORKROUTE          = 63, // <SubNetworkRoute>
        SYMBOL_SUBNETWORKROUTEKLS       = 64, // <SubNetworkRouteKlS>
        SYMBOL_TESTVEHICLE              = 65, // <TestVehicle>
        SYMBOL_TESTVEHICLEKLS           = 66, // <TestVehicleKlS>
        SYMBOL_TESTVEHICLEROUTE         = 67, // <TestVehicleRoute>
        SYMBOL_TESTVEHICLES             = 68, // <TestVehicles>
        SYMBOL_TESTVEHICLESBODY         = 69, // <TestVehiclesBody>
        SYMBOL_TRAFFIC                  = 70, // <Traffic>
        SYMBOL_TRAFFICBODY              = 71, // <TrafficBody>
        SYMBOL_TRAFFICELEMENT           = 72, // <TrafficElement>
        SYMBOL_TRAFFICELEMENTKLS        = 73, // <TrafficElementKlS>
        SYMBOL_TRAFFICEND               = 74, // <TrafficEnd>
        SYMBOL_TRAFFICSTART             = 75, // <TrafficStart>
        SYMBOL_TRAFFICSTARTEND          = 76  // <TrafficStartEnd>
    };

    enum RuleConstants : int
    {
        RULE_START_DEFINEKEYWORD                                         =  0, // <Start> ::= definekeyword <RoadNetwork> <DefineKlS>
        RULE_ROADNETWORK_ROADNETWORKKEYWORD_ID_LBRACE_RBRACE             =  1, // <RoadNetwork> ::= roadnetworkkeyword id '{' <RoadNetworkBody> '}'
        RULE_ROADNETWORKBODY                                             =  2, // <RoadNetworkBody> ::= <ConnectionType> <SubNetworkKlS> <SubNetwork>
        RULE_CONNECTIONTYPE_CONNECTIONTYPEKEYWORD_LBRACE_RBRACE          =  3, // <ConnectionType> ::= connectiontypekeyword '{' <ConnectionTypeBody> '}'
        RULE_CONNECTIONTYPEBODY_SEMI                                     =  4, // <ConnectionTypeBody> ::= <ConnectionTypeElementKlS> <ConnectionTypeElement> ';'
        RULE_CONNECTIONTYPEELEMENTKLS_COMMA                              =  5, // <ConnectionTypeElementKlS> ::= <ConnectionTypeElementKlS> <ConnectionTypeElement> ','
        RULE_CONNECTIONTYPEELEMENTKLS                                    =  6, // <ConnectionTypeElementKlS> ::= 
        RULE_CONNECTIONTYPEELEMENT_CONNECTIONSYMBOL_LPAREN_RPAREN        =  7, // <ConnectionTypeElement> ::= connectionsymbol '(' <ConnectionIDList> ')'
        RULE_CONNECTIONIDLIST_ID                                         =  8, // <ConnectionIDList> ::= <ConnectionIDKlS> id
        RULE_CONNECTIONIDKLS_ID_COMMA                                    =  9, // <ConnectionIDKlS> ::= <ConnectionIDKlS> id ','
        RULE_CONNECTIONIDKLS                                             = 10, // <ConnectionIDKlS> ::= 
        RULE_SUBNETWORKKLS                                               = 11, // <SubNetworkKlS> ::= <SubNetworkKlS> <SubNetwork>
        RULE_SUBNETWORKKLS2                                              = 12, // <SubNetworkKlS> ::= 
        RULE_SUBNETWORK_DEFINEKEYWORD_SUBNETWORKKEYWORD_ID_LBRACE_RBRACE = 13, // <SubNetwork> ::= definekeyword subnetworkkeyword id '{' <SubNetworkBody> '}'
        RULE_SUBNETWORKBODY                                              = 14, // <SubNetworkBody> ::= <SubNetworkRoute> <RoadNames> <RoadLengths> <RoadSpeeds>
        RULE_SUBNETWORKROUTE_LBRACKET_RBRACKET_SEMI                      = 15, // <SubNetworkRoute> ::= <SubNetworkRouteKlS> '[' <Route> ']' ';'
        RULE_SUBNETWORKROUTEKLS_LBRACKET_RBRACKET_COMMA                  = 16, // <SubNetworkRouteKlS> ::= <SubNetworkRouteKlS> '[' <Route> ']' ','
        RULE_SUBNETWORKROUTEKLS                                          = 17, // <SubNetworkRouteKlS> ::= 
        RULE_ROUTE_ID_DIRECTION_ID                                       = 18, // <Route> ::= id direction id <RouteKlS>
        RULE_ROUTEKLS_DIRECTION_ID                                       = 19, // <RouteKlS> ::= <RouteKlS> direction id
        RULE_ROUTEKLS                                                    = 20, // <RouteKlS> ::= 
        RULE_ROADNAMES_NAMEKEYWORD_LBRACE_RBRACE                         = 21, // <RoadNames> ::= namekeyword '{' <RoadNamesList> '}'
        RULE_ROADNAMESLIST_SEMI                                          = 22, // <RoadNamesList> ::= <RoadNameKlS> <RoadName> ';'
        RULE_ROADNAMEKLS_COMMA                                           = 23, // <RoadNameKlS> ::= <RoadNameKlS> <RoadName> ','
        RULE_ROADNAMEKLS                                                 = 24, // <RoadNameKlS> ::= 
        RULE_ROADNAME_ID_LPAREN_RPAREN                                   = 25, // <RoadName> ::= id '(' <RoadList> ')'
        RULE_ROADLIST                                                    = 26, // <RoadList> ::= <RoadIDKlS> <RoadID>
        RULE_ROADIDKLS_COMMA                                             = 27, // <RoadIDKlS> ::= <RoadIDKlS> <RoadID> ','
        RULE_ROADIDKLS                                                   = 28, // <RoadIDKlS> ::= 
        RULE_ROADID_ID___ID                                              = 29, // <RoadID> ::= id '_' id
        RULE_ROADLENGTHS_LENGTHKEYWORD_LBRACE_RBRACE                     = 30, // <RoadLengths> ::= lengthkeyword '{' <RoadLengthsList> '}'
        RULE_ROADLENGTHSLIST_SEMI                                        = 31, // <RoadLengthsList> ::= <RoadLengthKlS> <RoadLength> ';'
        RULE_ROADLENGTHKLS_COMMA                                         = 32, // <RoadLengthKlS> ::= <RoadLengthKlS> <RoadLength> ','
        RULE_ROADLENGTHKLS                                               = 33, // <RoadLengthKlS> ::= 
        RULE_ROADLENGTH_NUM_LPAREN_RPAREN                                = 34, // <RoadLength> ::= num '(' <RoadList> ')'
        RULE_ROADSPEEDS_SPEEDKEYWORD_LBRACE_RBRACE                       = 35, // <RoadSpeeds> ::= speedkeyword '{' <RoadSpeedsList> '}'
        RULE_ROADSPEEDSLIST_SEMI                                         = 36, // <RoadSpeedsList> ::= <RoadSpeedKlS> <RoadSpeed> ';'
        RULE_ROADSPEEDKLS_COMMA                                          = 37, // <RoadSpeedKlS> ::= <RoadSpeedKlS> <RoadSpeed> ','
        RULE_ROADSPEEDKLS                                                = 38, // <RoadSpeedKlS> ::= 
        RULE_ROADSPEED_NUM_LPAREN_RPAREN                                 = 39, // <RoadSpeed> ::= num '(' <RoadList> ')'
        RULE_DEFINEKLS_DEFINEKEYWORD                                     = 40, // <DefineKlS> ::= <DefineKlS> definekeyword <Define>
        RULE_DEFINEKLS                                                   = 41, // <DefineKlS> ::= 
        RULE_DEFINE                                                      = 42, // <Define> ::= <Paths>
        RULE_DEFINE2                                                     = 43, // <Define> ::= <Traffic>
        RULE_DEFINE3                                                     = 44, // <Define> ::= <TestVehicles>
        RULE_PATHS_PATHSKEYWORD_LBRACE_RBRACE                            = 45, // <Paths> ::= pathskeyword '{' <PathsBody> '}'
        RULE_PATHSBODY_SEMI                                              = 46, // <PathsBody> ::= <PathKlS> <Path> ';'
        RULE_PATHKLS_COMMA                                               = 47, // <PathKlS> ::= <PathKlS> <Path> ','
        RULE_PATHKLS                                                     = 48, // <PathKlS> ::= 
        RULE_PATH_ID_LPAREN_RPAREN                                       = 49, // <Path> ::= id '(' <ConnectionIDList> ')'
        RULE_TRAFFIC_TRAFFICKEYWORD_LBRACE_RBRACE                        = 50, // <Traffic> ::= traffickeyword '{' <TrafficBody> '}'
        RULE_TRAFFICBODY_SEMI                                            = 51, // <TrafficBody> ::= <TrafficElementKlS> <TrafficElement> ';'
        RULE_TRAFFICELEMENTKLS_COMMA                                     = 52, // <TrafficElementKlS> ::= <TrafficElementKlS> <TrafficElement> ','
        RULE_TRAFFICELEMENTKLS                                           = 53, // <TrafficElementKlS> ::= 
        RULE_TRAFFICELEMENT_LPAREN_NUM_COMMA_NUM_COMMA_NUM_COMMA_RPAREN  = 54, // <TrafficElement> ::= '(' num ',' num ',' num ',' <TrafficStartEnd> ')'
        RULE_TRAFFICSTARTEND_ID                                          = 55, // <TrafficStartEnd> ::= id
        RULE_TRAFFICSTARTEND_COMMA                                       = 56, // <TrafficStartEnd> ::= <TrafficStart> ',' <TrafficEnd>
        RULE_TRAFFICSTART_ID                                             = 57, // <TrafficStart> ::= id
        RULE_TRAFFICSTART_RANDOMSTARTKEYWORD                             = 58, // <TrafficStart> ::= randomstartkeyword
        RULE_TRAFFICEND_ID                                               = 59, // <TrafficEnd> ::= id
        RULE_TRAFFICEND_RANDOMENDKEYWORD                                 = 60, // <TrafficEnd> ::= randomendkeyword
        RULE_TESTVEHICLES_TESTVEHICLESKEYWORD_LBRACE_RBRACE              = 61, // <TestVehicles> ::= testvehicleskeyword '{' <TestVehiclesBody> '}'
        RULE_TESTVEHICLESBODY_SEMI                                       = 62, // <TestVehiclesBody> ::= <TestVehicleKlS> <TestVehicle> ';'
        RULE_TESTVEHICLEKLS_COMMA                                        = 63, // <TestVehicleKlS> ::= <TestVehicleKlS> <TestVehicle> ','
        RULE_TESTVEHICLEKLS                                              = 64, // <TestVehicleKlS> ::= 
        RULE_TESTVEHICLE_ID_LPAREN_NUM_COMMA_NUM_COMMA_RPAREN            = 65, // <TestVehicle> ::= id '(' num ',' num ',' <TestVehicleRoute> ')'
        RULE_TESTVEHICLEROUTE_ID                                         = 66, // <TestVehicleRoute> ::= id
        RULE_TESTVEHICLEROUTE_ID_COMMA_ID                                = 67  // <TestVehicleRoute> ::= id ',' id
    };

        // this class will construct a parser without having to process
        //  the CGT tables with each creation.  It must be initialized
        //  before you can call CreateParser()
    public sealed class ParserFactory
    {
        static Grammar m_grammar;
        static bool _init;
        
        private ParserFactory()
        {
        }
        
        private static BinaryReader GetResourceReader(string resourceName)
        {  
            Assembly assembly = Assembly.GetExecutingAssembly();   
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            return new BinaryReader(stream);
        }
        
        public static void InitializeFactoryFromFile(string FullCGTFilePath)
        {
            if (!_init)
            {
               BinaryReader reader = new BinaryReader(new FileStream(FullCGTFilePath,FileMode.Open));
               m_grammar = new Grammar( reader );
               _init = true;
            }
        }
        
        public static void InitializeFactoryFromResource(string resourceName)
        {
            if (!_init)
            {
                BinaryReader reader = GetResourceReader(resourceName);
                m_grammar = new Grammar( reader );
                _init = true;
            }
        }
        
        public static Parser CreateParser(TextReader reader)
        {
           if (_init)
           {
                return new Parser(reader, m_grammar);
           }
           throw new Exception("You must first Initialize the Factory before creating a parser!");
        }
    }
        
    public abstract class ASTNode
    {
		public ASTNode Parent { get; set; }
		public ASTNode LeftmostSibling { get; set; }
		public ASTNode LeftmostChild { get; set; }
		public ASTNode RightSibling { get; set; }
	    private ASTNode _ysibs;
	    private ASTNode _xsibs;
		public List<ASTNode> Children = new List<ASTNode>();

		public abstract bool IsTerminal
        {
            get;
        }

		//se cac afsnit 7.4.3
	    public ASTNode MakeSiblings(ASTNode y)
	    {
		    _xsibs = this;
		    while (_xsibs.RightSibling != null)
		    {
			    _xsibs = _xsibs.RightSibling;
		    }
			_ysibs = y.LeftmostSibling;
			_xsibs.RightSibling = _ysibs;
		    _ysibs.LeftmostSibling = _xsibs.LeftmostSibling;
		    _ysibs.Parent = _xsibs.Parent;
		    while (_ysibs.RightSibling != null)
		    {
			    _ysibs = _ysibs.RightSibling;
			    _ysibs.LeftmostSibling = _xsibs.LeftmostSibling;
			    _ysibs.Parent = _xsibs.Parent;
		    }
		    return _ysibs;
		}
		//se cac afsnit 7.4.3
		public void Adoptchildren(ASTNode y)
		{
		    if (this.LeftmostChild != null)
		    {
			    this.LeftmostChild.MakeSiblings(y);
			}
			else
		    {
				_ysibs = y.LeftmostSibling;
			    this.LeftmostChild = _ysibs;
			    while (_ysibs != null)
			    {
				    _ysibs.Parent = this;
				    _ysibs = _ysibs.RightSibling;
			    }
		    }
	    }
    }
    
    /// <summary>
    /// Derive this class for Terminal AST Nodes
    /// </summary>
    public class TerminalNode : ASTNode
    {
        private Symbol m_symbol;
        private string m_text;
        private int m_lineNumber;
        private int m_linePosition;

        public TerminalNode(Parser theParser)
        {
            m_symbol = theParser.TokenSymbol;
            m_text = theParser.TokenSymbol.ToString();
            m_lineNumber = theParser.LineNumber;
            m_linePosition = theParser.LinePosition;
        }

        public override bool IsTerminal
        {
            get
            {
                return true;
            }
        }
        
        public Symbol Symbol
        {
            get { return m_symbol; }
        }

        public string Text
        {
            get { return m_text; }
        }

        public override string ToString()
        {
            return m_text;
        }

        public int LineNumber 
        {
            get { return m_lineNumber; }
        }

        public int LinePosition
        {
            get { return m_linePosition; }
        }
    }
    
    /// <summary>
    /// Derive this class for NonTerminal AST Nodes
    /// </summary>
    public class NonTerminalNode : ASTNode
    {
        private int m_reductionNumber;
        private Rule m_rule;
        private ArrayList m_array = new ArrayList();

        public NonTerminalNode(Parser theParser)
        {
            m_rule = theParser.ReductionRule;
        }
        
        public override bool IsTerminal
        {
            get
            {
                return false;
            }
        }

        public int ReductionNumber 
        {
            get { return m_reductionNumber; }
            set { m_reductionNumber = value; }
        }

        public int Count 
        {
            get { return m_array.Count; }
        }

        public ASTNode this[int index]
        {
            get { return m_array[index] as ASTNode; }
        }

        public void AppendChildNode(ASTNode node)
        {
            if (node == null)
            {
                return ; 
            }
            m_array.Add(node);
        }

        public Rule Rule
        {
            get { return m_rule; }
        }

    }

    public class MyParser
    {
        MyParserContext m_context;
        ASTNode m_AST;
        string m_errorString;
        Parser m_parser;
		private Stack _stack;


	    public MyParser(Stack stack)
	    {
		    Stack = stack;
	    }
        
        public int LineNumber
        {
            get
            {
                return m_parser.LineNumber;
            }
        }

        public int LinePosition
        {
            get
            {
                return m_parser.LinePosition;
            }
        }

        public string ErrorString
        {
            get
            {
                return m_errorString;
            }
        }

        public string ErrorLine
        {
            get
            {
                return m_parser.LineText;
            }
        }

        public ASTNode SyntaxTree
        {
            get
            {
                return m_AST;
            }
        }

	    public Stack Stack
	    {
		    get
		    {
			    return _stack;
		    }
		    set
		    {
			    _stack = value;
		    }
	    }
        public bool Parse(string source)
        {
            return Parse(new StringReader(source));
        }

        public bool Parse(StringReader sourceReader)
        {
            m_parser = ParserFactory.CreateParser(sourceReader);
            m_parser.TrimReductions = false;
            m_context = new MyParserContext(m_parser);
            
            while (true)
            {
                switch (m_parser.Parse())
                {
                    case ParseMessage.LexicalError:
                        m_errorString = string.Format("Lexical Error. Line {0}. Token {1} was not expected.", m_parser.LineNumber, m_parser.TokenText);
                        return false;

                    case ParseMessage.SyntaxError:
						StringBuilder text = new StringBuilder();
                        foreach (Symbol tokenSymbol in m_parser.GetExpectedTokens())
                        {
                            text.Append(' ');
                            text.Append(tokenSymbol.ToString());
                        }
                        m_errorString = string.Format("Syntax Error. Line {0}. Expecting: {1}.", m_parser.LineNumber, text.ToString());
                        
                        return false;
                    case ParseMessage.Reduction:
                        ASTNode curAstNode = m_context.CreateASTNode();
	                    m_parser.TokenSyntaxNode = curAstNode;
						if(curAstNode != null)
							Stack.Push(curAstNode);
						break;

                    case ParseMessage.Accept:
                        m_AST = m_parser.TokenSyntaxNode as ASTNode;
						CreateTree();
						m_errorString = null;
                        return true;

                    case ParseMessage.InternalError:
                        m_errorString = "Internal Error. Something is horribly wrong.";
                        return false;

                    case ParseMessage.NotLoadedError:
                        m_errorString = "Grammar Table is not loaded.";
                        return false;

                    case ParseMessage.CommentError:
                        m_errorString = "Comment Error. Unexpected end of input.";
                        
                        return false;
					case ParseMessage.CommentBlockRead:
                    case ParseMessage.CommentLineRead:
                        // don't do anything 
                        break;
                }
            }
         }

		private void CreateTree()
		{
			ASTNode prevNonTerminal = _stack.GetTop();
			while (!_stack.IsEmpty())
			{
				ASTNode curAstNode = _stack.GetTop();
				if (curAstNode is TerminalNode)
				{
					//prevNonTerminal.LeftmostChild = curAstNode;
					//prevNonTerminal.Adoptchildren(curAstNode);
					prevNonTerminal.Children.Add(curAstNode);
					curAstNode.Parent = prevNonTerminal;
					_stack.Pop();
				}
				else if (curAstNode is NonTerminalNode)
				{
					_stack.Pop();
					curAstNode = _stack.GetTop();
					if (!_stack.IsEmpty())
					{
						//prevNonTerminal.LeftmostChild = curAstNode;
						//prevNonTerminal.Adoptchildren(curAstNode);
						prevNonTerminal.Children.Add(curAstNode);
						curAstNode.Parent = prevNonTerminal;
					}
					if (_stack.GetTop() is NonTerminalNode)
					{
						prevNonTerminal = _stack.GetTop();
					}
				}
			}
		}
	}

	public class MyParserContext
    {

        // instance fields
        private Parser m_parser;
        
        private TextReader m_inputReader;
        

        
        // constructor
        public MyParserContext(Parser prser)
        {
            m_parser = prser;   
        }
       

        public string GetTokenText()
        {
            // delete any of these that are non-terminals.

            switch (m_parser.TokenSymbol.Index)
            {

                //case (int)SymbolConstants.SYMBOL_EOF :
                ////(EOF)
                ////Token Kind: 3
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ERROR :
                ////(Error)
                ////Token Kind: 7
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_WHITESPACE :
                ////Whitespace
                ////Token Kind: 2
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL__ :
                //'_'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONNECTIONSYMBOL :
                //connectionsymbol
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONNECTIONTYPEKEYWORD :
                //connectiontypekeyword
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DEFINEKEYWORD :
                //definekeyword
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DIRECTION :
                //direction
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //id
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LENGTHKEYWORD :
                //lengthkeyword
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NAMEKEYWORD :
                //namekeyword
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //num
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PATHSKEYWORD :
                //pathskeyword
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RANDOMENDKEYWORD :
                //randomendkeyword
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RANDOMSTARTKEYWORD :
                //randomstartkeyword
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ROADNETWORKKEYWORD :
                //roadnetworkkeyword
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SPEEDKEYWORD :
                //speedkeyword
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SUBNETWORKKEYWORD :
                //subnetworkkeyword
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TESTVEHICLESKEYWORD :
                //testvehicleskeyword
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TRAFFICKEYWORD :
                //traffickeyword
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                return m_parser.TokenString;
                return null;

                //case (int)SymbolConstants.SYMBOL_CONNECTIONIDKLS :
                ////<ConnectionIDKlS>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_CONNECTIONIDLIST :
                ////<ConnectionIDList>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_CONNECTIONTYPE :
                ////<ConnectionType>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_CONNECTIONTYPEBODY :
                ////<ConnectionTypeBody>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_CONNECTIONTYPEELEMENT :
                ////<ConnectionTypeElement>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_CONNECTIONTYPEELEMENTKLS :
                ////<ConnectionTypeElementKlS>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_DEFINE :
                ////<Define>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_DEFINEKLS :
                ////<DefineKlS>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_PATH :
                ////<Path>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_PATHKLS :
                ////<PathKlS>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_PATHS :
                ////<Paths>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_PATHSBODY :
                ////<PathsBody>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADID :
                ////<RoadID>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADIDKLS :
                ////<RoadIDKlS>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADLENGTH :
                ////<RoadLength>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADLENGTHKLS :
                ////<RoadLengthKlS>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADLENGTHS :
                ////<RoadLengths>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADLENGTHSLIST :
                ////<RoadLengthsList>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADLIST :
                ////<RoadList>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADNAME :
                ////<RoadName>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADNAMEKLS :
                ////<RoadNameKlS>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADNAMES :
                ////<RoadNames>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADNAMESLIST :
                ////<RoadNamesList>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADNETWORK :
                ////<RoadNetwork>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADNETWORKBODY :
                ////<RoadNetworkBody>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADSPEED :
                ////<RoadSpeed>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADSPEEDKLS :
                ////<RoadSpeedKlS>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADSPEEDS :
                ////<RoadSpeeds>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROADSPEEDSLIST :
                ////<RoadSpeedsList>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROUTE :
                ////<Route>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_ROUTEKLS :
                ////<RouteKlS>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_START :
                ////<Start>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_SUBNETWORK :
                ////<SubNetwork>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_SUBNETWORKBODY :
                ////<SubNetworkBody>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_SUBNETWORKKLS :
                ////<SubNetworkKlS>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_SUBNETWORKROUTE :
                ////<SubNetworkRoute>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_SUBNETWORKROUTEKLS :
                ////<SubNetworkRouteKlS>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_TESTVEHICLE :
                ////<TestVehicle>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_TESTVEHICLEKLS :
                ////<TestVehicleKlS>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_TESTVEHICLEROUTE :
                ////<TestVehicleRoute>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_TESTVEHICLES :
                ////<TestVehicles>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_TESTVEHICLESBODY :
                ////<TestVehiclesBody>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_TRAFFIC :
                ////<Traffic>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_TRAFFICBODY :
                ////<TrafficBody>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_TRAFFICELEMENT :
                ////<TrafficElement>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_TRAFFICELEMENTKLS :
                ////<TrafficElementKlS>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_TRAFFICEND :
                ////<TrafficEnd>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_TRAFFICSTART :
                ////<TrafficStart>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                //case (int)SymbolConstants.SYMBOL_TRAFFICSTARTEND :
                ////<TrafficStartEnd>
                ////Token Kind: 0
                ////todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                //// return m_parser.TokenString;
                //return null;

                default:
                    throw new SymbolException("You don't want the text of a non-terminal symbol");

            }
            
        }

        public ASTNode CreateASTNode()
        {
            switch (m_parser.ReductionRule.Index)
            {
                case (int)RuleConstants.RULE_START_DEFINEKEYWORD :
					//<Start> ::= definekeyword <RoadNetwork> <DefineKlS>
					//todo: Perhaps create an object in the AST.
					return new Start(m_parser);
                return null;

                case (int)RuleConstants.RULE_ROADNETWORK_ROADNETWORKKEYWORD_ID_LBRACE_RBRACE :
					//<RoadNetwork> ::= roadnetworkkeyword id '{' <RoadNetworkBody> '}'
					//todo: Perhaps create an object in the AST.
					return new RoadNetwork(m_parser);
                return null;

                case (int)RuleConstants.RULE_ROADNETWORKBODY :
					//<RoadNetworkBody> ::= <ConnectionType> <SubNetworkKlS> <SubNetwork>
					//todo: Perhaps create an object in the AST.
					return new RoadNetworkBody(m_parser);
					return null;

                case (int)RuleConstants.RULE_CONNECTIONTYPE_CONNECTIONTYPEKEYWORD_LBRACE_RBRACE :
					//<ConnectionType> ::= connectiontypekeyword '{' <ConnectionTypeBody> '}'
					//todo: Perhaps create an object in the AST.
					return new ConnectionType(m_parser);
					return null;

                case (int)RuleConstants.RULE_CONNECTIONTYPEBODY_SEMI :
					//<ConnectionTypeBody> ::= <ConnectionTypeElementKlS> <ConnectionTypeElement> ';'
					//todo: Perhaps create an object in the AST.
					return new ConnectionTypeBody(m_parser);
					return null;

                case (int)RuleConstants.RULE_CONNECTIONTYPEELEMENTKLS_COMMA :
					//<ConnectionTypeElementKlS> ::= <ConnectionTypeElementKlS> <ConnectionTypeElement> ','
					//todo: Perhaps create an object in the AST.
					return new ConnectionTypeElementKlS(m_parser);
					return null;

                case (int)RuleConstants.RULE_CONNECTIONTYPEELEMENTKLS :
					//<ConnectionTypeElementKlS> ::= 
					//todo: Perhaps create an object in the AST.
					//return new NonTerminalNode(m_parser);
					return null;

                case (int)RuleConstants.RULE_CONNECTIONTYPEELEMENT_CONNECTIONSYMBOL_LPAREN_RPAREN :
					//<ConnectionTypeElement> ::= connectionsymbol '(' <ConnectionIDList> ')'
					//todo: Perhaps create an object in the AST.
					return new ConnectionTypeElement(m_parser);
					return null;

                case (int)RuleConstants.RULE_CONNECTIONIDLIST_ID :
					//<ConnectionIDList> ::= <ConnectionIDKlS> id
					//todo: Perhaps create an object in the AST.
					return new ConnectionIDList(m_parser);
					return null;

                case (int)RuleConstants.RULE_CONNECTIONIDKLS_ID_COMMA :
					//<ConnectionIDKlS> ::= <ConnectionIDKlS> id ','
					//todo: Perhaps create an object in the AST.
					return new ConnectionIDKlS(m_parser);
                return null;

                case (int)RuleConstants.RULE_CONNECTIONIDKLS :
					//<ConnectionIDKlS> ::= 
					//todo: Perhaps create an object in the AST.
					//return new NonTerminalNode(m_parser);
					return null;

                case (int)RuleConstants.RULE_SUBNETWORKKLS :
					//<SubNetworkKlS> ::= <SubNetworkKlS> <SubNetwork>
					//todo: Perhaps create an object in the AST.
					return new SubNetworkKlS(m_parser);
					return null;

                case (int)RuleConstants.RULE_SUBNETWORKKLS2 :
					//<SubNetworkKlS> ::= 
					//todo: Perhaps create an object in the AST.
					//return new NonTerminalNode(m_parser);
					return null;

                case (int)RuleConstants.RULE_SUBNETWORK_DEFINEKEYWORD_SUBNETWORKKEYWORD_ID_LBRACE_RBRACE :
					//<SubNetwork> ::= definekeyword subnetworkkeyword id '{' <SubNetworkBody> '}'
					//todo: Perhaps create an object in the AST.
					return new SubNetwork(m_parser);
					return null;

                case (int)RuleConstants.RULE_SUBNETWORKBODY :
					//<SubNetworkBody> ::= <SubNetworkRoute> <RoadNames> <RoadLengths> <RoadSpeeds>
					//todo: Perhaps create an object in the AST.
					return new SubNetworkBody(m_parser);
					return null;

                case (int)RuleConstants.RULE_SUBNETWORKROUTE_LBRACKET_RBRACKET_SEMI :
					//<SubNetworkRoute> ::= <SubNetworkRouteKlS> '[' <Route> ']' ';'
					//todo: Perhaps create an object in the AST.
					return new SubNetworkRoute(m_parser);
					return null;

                case (int)RuleConstants.RULE_SUBNETWORKROUTEKLS_LBRACKET_RBRACKET_COMMA :
					//<SubNetworkRouteKlS> ::= <SubNetworkRouteKlS> '[' <Route> ']' ','
					//todo: Perhaps create an object in the AST.
					return new SubNetworkRouteKlS(m_parser);
					return null;

                case (int)RuleConstants.RULE_SUBNETWORKROUTEKLS :
					//<SubNetworkRouteKlS> ::= 
					//todo: Perhaps create an object in the AST.
					//return new NonTerminalNode(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROUTE_ID_DIRECTION_ID :
					//<Route> ::= id direction id <RouteKlS>
					//todo: Perhaps create an object in the AST.
					return new Route(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROUTEKLS_DIRECTION_ID :
					//<RouteKlS> ::= <RouteKlS> direction id
					//todo: Perhaps create an object in the AST.
					return new RouteKLS(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROUTEKLS :
					//<RouteKlS> ::= 
					//todo: Perhaps create an object in the AST.
					//return new NonTerminalNode(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADNAMES_NAMEKEYWORD_LBRACE_RBRACE :
					//<RoadNames> ::= namekeyword '{' <RoadNamesList> '}'
					//todo: Perhaps create an object in the AST.
					return new RoadNames(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADNAMESLIST_SEMI :
					//<RoadNamesList> ::= <RoadNameKlS> <RoadName> ';'
					//todo: Perhaps create an object in the AST.
					return new RoadNamesList(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADNAMEKLS_COMMA :
					//<RoadNameKlS> ::= <RoadNameKlS> <RoadName> ','
					//todo: Perhaps create an object in the AST.
					return new RoadNameKlS(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADNAMEKLS :
					//<RoadNameKlS> ::= 
					//todo: Perhaps create an object in the AST.
					//return new NonTerminalNode(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADNAME_ID_LPAREN_RPAREN :
					//<RoadName> ::= id '(' <RoadList> ')'
					//todo: Perhaps create an object in the AST.
					return new RoadName(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADLIST :
					//<RoadList> ::= <RoadIDKlS> <RoadID>
					//todo: Perhaps create an object in the AST.
					return new RoadList(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADIDKLS_COMMA :
					//<RoadIDKlS> ::= <RoadIDKlS> <RoadID> ','
					//todo: Perhaps create an object in the AST.
					return new RoadIDKlS(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADIDKLS :
					//<RoadIDKlS> ::= 
					//todo: Perhaps create an object in the AST.
					//return new NonTerminalNode(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADID_ID___ID :
					//<RoadID> ::= id '_' id
					//todo: Perhaps create an object in the AST.
					return new RoadID(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADLENGTHS_LENGTHKEYWORD_LBRACE_RBRACE :
					//<RoadLengths> ::= lengthkeyword '{' <RoadLengthsList> '}'
					//todo: Perhaps create an object in the AST.
					return new RoadLengths(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADLENGTHSLIST_SEMI :
					//<RoadLengthsList> ::= <RoadLengthKlS> <RoadLength> ';'
					//todo: Perhaps create an object in the AST.
					return new RoadLengthsList(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADLENGTHKLS_COMMA :
					//<RoadLengthKlS> ::= <RoadLengthKlS> <RoadLength> ','
					//todo: Perhaps create an object in the AST.
					return new RoadLengthKlS(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADLENGTHKLS :
					//<RoadLengthKlS> ::= 
					//todo: Perhaps create an object in the AST.
					//return new RoadLengthKlS(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADLENGTH_NUM_LPAREN_RPAREN :
					//<RoadLength> ::= num '(' <RoadList> ')'
					//todo: Perhaps create an object in the AST.
					return new RoadLength(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADSPEEDS_SPEEDKEYWORD_LBRACE_RBRACE :
					//<RoadSpeeds> ::= speedkeyword '{' <RoadSpeedsList> '}'
					//todo: Perhaps create an object in the AST.
					return new RoadSpeeds(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADSPEEDSLIST_SEMI :
					//<RoadSpeedsList> ::= <RoadSpeedKlS> <RoadSpeed> ';'
					//todo: Perhaps create an object in the AST.
					return new RoadSpeedsList(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADSPEEDKLS_COMMA :
					//<RoadSpeedKlS> ::= <RoadSpeedKlS> <RoadSpeed> ','
					//todo: Perhaps create an object in the AST.
					return new RoadSpeedKLS(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADSPEEDKLS :
					//<RoadSpeedKlS> ::= 
					//todo: Perhaps create an object in the AST.
					//return new NonTerminalNode(m_parser);
					return null;

                case (int)RuleConstants.RULE_ROADSPEED_NUM_LPAREN_RPAREN :
					//<RoadSpeed> ::= num '(' <RoadList> ')'
					//todo: Perhaps create an object in the AST.
					return new RoadSpeed(m_parser);
					return null;

                case (int)RuleConstants.RULE_DEFINEKLS_DEFINEKEYWORD :
					//<DefineKlS> ::= <DefineKlS> definekeyword <Define>
					//todo: Perhaps create an object in the AST.
					return new DefineKLS(m_parser);
					return null;

                case (int)RuleConstants.RULE_DEFINEKLS :
					//<DefineKlS> ::= 
					//todo: Perhaps create an object in the AST.
					//return new NonTerminalNode(m_parser);
					return null;

                case (int)RuleConstants.RULE_DEFINE :
					//<Define> ::= <Paths>
					//todo: Perhaps create an object in the AST.
					return new Define(m_parser);
					return null;

                case (int)RuleConstants.RULE_DEFINE2 :
                //<Define> ::= <Traffic>
                //todo: Perhaps create an object in the AST.
				return new Define(m_parser);
                return null;

                case (int)RuleConstants.RULE_DEFINE3 :
                //<Define> ::= <TestVehicles>
                //todo: Perhaps create an object in the AST.
				return new Define(m_parser);
                return null;

                case (int)RuleConstants.RULE_PATHS_PATHSKEYWORD_LBRACE_RBRACE :
					//<Paths> ::= pathskeyword '{' <PathsBody> '}'
					//todo: Perhaps create an object in the AST.
					return new Paths(m_parser);
					return null;

                case (int)RuleConstants.RULE_PATHSBODY_SEMI :
					//<PathsBody> ::= <PathKlS> <Path> ';'
					//todo: Perhaps create an object in the AST.
					return new PathsBody(m_parser);
					return null;

                case (int)RuleConstants.RULE_PATHKLS_COMMA :
					//<PathKlS> ::= <PathKlS> <Path> ','
					//todo: Perhaps create an object in the AST.
					return new PathKlS(m_parser);
					return null;

                case (int)RuleConstants.RULE_PATHKLS :
					//<PathKlS> ::= 
					//todo: Perhaps create an object in the AST.
					//return new NonTerminalNode(m_parser);
					return null;

                case (int)RuleConstants.RULE_PATH_ID_LPAREN_RPAREN :
					//<Path> ::= id '(' <ConnectionIDList> ')'
					//todo: Perhaps create an object in the AST.
					return new PathInterpreter(m_parser);
					return null;

                case (int)RuleConstants.RULE_TRAFFIC_TRAFFICKEYWORD_LBRACE_RBRACE :
					//<Traffic> ::= traffickeyword '{' <TrafficBody> '}'
					//todo: Perhaps create an object in the AST.
					return new Traffic(m_parser);
					return null;

                case (int)RuleConstants.RULE_TRAFFICBODY_SEMI :
					//<TrafficBody> ::= <TrafficElementKlS> <TrafficElement> ';'
					//todo: Perhaps create an object in the AST.
					return new TrafficBody(m_parser);
					return null;

                case (int)RuleConstants.RULE_TRAFFICELEMENTKLS_COMMA :
					//<TrafficElementKlS> ::= <TrafficElementKlS> <TrafficElement> ','
					//todo: Perhaps create an object in the AST.
					return new TrafficElementKLS(m_parser);
					return null;

                case (int)RuleConstants.RULE_TRAFFICELEMENTKLS :
					//<TrafficElementKlS> ::= 
					//todo: Perhaps create an object in the AST.
					//return new TrafficElementKLS(m_parser);
                return null;

                case (int)RuleConstants.RULE_TRAFFICELEMENT_LPAREN_NUM_COMMA_NUM_COMMA_NUM_COMMA_RPAREN :
					//<TrafficElement> ::= '(' num ',' num ',' num ',' <TrafficStartEnd> ')'
					//todo: Perhaps create an object in the AST.
					return new TrafficElement(m_parser);
                return null;

                case (int)RuleConstants.RULE_TRAFFICSTARTEND_ID :
					//<TrafficStartEnd> ::= id
					//todo: Perhaps create an object in the AST.
					return new TrafficStartEndTerminal(m_parser);
                return null;

                case (int)RuleConstants.RULE_TRAFFICSTARTEND_COMMA :
					//<TrafficStartEnd> ::= <TrafficStart> ',' <TrafficEnd>
					//todo: Perhaps create an object in the AST.
					return new TrafficStartEndNonterminal(m_parser);
					return null;

                case (int)RuleConstants.RULE_TRAFFICSTART_ID :
					//<TrafficStart> ::= id
					//todo: Perhaps create an object in the AST.
					return new TrafficStart(m_parser);
                return null;

                case (int)RuleConstants.RULE_TRAFFICSTART_RANDOMSTARTKEYWORD :
					//<TrafficStart> ::= randomstartkeyword
					//todo: Perhaps create an object in the AST.
					return new TrafficStart(m_parser);
					return null;

                case (int)RuleConstants.RULE_TRAFFICEND_ID :
					//<TrafficEnd> ::= id
					//todo: Perhaps create an object in the AST.
					return new TrafficEnd(m_parser);
                return null;

                case (int)RuleConstants.RULE_TRAFFICEND_RANDOMENDKEYWORD :
					//<TrafficEnd> ::= randomendkeyword
					//todo: Perhaps create an object in the AST.
					return new TrafficEnd(m_parser);
					return null;

                case (int)RuleConstants.RULE_TESTVEHICLES_TESTVEHICLESKEYWORD_LBRACE_RBRACE :
					//<TestVehicles> ::= testvehicleskeyword '{' <TestVehiclesBody> '}'
					//todo: Perhaps create an object in the AST.
					return new TestVehicles(m_parser, null);
                return null;

                case (int)RuleConstants.RULE_TESTVEHICLESBODY_SEMI :
					//<TestVehiclesBody> ::= <TestVehicleKlS> <TestVehicle> ';'
					//todo: Perhaps create an object in the AST.
					return new TestVehiclesBody(m_parser);
					return null;

                case (int)RuleConstants.RULE_TESTVEHICLEKLS_COMMA :
					//<TestVehicleKlS> ::= <TestVehicleKlS> <TestVehicle> ','
					//todo: Perhaps create an object in the AST.
					return new TestVehicleKlS(m_parser);
					return null;

                case (int)RuleConstants.RULE_TESTVEHICLEKLS :
					//<TestVehicleKlS> ::= 
					//todo: Perhaps create an object in the AST.
					//return new NonTerminalNode(m_parser);
					return null;

                case (int)RuleConstants.RULE_TESTVEHICLE_ID_LPAREN_NUM_COMMA_NUM_COMMA_RPAREN :
					//<TestVehicle> ::= id '(' num ',' num ',' <TestVehicleRoute> ')'
					return new TestVehicle(m_parser);
					return null;

                case (int)RuleConstants.RULE_TESTVEHICLEROUTE_ID :
					//<TestVehicleRoute> ::= id
					//todo: Perhaps create an object in the AST.
					return new TestVehicleRoute(m_parser);
					return null;

                case (int)RuleConstants.RULE_TESTVEHICLEROUTE_ID_COMMA_ID :
					//<TestVehicleRoute> ::= id ',' id
					//todo: Perhaps create an object in the AST.
					return new TestVehicleRoute(m_parser);
					return null;

                default:
                    throw new RuleException("Unknown rule: Does your CGT Match your Code Revision?");
            }
            
        }

    }
    
}
