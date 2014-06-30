using System.Text;
using HtmlAgilityPack;

namespace CreoleAntlr
{
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
			_stringBuilder.Append(text.Trim());
		}

		public void AddNode(string name)
		{
			_stringBuilder.AppendFormat("<{0}>", name);
		}

		public void FinishNode(string name)
		{
			_stringBuilder.AppendFormat("</{0}>\n\n", name);
		}
	}
}