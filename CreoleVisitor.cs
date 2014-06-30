namespace CreoleAntlr
{
	public class CreoleVisitor : CreoleBaseVisitor<string>
	{
		private HtmlBuilder _htmlBuilder;

		public CreoleVisitor(HtmlBuilder builder)
		{
			_htmlBuilder = builder;
		}

		public override string VisitText(CreoleParser.TextContext context)
		{
			return base.VisitText(context);
		}
	}
}