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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;

using GoldParser;

#endregion

namespace TreeBuilder
{
	
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.TabPage tpSource;
		private System.Windows.Forms.TabPage tpParseActions;
		private System.Windows.Forms.TabPage tpParseTree;
		private System.Windows.Forms.ListView lvParseActions;
		private System.Windows.Forms.ColumnHeader chActions;
		private System.Windows.Forms.ColumnHeader chLine;
		private System.Windows.Forms.ColumnHeader chDescription;
		private System.Windows.Forms.ColumnHeader chNo;
		private System.Windows.Forms.ColumnHeader chValue;
		private System.Windows.Forms.ColumnHeader chTableIndex;
		private System.Windows.Forms.TreeView tvParseTree;
		private System.Windows.Forms.ToolBarButton tbOpen;
		private System.Windows.Forms.ToolBarButton tbSave;
		private System.Windows.Forms.ToolBarButton tbSeparator1;
		private System.Windows.Forms.ToolBarButton tbParse;
		private System.Windows.Forms.ImageList ilIcons;
		private System.Windows.Forms.TextBox tbSource;
		private System.Windows.Forms.TabControl tcPages;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbOpen = new System.Windows.Forms.ToolBarButton();
			this.tbSave = new System.Windows.Forms.ToolBarButton();
			this.tbSeparator1 = new System.Windows.Forms.ToolBarButton();
			this.tbParse = new System.Windows.Forms.ToolBarButton();
			this.ilIcons = new System.Windows.Forms.ImageList(this.components);
			this.tcPages = new System.Windows.Forms.TabControl();
			this.tpSource = new System.Windows.Forms.TabPage();
			this.tbSource = new System.Windows.Forms.TextBox();
			this.tpParseActions = new System.Windows.Forms.TabPage();
			this.lvParseActions = new System.Windows.Forms.ListView();
			this.chActions = new System.Windows.Forms.ColumnHeader();
			this.chLine = new System.Windows.Forms.ColumnHeader();
			this.chDescription = new System.Windows.Forms.ColumnHeader();
			this.chNo = new System.Windows.Forms.ColumnHeader();
			this.chValue = new System.Windows.Forms.ColumnHeader();
			this.chTableIndex = new System.Windows.Forms.ColumnHeader();
			this.tpParseTree = new System.Windows.Forms.TabPage();
			this.tvParseTree = new System.Windows.Forms.TreeView();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.tcPages.SuspendLayout();
			this.tpSource.SuspendLayout();
			this.tpParseActions.SuspendLayout();
			this.tpParseTree.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbOpen,
																						this.tbSave,
																						this.tbSeparator1,
																						this.tbParse});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.ilIcons;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(688, 28);
			this.toolBar1.TabIndex = 2;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbOpen
			// 
			this.tbOpen.ImageIndex = 4;
			this.tbOpen.Text = "Open";
			this.tbOpen.ToolTipText = "Open Source File";
			// 
			// tbSave
			// 
			this.tbSave.ImageIndex = 5;
			this.tbSave.Text = "Save";
			this.tbSave.ToolTipText = "Save Source File";
			// 
			// tbSeparator1
			// 
			this.tbSeparator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbParse
			// 
			this.tbParse.ImageIndex = 6;
			this.tbParse.Text = "Parse";
			this.tbParse.ToolTipText = "Parse the Source Text";
			// 
			// ilIcons
			// 
			this.ilIcons.ImageSize = new System.Drawing.Size(16, 16);
			this.ilIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons.ImageStream")));
			this.ilIcons.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// tcPages
			// 
			this.tcPages.Controls.Add(this.tpSource);
			this.tcPages.Controls.Add(this.tpParseActions);
			this.tcPages.Controls.Add(this.tpParseTree);
			this.tcPages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcPages.Location = new System.Drawing.Point(0, 28);
			this.tcPages.Name = "tcPages";
			this.tcPages.SelectedIndex = 0;
			this.tcPages.Size = new System.Drawing.Size(688, 554);
			this.tcPages.TabIndex = 3;
			// 
			// tpSource
			// 
			this.tpSource.Controls.Add(this.tbSource);
			this.tpSource.Location = new System.Drawing.Point(4, 22);
			this.tpSource.Name = "tpSource";
			this.tpSource.Size = new System.Drawing.Size(680, 528);
			this.tpSource.TabIndex = 0;
			this.tpSource.Text = "Source";
			// 
			// tbSource
			// 
			this.tbSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSource.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbSource.Location = new System.Drawing.Point(0, 0);
			this.tbSource.Multiline = true;
			this.tbSource.Name = "tbSource";
			this.tbSource.Size = new System.Drawing.Size(680, 528);
			this.tbSource.TabIndex = 0;
			this.tbSource.Text = "Put your source text here";
			// 
			// tpParseActions
			// 
			this.tpParseActions.Controls.Add(this.lvParseActions);
			this.tpParseActions.Location = new System.Drawing.Point(4, 22);
			this.tpParseActions.Name = "tpParseActions";
			this.tpParseActions.Size = new System.Drawing.Size(680, 514);
			this.tpParseActions.TabIndex = 1;
			this.tpParseActions.Text = "Parse Actions";
			// 
			// lvParseActions
			// 
			this.lvParseActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.chActions,
																							 this.chLine,
																							 this.chDescription,
																							 this.chNo,
																							 this.chValue,
																							 this.chTableIndex});
			this.lvParseActions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvParseActions.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lvParseActions.FullRowSelect = true;
			this.lvParseActions.GridLines = true;
			this.lvParseActions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvParseActions.HideSelection = false;
			this.lvParseActions.Location = new System.Drawing.Point(0, 0);
			this.lvParseActions.MultiSelect = false;
			this.lvParseActions.Name = "lvParseActions";
			this.lvParseActions.Size = new System.Drawing.Size(680, 514);
			this.lvParseActions.SmallImageList = this.ilIcons;
			this.lvParseActions.TabIndex = 0;
			this.lvParseActions.View = System.Windows.Forms.View.Details;
			// 
			// chActions
			// 
			this.chActions.Text = "Action";
			this.chActions.Width = 123;
			// 
			// chLine
			// 
			this.chLine.Text = "Line";
			this.chLine.Width = 40;
			// 
			// chDescription
			// 
			this.chDescription.Text = "Description";
			this.chDescription.Width = 256;
			// 
			// chNo
			// 
			this.chNo.Text = "#";
			this.chNo.Width = 25;
			// 
			// chValue
			// 
			this.chValue.Text = "Value";
			this.chValue.Width = 81;
			// 
			// chTableIndex
			// 
			this.chTableIndex.Text = "Table Index";
			this.chTableIndex.Width = 117;
			// 
			// tpParseTree
			// 
			this.tpParseTree.Controls.Add(this.tvParseTree);
			this.tpParseTree.Location = new System.Drawing.Point(4, 22);
			this.tpParseTree.Name = "tpParseTree";
			this.tpParseTree.Size = new System.Drawing.Size(680, 514);
			this.tpParseTree.TabIndex = 2;
			this.tpParseTree.Text = "ParseTree";
			// 
			// tvParseTree
			// 
			this.tvParseTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvParseTree.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tvParseTree.ImageList = this.ilIcons;
			this.tvParseTree.Location = new System.Drawing.Point(0, 0);
			this.tvParseTree.Name = "tvParseTree";
			this.tvParseTree.Size = new System.Drawing.Size(680, 514);
			this.tvParseTree.TabIndex = 0;
			// 
			// ParseTest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 582);
			this.Controls.Add(this.tcPages);
			this.Controls.Add(this.toolBar1);
			this.Name = "ParseTest";
			this.Text = "Parse Test";
			this.tcPages.ResumeLayout(false);
			this.tpSource.ResumeLayout(false);
			this.tpParseActions.ResumeLayout(false);
			this.tpParseTree.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == tbOpen)
			{
				OpenFile();
			}
			else if (e.Button == tbSave)
			{
				SaveFile();
			}
			else if (e.Button == tbParse)
			{
				ParseText();
			}
		}

		private void ClearData()
		{
			lvParseActions.Items.Clear();
			tvParseTree.Nodes.Clear();
		}

		private void OpenFile() 
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				ClearData();
				StreamReader reader = new StreamReader(openFileDialog.FileName);
				tbSource.Text = reader.ReadToEnd();
				reader.Close();
			}
		}

		private void SaveFile()
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
				writer.Write(tbSource.Text);
				writer.Close();
			}
		}

		private void ParseText()
		{
			ClearData();
			VBScriptParser parser = new VBScriptParser();
			parser.ParseAction = new ParseActionDelegate(AddParseAction);
			StringReader reader = new StringReader(tbSource.Text);
			NonTerminalNode syntaxNode = parser.Parse(reader) as NonTerminalNode;
			if (syntaxNode != null)
			{
				BuildParseTree(syntaxNode);
				tcPages.SelectedIndex = 2;
			}
			else
			{
				tcPages.SelectedIndex = 1;
			}
		}

		private void AddParseAction(Parser parser, ParseMessage action, string description, 
			string reductionNo, string value, string tableIndex)
		{
			Font font = lvParseActions.Font;
			Color foreColor = lvParseActions.ForeColor;
			Color backColor = Color.White;
			IconType iconType = IconType.Error;
			string actionName = "Error";
			switch (action) 
			{
				case ParseMessage.TokenRead:
					actionName = "Token Read";
					iconType = IconType.Token;
					break;

				case ParseMessage.Reduction:
					actionName = "Reduction";
					iconType = IconType.Reduction;
					foreColor = Color.FromArgb(0x60, 0x30, 0x18);
					backColor = Color.White;
					break;

				case ParseMessage.Accept:
					actionName = "Accept";
					iconType = IconType.Accept;
					foreColor = Color.FromArgb(0x00, 0x60, 0x00);
					backColor = Color.White;
					break;

				case ParseMessage.CommentError:
					actionName = "Comment Error";
					goto default;

				case ParseMessage.InternalError:
					actionName = "Internal Error";
					goto default;
				
				case ParseMessage.LexicalError:
					actionName = "Tokenizer Error";
					goto default;

				case ParseMessage.NotLoadedError:
					actionName = "Not Loaded Error";
					goto default;

				case ParseMessage.SyntaxError:
					actionName = "Syntax Error";
					goto default;


				default:
					iconType = IconType.Error;
					foreColor = Color.FromArgb(0x40, 0x00, 0x00);
					backColor = Color.White;
					break;					
			}

			ListViewItem item = new ListViewItem(new string[] 
				{actionName, parser.LineNumber.ToString(), description,
			    reductionNo, value, tableIndex}, Convert.ToInt32(iconType), foreColor, backColor, font);
			lvParseActions.Items.Add(item);
		}

		private void BuildParseTree(NonTerminalNode nonTerminal)
		{
			tvParseTree.Nodes.Clear();
			TreeNode node = new TreeNode(nonTerminal.Rule.ToString(), 
				Convert.ToInt32(IconType.Reduction), 
				Convert.ToInt32(IconType.Reduction));
			tvParseTree.Nodes.Add(node);
			for (int i = 0; i < nonTerminal.Count; i++)
			{
				SyntaxNode childNode = nonTerminal[i];
				BuildParseTree(childNode, node);
			}
			node.Expand();
		}

		private void BuildParseTree(SyntaxNode syntaxNode, TreeNode parentNode)
		{
			NonTerminalNode nonTerminal = syntaxNode as NonTerminalNode;
			if (nonTerminal != null)
			{
				TreeNode node = new TreeNode(nonTerminal.Rule.ToString(), 
					Convert.ToInt32(IconType.Reduction), 
					Convert.ToInt32(IconType.Reduction));
				parentNode.Nodes.Add(node);
				for (int i = 0; i < nonTerminal.Count; i++)
				{
					SyntaxNode childNode = nonTerminal[i];
					BuildParseTree(childNode, node);
				}
			}
			else
			{
				TreeNode node = new TreeNode(syntaxNode.ToString(), 
					Convert.ToInt32(IconType.Token), 
					Convert.ToInt32(IconType.Token));
				parentNode.Nodes.Add(node);
			}
		}

		private enum IconType 
		{
			Token = 0,
			Reduction = 1,
			Accept = 2,
			Error = 3
		}
	}
}
