using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using HtmlAgilityPack;

namespace CreoleAntlr
{
	class Program
	{
		private static void Main(string[] args)
		{
			RunParser();
			Console.ReadLine();
		}

		static void RunParser()
		{
			AntlrInputStream inputStream = new AntlrInputStream(File.OpenText("testinput.txt"));
			CreoleLexer creoleLexer = new CreoleLexer(inputStream);
			CommonTokenStream commonTokenStream = new CommonTokenStream(creoleLexer);

			CreoleParser parser = new CreoleParser(commonTokenStream);
			IParseTree tree = parser.document();

			var visitor = new MyVisitor();
			visitor.Visit(tree);
			HtmlDocument doc = visitor.Document;
			Console.WriteLine(doc.DocumentNode.InnerHtml);
		}
	}

	public class MyVisitor : CreoleBaseVisitor<string>
	{
		public HtmlDocument Document { get; set; }
		private HtmlNode _currentNode;

		public MyVisitor()
		{
			Document = new HtmlDocument();
			_currentNode = Document.DocumentNode;
		}

		public override string VisitText(CreoleParser.TextContext context)
		{
			Console.WriteLine("Text: {0}", context.GetText());
			_currentNode.InnerHtml = context.GetText();
			return base.VisitText(context);
		}

		public override string Visit(IParseTree tree)
		{
			return base.Visit(tree);
		}

		public override string VisitBold(CreoleParser.BoldContext context)
		{
			AddNode("strong");
			return base.VisitBold(context);
		}

		public override string VisitItalics(CreoleParser.ItalicsContext context)
		{
			AddNode("em");
			return base.VisitItalics(context);
		}

		private void AddNode(string name)
		{
			//if (_currentNode.Name != name)
			//{
				var newNode = new HtmlNode(HtmlNodeType.Element, Document, 0);
				newNode.Name = name;

				_currentNode.AppendChild(newNode);
				_currentNode = newNode;
			//}
		}

		//public override string VisitTerminal(ITerminalNode node)
		//{
		//	Console.WriteLine("Text: {0}", node.Symbol.Text);

		//	return base.VisitTerminal(node);
		//}
	}
}
