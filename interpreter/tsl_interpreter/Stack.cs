using System;
using System.Collections.Generic;
using System.Text;

namespace tsl_interpreter
{
    public class Stack
    {
		private List<ASTNode> theStack = new List<ASTNode>();

		public void Push(ASTNode node)
		{
			theStack.Add(node);
		}

		public void Pop()
		{
			theStack.RemoveAt(theStack.Count - 1);
		}

		public bool IsEmpty()
		{
			return theStack.Count == 0;
		}

		public ASTNode GetTop()
		{
			return theStack.FindLast(x => x is ASTNode);
		}

		public List<ASTNode> GetNodes
		{
			get
			{
				return theStack;
			}
		}
    }
}
