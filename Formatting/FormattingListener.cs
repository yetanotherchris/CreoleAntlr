namespace CreoleAntlr.Formatting
{
	public class FormattingListener : CreoleFormattingBaseListener
	{
		private HtmlBuilder _htmlBuilder;

		public FormattingListener(HtmlBuilder builder)
		{
			_htmlBuilder = builder;
		}

		public override void ExitText(CreoleFormattingParser.TextContext context)
		{
			string text = context.GetText();
			_htmlBuilder.SetText("{" + text + "}");
		}

		public override void EnterBold(CreoleFormattingParser.BoldContext context)
		{
			_htmlBuilder.AddNode("strong");
		}

		public override void ExitBold(CreoleFormattingParser.BoldContext context)
		{
			_htmlBuilder.FinishNode("strong");
		}

		public override void ExitLinebreak(CreoleFormattingParser.LinebreakContext context)
		{
			_htmlBuilder.AddNode("br");
		}
	}
}