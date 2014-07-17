grammar CreoleFormatting;

file: (text | linebreak | bold | WS)* EOF;

// Linebreak		: \\
// Horizontal rule	: ----
// Bold			: **bold**
// Italic		: //italic//

bold: STARS text STARS;
text: TEXT;

linebreak: LINEBREAK;

TEXT: ~(['\\''**'])+;

STARS: '**';
LINEBREAK: '\\'+;
NL: [\n]+ -> skip ;