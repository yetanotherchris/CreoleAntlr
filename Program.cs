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
	// Paragraphs, \\ line breaks
	// Bold, Italic
	// Horizontal Rule
	// Headings
	// Links (+ text and images inside links)
	// 	- Free standing Urls should be detected
	// Images
	// Lists
	// Tables
	// Escape character: ~#1
	// Nowiki
	class Program
	{
		private static void Main(string[] args)
		{
			RunParagraphParser();
			Console.ReadLine();
		}

		static void RunParagraphParser()
		{
			AntlrInputStream inputStream = new AntlrInputStream(File.OpenText("testinput.txt"));
			CreoleLexer creoleLexer = new CreoleLexer(inputStream);
			CommonTokenStream commonTokenStream = new CommonTokenStream(creoleLexer);

			HtmlBuilder htmlBuilder = new HtmlBuilder();
			ParagraphListener listener = new ParagraphListener(htmlBuilder);

			CreoleParagraphsParser parser = new CreoleParagraphsParser(commonTokenStream);
			parser.AddParseListener(listener);

			IParseTree tree = parser.file();
			Console.WriteLine(htmlBuilder);
			Console.ReadKey();
		}

		static void RunFullParser()
		{
			AntlrInputStream inputStream = new AntlrInputStream(File.OpenText("testinput.txt"));
			CreoleLexer creoleLexer = new CreoleLexer(inputStream);
			CommonTokenStream commonTokenStream = new CommonTokenStream(creoleLexer);

			HtmlBuilder htmlBuilder = new HtmlBuilder();
			MyListener listener = new MyListener(htmlBuilder);
			
			CreoleParser parser = new CreoleParser(commonTokenStream);
			parser.AddParseListener(listener);
			
			IParseTree tree = parser.document();

			var visitor = new MyVisitor(htmlBuilder);
			visitor.Visit(tree);
			HtmlDocument doc = htmlBuilder.Document;
			//Console.WriteLine(doc.DocumentNode.InnerHtml);
			Console.WriteLine(htmlBuilder);

			Console.ReadKey();
		}
	}

	public class HtmlBuilder
	{
		public HtmlDocument Document { get; set; }
		private HtmlNode _currentNode;
		private StringBuilder _stringBuilder;

		public override string ToString()
		{
			return _stringBuilder.ToString();
		}

		public HtmlBuilder()
		{
			_stringBuilder = new StringBuilder();

			Document = new HtmlDocument();
			_currentNode = Document.DocumentNode;
		}

		public void SetText(string text)
		{
			_stringBuilder.Append(text);

			if (_currentNode.ChildNodes.Count == 0)
			{
				_currentNode.InnerHtml = text;
			}
		}

		public void AddNode(string name)
		{
			_stringBuilder.AppendFormat("<{0}>", name);
			//if (_currentNode.Name != name)
			//{
				var newNode = new HtmlNode(HtmlNodeType.Element, Document, 0);
				newNode.Name = name;
				_currentNode.AppendChild(newNode);
				_currentNode = newNode;
			//}
		}

		public void FinishNode(string name)
		{
			_stringBuilder.AppendFormat("</{0}>", name);
		}
	}

	public class ParagraphListener : CreoleParagraphsBaseListener
	{
		private HtmlBuilder _htmlBuilder;

		public ParagraphListener(HtmlBuilder builder)
		{
			_htmlBuilder = builder;
		}

		public override void EnterParagraph(CreoleParagraphsParser.ParagraphContext context)
		{
			_htmlBuilder.AddNode("p");
		}

		public override void ExitParagraph(CreoleParagraphsParser.ParagraphContext context)
		{
			_htmlBuilder.FinishNode("p");
		}
	}

	public class MyListener : CreoleBaseListener
	{
		private HtmlBuilder _htmlBuilder;

		public MyListener(HtmlBuilder builder)
		{
			_htmlBuilder = builder;
		}

		public override void ExitText(CreoleParser.TextContext context)
		{
			_htmlBuilder.SetText(context.GetText());
		}

		public override void EnterBold(CreoleParser.BoldContext context)
		{
			_htmlBuilder.AddNode("strong");
		}

		public override void ExitBold(CreoleParser.BoldContext context)
		{
			_htmlBuilder.FinishNode("strong");
		}

		public override void EnterItalics(CreoleParser.ItalicsContext context)
		{
			_htmlBuilder.AddNode("em");
		}

		public override void ExitItalics(CreoleParser.ItalicsContext context)
		{
			_htmlBuilder.FinishNode("em");
		}

		public override void EnterH1(CreoleParser.H1Context context)
		{
			_htmlBuilder.AddNode("h1");
		}

		public override void ExitH1(CreoleParser.H1Context context)
		{
			_htmlBuilder.FinishNode("h1");
		}

		public override void EnterH2(CreoleParser.H2Context context)
		{
			_htmlBuilder.AddNode("h2");
		}

		public override void ExitH2(CreoleParser.H2Context context)
		{
			_htmlBuilder.FinishNode("h2");
		}

		public override void EnterH3(CreoleParser.H3Context context)
		{
			_htmlBuilder.AddNode("h3");
		}

		public override void ExitH3(CreoleParser.H3Context context)
		{
			_htmlBuilder.FinishNode("h3");
		}

		public override void EnterImage(CreoleParser.ImageContext context)
		{
			_htmlBuilder.AddNode("a");
		}
	}

	public class MyVisitor : CreoleBaseVisitor<string>
	{
		private HtmlBuilder _htmlBuilder;

		public MyVisitor(HtmlBuilder builder)
		{
			_htmlBuilder = builder;
		}

		public override string VisitText(CreoleParser.TextContext context)
		{
			return base.VisitText(context);
		}
	}
}