using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace CreoleAntlr.Formatting
{
	public class FormattingRunner
	{
		public static void Run()
		{
			AntlrInputStream inputStream = new AntlrInputStream(File.OpenText("formatting-testinput.txt"));
			CreoleParagraphsLexer creoleLexer = new CreoleParagraphsLexer(inputStream);
			CommonTokenStream commonTokenStream = new CommonTokenStream(creoleLexer);

			HtmlBuilder htmlBuilder = new HtmlBuilder();
			FormattingListener listener = new FormattingListener(htmlBuilder);

			CreoleFormattingParser parser = new CreoleFormattingParser(commonTokenStream);
			parser.AddParseListener(listener);

			IParseTree tree = parser.file();
			Console.WriteLine(htmlBuilder);
		}
	}
}
