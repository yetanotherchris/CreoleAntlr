grammar CreoleFormatting;

file: both | text* | linebreak* EOF;

// Linebreak		: \\
// Horizontal rule	: ----
// Bold			: **bold**
// Italic		: //italic//

both: (text | linebreak)*;
text: TEXT;
linebreak: LINEBREAK;

LINEBREAK: '\\'+;
TEXT: ~('\\')+;