using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace CreoleAntlr.Paragraphs
{
	public class ParagraphRunner
	{
		public static void Run()
		{
			AntlrInputStream inputStream = new AntlrInputStream(File.OpenText("paragraphs-testinput.txt"));
			CreoleParagraphsLexer creoleLexer = new CreoleParagraphsLexer(inputStream);
			CommonTokenStream commonTokenStream = new CommonTokenStream(creoleLexer);

			HtmlBuilder htmlBuilder = new HtmlBuilder();
			ParagraphListener listener = new ParagraphListener(htmlBuilder);

			CreoleParagraphsParser parser = new CreoleParagraphsParser(commonTokenStream);
			parser.AddParseListener(listener);

			IParseTree tree = parser.file();
			Console.WriteLine(htmlBuilder);
		}
	}
}
