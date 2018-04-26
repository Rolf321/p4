#region Copyright

//----------------------------------------------------------------------
// VBSctipt grammar implementation for Gold Parser engine.
// See more details on http://www.devincook.com/goldparser/
// 
// Original code is written in VB by Devin Cook (GOLDParser@DevinCook.com)
//
// This translation is done by Vladimir Morozov (vmoroz@hotmail.com)
// 
// The translation is based on the other engine translations:
// Delphi engine by Alexandre Rai (riccio@gmx.at)
// C# engine by Marcus Klimstra (klimstra@home.nl)
//----------------------------------------------------------------------

#endregion

#region Using directives

using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Reflection;

using GoldParser;

#endregion

namespace TreeBuilder
{
	/// <summary>
	/// VB Script parser.
	/// </summary>
	public class VBScriptParser
	{
		private Grammar m_grammar;
		private ParseActionDelegate m_parseAction; 
		
		/// <summary>
		/// Creates a new instance of <see cref="VBScriptParser"/> class.
		/// </summary>
		public VBScriptParser()
		{
			BinaryReader reader = GetResourceReader("TreeBuilder.VBScript.cgt");		
			m_grammar = new Grammar(reader);
		}

		/// <summary>
		/// Callback function to monitor parsing events.
		/// </summary>
		public ParseActionDelegate ParseAction 
		{
			get { return m_parseAction; }
			set { m_parseAction = value; }
		}

		/// <summary>
		/// Parsers the given string.
		/// </summary>
		/// <param name="value">String to parse.</param>
		/// <returns>
		/// Topmost reduction if the parsing was successful.
		/// Retuns null if the value was not parsed.
		/// </returns>
		public SyntaxNode Parse(TextReader reader)
		{
			int reductionNumber = 0;
			Parser parser = new Parser(reader, m_grammar);
			parser.TrimReductions = true;
			
			while (true)
			{
				ParseMessage response = parser.Parse();
				switch (response)
				{
					case ParseMessage.LexicalError:
						AddParseAction(parser, response, "Cannot Recognize Token", 
							"",	parser.TokenText, "");
						return null;

					case ParseMessage.SyntaxError:
						StringBuilder expectedTokens = new StringBuilder();
						foreach (Symbol token in parser.GetExpectedTokens())
						{
							expectedTokens.Append(token.Name);
							expectedTokens.Append(' ');
						}
						AddParseAction(parser, response, "Expecting the following tokens", 
							"",	expectedTokens.ToString(), "");
						return null;     

					case ParseMessage.Reduction:
						NonTerminalNode nonTerminal = new NonTerminalNode(parser.ReductionRule);
						nonTerminal.ReductionNumber = ++reductionNumber;
						parser.TokenSyntaxNode = nonTerminal;
						StringBuilder childReductionList = new StringBuilder();
						for (int i = 0; i < parser.ReductionCount; i++)
						{
							SyntaxNode node = parser.GetReductionSyntaxNode(i) as SyntaxNode;
							nonTerminal.Add(node);
							NonTerminalNode childNode = node as NonTerminalNode;
							if (childNode != null)
							{
								childReductionList.Append('#');
								childReductionList.Append(childNode.ReductionNumber);
								childReductionList.Append(' ');
							}
						}
						AddParseAction(parser, response, nonTerminal.Rule.ToString(),
							reductionNumber.ToString(),
							childReductionList.ToString(),
							nonTerminal.Rule.Index.ToString());
						break;
     
					case ParseMessage.Accept:	//=== Success!
						AddParseAction(parser, response, parser.ReductionRule.ToString(),	
							"", "", "");
						return (SyntaxNode) parser.TokenSyntaxNode;
        
					case ParseMessage.TokenRead:
						TerminalNode terminal = new TerminalNode(
							parser.TokenSymbol,
							parser.TokenText,
							parser.TokenString,
							parser.TokenLineNumber,
							parser.TokenLinePosition);
						parser.TokenSyntaxNode = terminal;
						AddParseAction(parser, response, 
							terminal.Symbol.Name, "", 
							terminal.ToString(), 
							terminal.Symbol.Index.ToString());
						break;

					case ParseMessage.InternalError:
						AddParseAction(parser, response, "Error in LR state engine", 
							"",	"", "");
						return null;

					case ParseMessage.NotLoadedError:
						//=== Due to the if-statement above, this case statement should never be true
						AddParseAction(parser, response, "Compiled Grammar Table not loaded", 
							"",	"", "");
						return null;
        
					case ParseMessage.CommentError:
						AddParseAction(parser, response, "Unexpected end of file", 
							"",	"", "");
						return null;
				}
			}		
		}

		private void AddParseAction(Parser parser, ParseMessage action, 
			string description, string reductionNo, string value, string tableIndex)
		{
			if (m_parseAction != null)
			{
				m_parseAction(parser, action, description, reductionNo, value, tableIndex);
			}
		}

		private BinaryReader GetResourceReader(string resourceName)
		{  
			Assembly assembly = this.GetType().Assembly;   
			Stream stream = assembly.GetManifestResourceStream(resourceName);
			return new BinaryReader(stream);
		}
	}
}
