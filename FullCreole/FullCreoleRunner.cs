using System;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using HtmlAgilityPack;

namespace CreoleAntlr.FullCreole
{
	public class FullCreoleRunner
	{
		public static void Run()
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
