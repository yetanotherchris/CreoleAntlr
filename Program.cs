using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace CreoleAntlr
{
	class Program
	{
		private static void Main(string[] args)
		{
			new Program().Run();
		}

		public void Run()
		{
			try
			{
				Console.WriteLine("START");
				RunParser();
				Console.Write("DONE. Hit RETURN to exit: ");
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR: " + ex);
				Console.Write("Hit RETURN to exit: ");
			}
			Console.ReadLine();
		}

		private void RunParser()
		{
			AntlrInputStream inputStream = new AntlrInputStream("test some *new*\n");
			CreoleLexer creoleLexer = new CreoleLexer(inputStream);

			CommonTokenStream commonTokenStream = new CommonTokenStream(creoleLexer);

			CreoleParser creoleParser = new CreoleParser(commonTokenStream);
			CreoleParser.DocumentContext context = creoleParser.document

			Console.Write(context.ToStringTree());
			//ParseTreeWalker walker = new ParseTreeWalker();
			//CreoleBaseListener listener = new CreoleBaseListener();
			//walker.Walk(listener, );

			//MyVisitor visitor = new MyVisitor();
			//visitor.VisitDocument(context);
		}
	}

	public class MyVisitor : CreoleBaseVisitor<object>
	{
		public override object VisitDocument(CreoleParser.DocumentContext context)
		{
			Console.WriteLine("VisitDocument");
			return base.VisitDocument(context);
		}

		public override object VisitMarkup(CreoleParser.MarkupContext context)
		{
			return base.VisitMarkup(context);
		}

		private void Visit(TerminalNodeImpl node)
		{
			Console.WriteLine(" Visit Symbol={0}", node.Symbol.Text);
		}
	}
}
