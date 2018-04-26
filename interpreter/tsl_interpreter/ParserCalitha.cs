
//using System;
//using System.IO;
//using System.Runtime.Serialization;
//using com.calitha.goldparser.lalr;
//using com.calitha.commons;

//namespace com.calitha.goldparser
//{

//	[Serializable()]
//	public class SymbolException : System.Exception
//	{
//		public SymbolException(string message) : base(message)
//		{
//		}

//		public SymbolException(string message,
//			Exception inner) : base(message, inner)
//		{
//		}

//		protected SymbolException(SerializationInfo info,
//			StreamingContext context) : base(info, context)
//		{
//		}

//	}

//	[Serializable()]
//	public class RuleException : System.Exception
//	{

//		public RuleException(string message) : base(message)
//		{
//		}

//		public RuleException(string message,
//							 Exception inner) : base(message, inner)
//		{
//		}

//		protected RuleException(SerializationInfo info,
//								StreamingContext context) : base(info, context)
//		{
//		}

//	}

//	enum SymbolConstants : int
//	{
//		SYMBOL_EOF = 0, // (EOF)
//		SYMBOL_ERROR = 1, // (Error)
//		SYMBOL_WHITESPACE = 2, // Whitespace
//		SYMBOL_LPAREN = 3, // '('
//		SYMBOL_RPAREN = 4, // ')'
//		SYMBOL_COMMA = 5, // ','
//		SYMBOL_SEMI = 6, // ';'
//		SYMBOL_LBRACKET = 7, // '['
//		SYMBOL_RBRACKET = 8, // ']'
//		SYMBOL__ = 9, // '_'
//		SYMBOL_LBRACE = 10, // '{'
//		SYMBOL_RBRACE = 11, // '}'
//		SYMBOL_CONNECTIONSYMBOL = 12, // connectionsymbol
//		SYMBOL_CONNECTIONTYPEKEYWORD = 13, // connectiontypekeyword
//		SYMBOL_DEFINEKEYWORD = 14, // definekeyword
//		SYMBOL_DIRECTION = 15, // direction
//		SYMBOL_ID = 16, // id
//		SYMBOL_LENGTHKEYWORD = 17, // lengthkeyword
//		SYMBOL_NAMEKEYWORD = 18, // namekeyword
//		SYMBOL_NUM = 19, // num
//		SYMBOL_PATHSKEYWORD = 20, // pathskeyword
//		SYMBOL_RANDOMENDKEYWORD = 21, // randomendkeyword
//		SYMBOL_RANDOMSTARTKEYWORD = 22, // randomstartkeyword
//		SYMBOL_ROADNETWORKKEYWORD = 23, // roadnetworkkeyword
//		SYMBOL_SPEEDKEYWORD = 24, // speedkeyword
//		SYMBOL_SUBNETWORKKEYWORD = 25, // subnetworkkeyword
//		SYMBOL_TESTVEHICLESKEYWORD = 26, // testvehicleskeyword
//		SYMBOL_TRAFFICKEYWORD = 27, // traffickeyword
//		SYMBOL_CONNECTIONIDKLS = 28, // <ConnectionIDKlS>
//		SYMBOL_CONNECTIONIDLIST = 29, // <ConnectionIDList>
//		SYMBOL_CONNECTIONTYPE = 30, // <ConnectionType>
//		SYMBOL_CONNECTIONTYPEBODY = 31, // <ConnectionTypeBody>
//		SYMBOL_CONNECTIONTYPEELEMENT = 32, // <ConnectionTypeElement>
//		SYMBOL_CONNECTIONTYPEELEMENTKLS = 33, // <ConnectionTypeElementKlS>
//		SYMBOL_DEFINE = 34, // <Define>
//		SYMBOL_DEFINEKLS = 35, // <DefineKlS>
//		SYMBOL_PATH = 36, // <Path>
//		SYMBOL_PATHKLS = 37, // <PathKlS>
//		SYMBOL_PATHS = 38, // <Paths>
//		SYMBOL_PATHSBODY = 39, // <PathsBody>
//		SYMBOL_ROADID = 40, // <RoadID>
//		SYMBOL_ROADIDKLS = 41, // <RoadIDKlS>
//		SYMBOL_ROADLENGTH = 42, // <RoadLength>
//		SYMBOL_ROADLENGTHKLS = 43, // <RoadLengthKlS>
//		SYMBOL_ROADLENGTHS = 44, // <RoadLengths>
//		SYMBOL_ROADLENGTHSLIST = 45, // <RoadLengthsList>
//		SYMBOL_ROADLIST = 46, // <RoadList>
//		SYMBOL_ROADNAME = 47, // <RoadName>
//		SYMBOL_ROADNAMEKLS = 48, // <RoadNameKlS>
//		SYMBOL_ROADNAMES = 49, // <RoadNames>
//		SYMBOL_ROADNAMESLIST = 50, // <RoadNamesList>
//		SYMBOL_ROADNETWORK = 51, // <RoadNetwork>
//		SYMBOL_ROADNETWORKBODY = 52, // <RoadNetworkBody>
//		SYMBOL_ROADSPEED = 53, // <RoadSpeed>
//		SYMBOL_ROADSPEEDKLS = 54, // <RoadSpeedKlS>
//		SYMBOL_ROADSPEEDS = 55, // <RoadSpeeds>
//		SYMBOL_ROADSPEEDSLIST = 56, // <RoadSpeedsList>
//		SYMBOL_ROUTE = 57, // <Route>
//		SYMBOL_ROUTEKLS = 58, // <RouteKlS>
//		SYMBOL_START = 59, // <Start>
//		SYMBOL_SUBNETWORK = 60, // <SubNetwork>
//		SYMBOL_SUBNETWORKBODY = 61, // <SubNetworkBody>
//		SYMBOL_SUBNETWORKKLS = 62, // <SubNetworkKlS>
//		SYMBOL_SUBNETWORKROUTE = 63, // <SubNetworkRoute>
//		SYMBOL_SUBNETWORKROUTEKLS = 64, // <SubNetworkRouteKlS>
//		SYMBOL_TESTVEHICLE = 65, // <TestVehicle>
//		SYMBOL_TESTVEHICLEKLS = 66, // <TestVehicleKlS>
//		SYMBOL_TESTVEHICLEROUTE = 67, // <TestVehicleRoute>
//		SYMBOL_TESTVEHICLES = 68, // <TestVehicles>
//		SYMBOL_TESTVEHICLESBODY = 69, // <TestVehiclesBody>
//		SYMBOL_TRAFFIC = 70, // <Traffic>
//		SYMBOL_TRAFFICBODY = 71, // <TrafficBody>
//		SYMBOL_TRAFFICELEMENT = 72, // <TrafficElement>
//		SYMBOL_TRAFFICELEMENTKLS = 73, // <TrafficElementKlS>
//		SYMBOL_TRAFFICEND = 74, // <TrafficEnd>
//		SYMBOL_TRAFFICSTART = 75, // <TrafficStart>
//		SYMBOL_TRAFFICSTARTEND = 76  // <TrafficStartEnd>
//	};

//	enum RuleConstants : int
//	{
//		RULE_START_DEFINEKEYWORD = 0, // <Start> ::= definekeyword <RoadNetwork> <DefineKlS>
//		RULE_ROADNETWORK_ROADNETWORKKEYWORD_ID_LBRACE_RBRACE = 1, // <RoadNetwork> ::= roadnetworkkeyword id '{' <RoadNetworkBody> '}'
//		RULE_ROADNETWORKBODY = 2, // <RoadNetworkBody> ::= <ConnectionType> <SubNetworkKlS> <SubNetwork>
//		RULE_CONNECTIONTYPE_CONNECTIONTYPEKEYWORD_LBRACE_RBRACE = 3, // <ConnectionType> ::= connectiontypekeyword '{' <ConnectionTypeBody> '}'
//		RULE_CONNECTIONTYPEBODY_SEMI = 4, // <ConnectionTypeBody> ::= <ConnectionTypeElementKlS> <ConnectionTypeElement> ';'
//		RULE_CONNECTIONTYPEELEMENTKLS_COMMA = 5, // <ConnectionTypeElementKlS> ::= <ConnectionTypeElementKlS> <ConnectionTypeElement> ','
//		RULE_CONNECTIONTYPEELEMENTKLS = 6, // <ConnectionTypeElementKlS> ::= 
//		RULE_CONNECTIONTYPEELEMENT_CONNECTIONSYMBOL_LPAREN_RPAREN = 7, // <ConnectionTypeElement> ::= connectionsymbol '(' <ConnectionIDList> ')'
//		RULE_CONNECTIONIDLIST_ID = 8, // <ConnectionIDList> ::= <ConnectionIDKlS> id
//		RULE_CONNECTIONIDKLS_ID_COMMA = 9, // <ConnectionIDKlS> ::= <ConnectionIDKlS> id ','
//		RULE_CONNECTIONIDKLS = 10, // <ConnectionIDKlS> ::= 
//		RULE_SUBNETWORKKLS = 11, // <SubNetworkKlS> ::= <SubNetworkKlS> <SubNetwork>
//		RULE_SUBNETWORKKLS2 = 12, // <SubNetworkKlS> ::= 
//		RULE_SUBNETWORK_DEFINEKEYWORD_SUBNETWORKKEYWORD_ID_LBRACE_RBRACE = 13, // <SubNetwork> ::= definekeyword subnetworkkeyword id '{' <SubNetworkBody> '}'
//		RULE_SUBNETWORKBODY = 14, // <SubNetworkBody> ::= <SubNetworkRoute> <RoadNames> <RoadLengths> <RoadSpeeds>
//		RULE_SUBNETWORKROUTE_LBRACKET_RBRACKET_SEMI = 15, // <SubNetworkRoute> ::= <SubNetworkRouteKlS> '[' <Route> ']' ';'
//		RULE_SUBNETWORKROUTEKLS_LBRACKET_RBRACKET_COMMA = 16, // <SubNetworkRouteKlS> ::= <SubNetworkRouteKlS> '[' <Route> ']' ','
//		RULE_SUBNETWORKROUTEKLS = 17, // <SubNetworkRouteKlS> ::= 
//		RULE_ROUTE_ID_DIRECTION_ID = 18, // <Route> ::= id direction id <RouteKlS>
//		RULE_ROUTEKLS_DIRECTION_ID = 19, // <RouteKlS> ::= <RouteKlS> direction id
//		RULE_ROUTEKLS = 20, // <RouteKlS> ::= 
//		RULE_ROADNAMES_NAMEKEYWORD_LBRACE_RBRACE = 21, // <RoadNames> ::= namekeyword '{' <RoadNamesList> '}'
//		RULE_ROADNAMESLIST_SEMI = 22, // <RoadNamesList> ::= <RoadNameKlS> <RoadName> ';'
//		RULE_ROADNAMEKLS_COMMA = 23, // <RoadNameKlS> ::= <RoadNameKlS> <RoadName> ','
//		RULE_ROADNAMEKLS = 24, // <RoadNameKlS> ::= 
//		RULE_ROADNAME_ID_LPAREN_RPAREN = 25, // <RoadName> ::= id '(' <RoadList> ')'
//		RULE_ROADLIST = 26, // <RoadList> ::= <RoadIDKlS> <RoadID>
//		RULE_ROADIDKLS_COMMA = 27, // <RoadIDKlS> ::= <RoadIDKlS> <RoadID> ','
//		RULE_ROADIDKLS = 28, // <RoadIDKlS> ::= 
//		RULE_ROADID_ID___ID = 29, // <RoadID> ::= id '_' id
//		RULE_ROADLENGTHS_LENGTHKEYWORD_LBRACE_RBRACE = 30, // <RoadLengths> ::= lengthkeyword '{' <RoadLengthsList> '}'
//		RULE_ROADLENGTHSLIST_SEMI = 31, // <RoadLengthsList> ::= <RoadLengthKlS> <RoadLength> ';'
//		RULE_ROADLENGTHKLS_COMMA = 32, // <RoadLengthKlS> ::= <RoadLengthKlS> <RoadLength> ','
//		RULE_ROADLENGTHKLS = 33, // <RoadLengthKlS> ::= 
//		RULE_ROADLENGTH_NUM_LPAREN_RPAREN = 34, // <RoadLength> ::= num '(' <RoadList> ')'
//		RULE_ROADSPEEDS_SPEEDKEYWORD_LBRACE_RBRACE = 35, // <RoadSpeeds> ::= speedkeyword '{' <RoadSpeedsList> '}'
//		RULE_ROADSPEEDSLIST_SEMI = 36, // <RoadSpeedsList> ::= <RoadSpeedKlS> <RoadSpeed> ';'
//		RULE_ROADSPEEDKLS_COMMA = 37, // <RoadSpeedKlS> ::= <RoadSpeedKlS> <RoadSpeed> ','
//		RULE_ROADSPEEDKLS = 38, // <RoadSpeedKlS> ::= 
//		RULE_ROADSPEED_NUM_LPAREN_RPAREN = 39, // <RoadSpeed> ::= num '(' <RoadList> ')'
//		RULE_DEFINEKLS_DEFINEKEYWORD = 40, // <DefineKlS> ::= <DefineKlS> definekeyword <Define>
//		RULE_DEFINEKLS = 41, // <DefineKlS> ::= 
//		RULE_DEFINE = 42, // <Define> ::= <Paths>
//		RULE_DEFINE2 = 43, // <Define> ::= <Traffic>
//		RULE_DEFINE3 = 44, // <Define> ::= <TestVehicles>
//		RULE_PATHS_PATHSKEYWORD_LBRACE_RBRACE = 45, // <Paths> ::= pathskeyword '{' <PathsBody> '}'
//		RULE_PATHSBODY_SEMI = 46, // <PathsBody> ::= <PathKlS> <Path> ';'
//		RULE_PATHKLS_COMMA = 47, // <PathKlS> ::= <PathKlS> <Path> ','
//		RULE_PATHKLS = 48, // <PathKlS> ::= 
//		RULE_PATH_ID_LPAREN_RPAREN = 49, // <Path> ::= id '(' <ConnectionIDList> ')'
//		RULE_TRAFFIC_TRAFFICKEYWORD_LBRACE_RBRACE = 50, // <Traffic> ::= traffickeyword '{' <TrafficBody> '}'
//		RULE_TRAFFICBODY_SEMI = 51, // <TrafficBody> ::= <TrafficElementKlS> <TrafficElement> ';'
//		RULE_TRAFFICELEMENTKLS_COMMA = 52, // <TrafficElementKlS> ::= <TrafficElementKlS> <TrafficElement> ','
//		RULE_TRAFFICELEMENTKLS = 53, // <TrafficElementKlS> ::= 
//		RULE_TRAFFICELEMENT_LPAREN_NUM_COMMA_NUM_COMMA_NUM_COMMA_RPAREN = 54, // <TrafficElement> ::= '(' num ',' num ',' num ',' <TrafficStartEnd> ')'
//		RULE_TRAFFICSTARTEND_ID = 55, // <TrafficStartEnd> ::= id
//		RULE_TRAFFICSTARTEND_COMMA = 56, // <TrafficStartEnd> ::= <TrafficStart> ',' <TrafficEnd>
//		RULE_TRAFFICSTART_ID = 57, // <TrafficStart> ::= id
//		RULE_TRAFFICSTART_RANDOMSTARTKEYWORD = 58, // <TrafficStart> ::= randomstartkeyword
//		RULE_TRAFFICEND_ID = 59, // <TrafficEnd> ::= id
//		RULE_TRAFFICEND_RANDOMENDKEYWORD = 60, // <TrafficEnd> ::= randomendkeyword
//		RULE_TESTVEHICLES_TESTVEHICLESKEYWORD_LBRACE_RBRACE = 61, // <TestVehicles> ::= testvehicleskeyword '{' <TestVehiclesBody> '}'
//		RULE_TESTVEHICLESBODY_SEMI = 62, // <TestVehiclesBody> ::= <TestVehicleKlS> <TestVehicle> ';'
//		RULE_TESTVEHICLEKLS_COMMA = 63, // <TestVehicleKlS> ::= <TestVehicleKlS> <TestVehicle> ','
//		RULE_TESTVEHICLEKLS = 64, // <TestVehicleKlS> ::= 
//		RULE_TESTVEHICLE_ID_LPAREN_NUM_COMMA_NUM_COMMA_RPAREN = 65, // <TestVehicle> ::= id '(' num ',' num ',' <TestVehicleRoute> ')'
//		RULE_TESTVEHICLEROUTE_ID = 66, // <TestVehicleRoute> ::= id
//		RULE_TESTVEHICLEROUTE_ID_COMMA_ID = 67  // <TestVehicleRoute> ::= id ',' id
//	};

//	public class MyParser
//	{
//		private LALRParser parser;

//		public MyParser(string filename)
//		{
//			FileStream stream = new FileStream(filename,
//											   FileMode.Open,
//											   FileAccess.Read,
//											   FileShare.Read);
//			Init(stream);
//			stream.Close();
//		}

//		public MyParser(string baseName, string resourceName)
//		{
//			byte[] buffer = ResourceUtil.GetByteArrayResource(
//				System.Reflection.Assembly.GetExecutingAssembly(),
//				baseName,
//				resourceName);
//			MemoryStream stream = new MemoryStream(buffer);
//			Init(stream);
//			stream.Close();
//		}

//		public MyParser(Stream stream)
//		{
//			Init(stream);
//		}

//		private void Init(Stream stream)
//		{
//			CGTReader reader = new CGTReader(stream);
//			parser = reader.CreateNewParser();
//			parser.TrimReductions = false;
//			parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

//			parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
//			parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
//		}

//		public void Parse(string source)
//		{
//			NonterminalToken token = parser.Parse(source);
//			if (token != null)
//			{
//				Object obj = CreateObject(token);
//				//todo: Use your object any way you like
//			}
//		}

//		private Object CreateObject(Token token)
//		{
//			if (token is TerminalToken)
//				return CreateObjectFromTerminal((TerminalToken)token);
//			else
//				return CreateObjectFromNonterminal((NonterminalToken)token);
//		}

//		private Object CreateObjectFromTerminal(TerminalToken token)
//		{
//			switch (token.Symbol.Id)
//			{
//				case (int)SymbolConstants.SYMBOL_EOF:
//					//(EOF)
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ERROR:
//					//(Error)
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_WHITESPACE:
//					//Whitespace
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_LPAREN:
//					//'('
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_RPAREN:
//					//')'
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_COMMA:
//					//','
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_SEMI:
//					//';'
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_LBRACKET:
//					//'['
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_RBRACKET:
//					//']'
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL__:
//					//'_'
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_LBRACE:
//					//'{'
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_RBRACE:
//					//'}'
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_CONNECTIONSYMBOL:
//					//connectionsymbol
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_CONNECTIONTYPEKEYWORD:
//					//connectiontypekeyword
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_DEFINEKEYWORD:
//					//definekeyword
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_DIRECTION:
//					//direction
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ID:
//					//id
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_LENGTHKEYWORD:
//					//lengthkeyword
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_NAMEKEYWORD:
//					//namekeyword
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_NUM:
//					//num
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_PATHSKEYWORD:
//					//pathskeyword
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_RANDOMENDKEYWORD:
//					//randomendkeyword
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_RANDOMSTARTKEYWORD:
//					//randomstartkeyword
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADNETWORKKEYWORD:
//					//roadnetworkkeyword
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_SPEEDKEYWORD:
//					//speedkeyword
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_SUBNETWORKKEYWORD:
//					//subnetworkkeyword
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TESTVEHICLESKEYWORD:
//					//testvehicleskeyword
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TRAFFICKEYWORD:
//					//traffickeyword
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_CONNECTIONIDKLS:
//					//<ConnectionIDKlS>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_CONNECTIONIDLIST:
//					//<ConnectionIDList>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_CONNECTIONTYPE:
//					//<ConnectionType>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_CONNECTIONTYPEBODY:
//					//<ConnectionTypeBody>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_CONNECTIONTYPEELEMENT:
//					//<ConnectionTypeElement>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_CONNECTIONTYPEELEMENTKLS:
//					//<ConnectionTypeElementKlS>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_DEFINE:
//					//<Define>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_DEFINEKLS:
//					//<DefineKlS>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_PATH:
//					//<Path>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_PATHKLS:
//					//<PathKlS>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_PATHS:
//					//<Paths>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_PATHSBODY:
//					//<PathsBody>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADID:
//					//<RoadID>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADIDKLS:
//					//<RoadIDKlS>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADLENGTH:
//					//<RoadLength>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADLENGTHKLS:
//					//<RoadLengthKlS>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADLENGTHS:
//					//<RoadLengths>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADLENGTHSLIST:
//					//<RoadLengthsList>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADLIST:
//					//<RoadList>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADNAME:
//					//<RoadName>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADNAMEKLS:
//					//<RoadNameKlS>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADNAMES:
//					//<RoadNames>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADNAMESLIST:
//					//<RoadNamesList>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADNETWORK:
//					//<RoadNetwork>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADNETWORKBODY:
//					//<RoadNetworkBody>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADSPEED:
//					//<RoadSpeed>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADSPEEDKLS:
//					//<RoadSpeedKlS>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADSPEEDS:
//					//<RoadSpeeds>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROADSPEEDSLIST:
//					//<RoadSpeedsList>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROUTE:
//					//<Route>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_ROUTEKLS:
//					//<RouteKlS>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_START:
//					//<Start>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_SUBNETWORK:
//					//<SubNetwork>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_SUBNETWORKBODY:
//					//<SubNetworkBody>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_SUBNETWORKKLS:
//					//<SubNetworkKlS>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_SUBNETWORKROUTE:
//					//<SubNetworkRoute>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_SUBNETWORKROUTEKLS:
//					//<SubNetworkRouteKlS>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TESTVEHICLE:
//					//<TestVehicle>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TESTVEHICLEKLS:
//					//<TestVehicleKlS>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TESTVEHICLEROUTE:
//					//<TestVehicleRoute>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TESTVEHICLES:
//					//<TestVehicles>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TESTVEHICLESBODY:
//					//<TestVehiclesBody>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TRAFFIC:
//					//<Traffic>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TRAFFICBODY:
//					//<TrafficBody>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TRAFFICELEMENT:
//					//<TrafficElement>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TRAFFICELEMENTKLS:
//					//<TrafficElementKlS>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TRAFFICEND:
//					//<TrafficEnd>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TRAFFICSTART:
//					//<TrafficStart>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//				case (int)SymbolConstants.SYMBOL_TRAFFICSTARTEND:
//					//<TrafficStartEnd>
//					//todo: Create a new object that corresponds to the symbol
//					return null;

//			}
//			throw new SymbolException("Unknown symbol");
//		}

//		public Object CreateObjectFromNonterminal(NonterminalToken token)
//		{
//			switch (token.Rule.Id)
//			{
//				case (int)RuleConstants.RULE_START_DEFINEKEYWORD:
//					//<Start> ::= definekeyword <RoadNetwork> <DefineKlS>
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADNETWORK_ROADNETWORKKEYWORD_ID_LBRACE_RBRACE:
//					//<RoadNetwork> ::= roadnetworkkeyword id '{' <RoadNetworkBody> '}'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADNETWORKBODY:
//					//<RoadNetworkBody> ::= <ConnectionType> <SubNetworkKlS> <SubNetwork>
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_CONNECTIONTYPE_CONNECTIONTYPEKEYWORD_LBRACE_RBRACE:
//					//<ConnectionType> ::= connectiontypekeyword '{' <ConnectionTypeBody> '}'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_CONNECTIONTYPEBODY_SEMI:
//					//<ConnectionTypeBody> ::= <ConnectionTypeElementKlS> <ConnectionTypeElement> ';'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_CONNECTIONTYPEELEMENTKLS_COMMA:
//					//<ConnectionTypeElementKlS> ::= <ConnectionTypeElementKlS> <ConnectionTypeElement> ','
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_CONNECTIONTYPEELEMENTKLS:
//					//<ConnectionTypeElementKlS> ::= 
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_CONNECTIONTYPEELEMENT_CONNECTIONSYMBOL_LPAREN_RPAREN:
//					//<ConnectionTypeElement> ::= connectionsymbol '(' <ConnectionIDList> ')'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_CONNECTIONIDLIST_ID:
//					//<ConnectionIDList> ::= <ConnectionIDKlS> id
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_CONNECTIONIDKLS_ID_COMMA:
//					//<ConnectionIDKlS> ::= <ConnectionIDKlS> id ','
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_CONNECTIONIDKLS:
//					//<ConnectionIDKlS> ::= 
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_SUBNETWORKKLS:
//					//<SubNetworkKlS> ::= <SubNetworkKlS> <SubNetwork>
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_SUBNETWORKKLS2:
//					//<SubNetworkKlS> ::= 
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_SUBNETWORK_DEFINEKEYWORD_SUBNETWORKKEYWORD_ID_LBRACE_RBRACE:
//					//<SubNetwork> ::= definekeyword subnetworkkeyword id '{' <SubNetworkBody> '}'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_SUBNETWORKBODY:
//					//<SubNetworkBody> ::= <SubNetworkRoute> <RoadNames> <RoadLengths> <RoadSpeeds>
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_SUBNETWORKROUTE_LBRACKET_RBRACKET_SEMI:
//					//<SubNetworkRoute> ::= <SubNetworkRouteKlS> '[' <Route> ']' ';'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_SUBNETWORKROUTEKLS_LBRACKET_RBRACKET_COMMA:
//					//<SubNetworkRouteKlS> ::= <SubNetworkRouteKlS> '[' <Route> ']' ','
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_SUBNETWORKROUTEKLS:
//					//<SubNetworkRouteKlS> ::= 
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROUTE_ID_DIRECTION_ID:
//					//<Route> ::= id direction id <RouteKlS>
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROUTEKLS_DIRECTION_ID:
//					//<RouteKlS> ::= <RouteKlS> direction id
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROUTEKLS:
//					//<RouteKlS> ::= 
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADNAMES_NAMEKEYWORD_LBRACE_RBRACE:
//					//<RoadNames> ::= namekeyword '{' <RoadNamesList> '}'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADNAMESLIST_SEMI:
//					//<RoadNamesList> ::= <RoadNameKlS> <RoadName> ';'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADNAMEKLS_COMMA:
//					//<RoadNameKlS> ::= <RoadNameKlS> <RoadName> ','
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADNAMEKLS:
//					//<RoadNameKlS> ::= 
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADNAME_ID_LPAREN_RPAREN:
//					//<RoadName> ::= id '(' <RoadList> ')'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADLIST:
//					//<RoadList> ::= <RoadIDKlS> <RoadID>
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADIDKLS_COMMA:
//					//<RoadIDKlS> ::= <RoadIDKlS> <RoadID> ','
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADIDKLS:
//					//<RoadIDKlS> ::= 
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADID_ID___ID:
//					//<RoadID> ::= id '_' id
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADLENGTHS_LENGTHKEYWORD_LBRACE_RBRACE:
//					//<RoadLengths> ::= lengthkeyword '{' <RoadLengthsList> '}'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADLENGTHSLIST_SEMI:
//					//<RoadLengthsList> ::= <RoadLengthKlS> <RoadLength> ';'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADLENGTHKLS_COMMA:
//					//<RoadLengthKlS> ::= <RoadLengthKlS> <RoadLength> ','
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADLENGTHKLS:
//					//<RoadLengthKlS> ::= 
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADLENGTH_NUM_LPAREN_RPAREN:
//					//<RoadLength> ::= num '(' <RoadList> ')'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADSPEEDS_SPEEDKEYWORD_LBRACE_RBRACE:
//					//<RoadSpeeds> ::= speedkeyword '{' <RoadSpeedsList> '}'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADSPEEDSLIST_SEMI:
//					//<RoadSpeedsList> ::= <RoadSpeedKlS> <RoadSpeed> ';'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADSPEEDKLS_COMMA:
//					//<RoadSpeedKlS> ::= <RoadSpeedKlS> <RoadSpeed> ','
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADSPEEDKLS:
//					//<RoadSpeedKlS> ::= 
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_ROADSPEED_NUM_LPAREN_RPAREN:
//					//<RoadSpeed> ::= num '(' <RoadList> ')'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_DEFINEKLS_DEFINEKEYWORD:
//					//<DefineKlS> ::= <DefineKlS> definekeyword <Define>
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_DEFINEKLS:
//					//<DefineKlS> ::= 
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_DEFINE:
//					//<Define> ::= <Paths>
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_DEFINE2:
//					//<Define> ::= <Traffic>
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_DEFINE3:
//					//<Define> ::= <TestVehicles>
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_PATHS_PATHSKEYWORD_LBRACE_RBRACE:
//					//<Paths> ::= pathskeyword '{' <PathsBody> '}'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_PATHSBODY_SEMI:
//					//<PathsBody> ::= <PathKlS> <Path> ';'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_PATHKLS_COMMA:
//					//<PathKlS> ::= <PathKlS> <Path> ','
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_PATHKLS:
//					//<PathKlS> ::= 
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_PATH_ID_LPAREN_RPAREN:
//					//<Path> ::= id '(' <ConnectionIDList> ')'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TRAFFIC_TRAFFICKEYWORD_LBRACE_RBRACE:
//					//<Traffic> ::= traffickeyword '{' <TrafficBody> '}'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TRAFFICBODY_SEMI:
//					//<TrafficBody> ::= <TrafficElementKlS> <TrafficElement> ';'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TRAFFICELEMENTKLS_COMMA:
//					//<TrafficElementKlS> ::= <TrafficElementKlS> <TrafficElement> ','
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TRAFFICELEMENTKLS:
//					//<TrafficElementKlS> ::= 
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TRAFFICELEMENT_LPAREN_NUM_COMMA_NUM_COMMA_NUM_COMMA_RPAREN:
//					//<TrafficElement> ::= '(' num ',' num ',' num ',' <TrafficStartEnd> ')'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TRAFFICSTARTEND_ID:
//					//<TrafficStartEnd> ::= id
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TRAFFICSTARTEND_COMMA:
//					//<TrafficStartEnd> ::= <TrafficStart> ',' <TrafficEnd>
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TRAFFICSTART_ID:
//					//<TrafficStart> ::= id
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TRAFFICSTART_RANDOMSTARTKEYWORD:
//					//<TrafficStart> ::= randomstartkeyword
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TRAFFICEND_ID:
//					//<TrafficEnd> ::= id
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TRAFFICEND_RANDOMENDKEYWORD:
//					//<TrafficEnd> ::= randomendkeyword
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TESTVEHICLES_TESTVEHICLESKEYWORD_LBRACE_RBRACE:
//					//<TestVehicles> ::= testvehicleskeyword '{' <TestVehiclesBody> '}'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TESTVEHICLESBODY_SEMI:
//					//<TestVehiclesBody> ::= <TestVehicleKlS> <TestVehicle> ';'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TESTVEHICLEKLS_COMMA:
//					//<TestVehicleKlS> ::= <TestVehicleKlS> <TestVehicle> ','
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TESTVEHICLEKLS:
//					//<TestVehicleKlS> ::= 
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TESTVEHICLE_ID_LPAREN_NUM_COMMA_NUM_COMMA_RPAREN:
//					//<TestVehicle> ::= id '(' num ',' num ',' <TestVehicleRoute> ')'
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TESTVEHICLEROUTE_ID:
//					//<TestVehicleRoute> ::= id
//					//todo: Create a new object using the stored tokens.
//					return null;

//				case (int)RuleConstants.RULE_TESTVEHICLEROUTE_ID_COMMA_ID:
//					//<TestVehicleRoute> ::= id ',' id
//					//todo: Create a new object using the stored tokens.
//					return null;

//			}
//			throw new RuleException("Unknown rule");
//		}

//		private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
//		{
//			string message = "Token error with input: '" + args.Token.ToString() + "'";
//			//todo: Report message to UI?
//		}

//		private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
//		{
//			string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "'";
//			//todo: Report message to UI?
//		}

//	}
//}
