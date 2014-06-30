using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
			CreoleParagraphsLexer creoleLexer = new CreoleParagraphsLexer(inputStream);
			CommonTokenStream commonTokenStream = new CommonTokenStream(creoleLexer);

			HtmlBuilder htmlBuilder = new HtmlBuilder();
			ParagraphListener listener = new ParagraphListener(htmlBuilder);

			CreoleParagraphsParser parser = new CreoleParagraphsParser(commonTokenStream);
			parser.AddParseListener(listener);

			IParseTree tree = parser.file();
			Console.WriteLine(htmlBuilder);
		}

		static void RunFullParser()
		{
			AntlrInputStream inputStream = new AntlrInputStream(File.OpenText("testinput.txt"));
			CreoleLexer creoleLexer = new CreoleLexer(inputStream);
			CommonTokenStream commonTokenStream = new CommonTokenStream(creoleLexer);

			HtmlBuilder htmlBuilder = new HtmlBuilder();
			CreoleListener listener = new CreoleListener(htmlBuilder);
			
			CreoleParser parser = new CreoleParser(commonTokenStream);
			parser.AddParseListener(listener);
			
			IParseTree tree = parser.document();

			var visitor = new CreoleVisitor(htmlBuilder);
			visitor.Visit(tree);
			HtmlDocument doc = htmlBuilder.Document;
			//Console.WriteLine(doc.DocumentNode.InnerHtml);
			Console.WriteLine(htmlBuilder);
		}
	}
}