namespace CreoleAntlr
{
	public class CreoleListener : CreoleBaseListener
	{
		private HtmlBuilder _htmlBuilder;

		public CreoleListener(HtmlBuilder builder)
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
}