using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace tsl_interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine(GetDirectory());
	        Console.ReadKey();
			Stack s = new Stack();
			MyParser parser = new MyParser(s);

			ParserFactory.InitializeFactoryFromFile(Path.Combine(GetDirectory(), "cgt.cgt"));
			parser.Parse(File.ReadAllText(Path.Combine(GetDirectory(), "simpletest.txt")));

	        if (parser.SyntaxTree != null)
	        {
				//if (parser.SyntaxTree.LeftmostChild != null)
				//{
				// Console.WriteLine(parser.SyntaxTree.LeftmostChild.GetType());
				//}
				//if (parser.SyntaxTree.Parent != null)
				//{
				// Console.WriteLine(parser.SyntaxTree.Parent.GetType());
				//}
				//if (parser.SyntaxTree.LeftmostSibling != null)
				//{
				// Console.WriteLine(parser.SyntaxTree.LeftmostSibling.GetType());
				//}
				//if (parser.SyntaxTree.RightSibling != null)
				//{
				// Console.WriteLine(parser.SyntaxTree.RightSibling.GetType());
				//}
				PrintAST(parser.SyntaxTree);
			}
			else
				Console.WriteLine("syntax tree is null");
			WriteNodesToConsole(parser.Stack.GetNodes);
	        Console.ReadKey();
        }

		private static void PrintAST(ASTNode node)
		{
			if(node != null)
			{
				if (node is TerminalNode)
					Console.ForegroundColor = ConsoleColor.Red;
				else
					Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine(node.GetType());
				foreach(ASTNode n in node.Children)
				{
					PrintAST(n);
				}
			}
		}

		//stien til mappen hvor test.txt og cgt.cgt ligger
		private static string GetDirectory()
	    {
		    DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());
		    directory = directory.Parent;
		    return directory.FullName;
	    }

	    //skriver liste af alle nodes ud
		private static void WriteNodesToConsole(List<ASTNode> nodes)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Liste af alle nodes:");
			Console.ForegroundColor = ConsoleColor.White;
		    if (nodes != null)
		    {
			    foreach (ASTNode n in nodes)
			    {
				    if (n != null)
				    {
					    Console.WriteLine(n.GetType());
				    }
				    else
				    {
					    Console.WriteLine("null node");
				    }
			    }
		    }
		}
	}
}
