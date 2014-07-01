namespace CreoleAntlr.Paragraphs
{
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
			_htmlBuilder.SetText(context.GetText());
			_htmlBuilder.FinishNode("p");
		}
	}
}