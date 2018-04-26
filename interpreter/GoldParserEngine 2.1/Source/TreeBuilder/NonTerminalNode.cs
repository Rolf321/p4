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
using System.Collections;
using GoldParser;

#endregion

namespace TreeBuilder
{
	/// <summary>
	/// Summary description for NonTerminalNode.
	/// </summary>
	public class NonTerminalNode : SyntaxNode
	{
		private int m_reductionNumber;
		private Rule m_rule;
		private ArrayList m_array = new ArrayList();

		public NonTerminalNode(Rule rule)
		{
			m_rule = rule;
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

		public SyntaxNode this[int index]
		{
			get { return (SyntaxNode) m_array[index]; }
		}

		public void Add(SyntaxNode node)
		{
			if (node == null)
			{
				return ; //throw new ArgumentNullException("node");
			}
			m_array.Add(node);
		}

		public Rule Rule
		{
			get { return m_rule; }
		}

	}
}
