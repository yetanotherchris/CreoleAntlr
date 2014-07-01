grammar CreoleParagraphs;

file: paragraph* EOF;		// any number of paragraphs
paragraph: TEXT CRLF*?;		// ignore CRLFs inside the paragraph, e.g. 4 newlines then some more text.

CRLF	: '\r'* '\n'+;		// group up new lines - Windows CR optional, at least one LF
TEXT	: ~([\n\r])+;		// anything except new lines, at least 1