using System;
using CreoleAntlr.Formatting;
using CreoleAntlr.Paragraphs;

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
			FormattingRunner.Run();
			Console.ReadLine();
		}
	}
}