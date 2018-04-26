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

using GoldParser;

#endregion

namespace TreeBuilder
{
	/// <summary>
	/// Summary description for ParseActionDelegate.
	/// </summary>
	public delegate void ParseActionDelegate(
		Parser parser,
		ParseMessage action, 
		string description, 
		string reductionNo, 
		string value, 
		string tableIndex);
}
