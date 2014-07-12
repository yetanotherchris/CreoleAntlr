grammar CreoleFormatting;

file: (text | linebreak | WS)* EOF;

// Linebreak		: \\
// Horizontal rule	: ----
// Bold			: **bold**
// Italic		: //italic//

text: TEXT;
linebreak: LINEBREAK;

TEXT: ~(['\\'])+;

LINEBREAK: '\\'+;
NL: [\n]+ -> skip ;