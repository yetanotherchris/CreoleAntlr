grammar Creole;
   
document
    : (line? CR)*
    ;
 
line
    : markup+ 
    ;
 
markup
    : bold
    | italics
    | href
    | h1
    | hline
    | text
    | listitem
    | image
    | tablerow
    | tableheader
    | nowiki
    ;
    
text
    : (TEXT | RSLASH)+ ('\\\\' text)*
    ;
 
bold
    : '**' (text|href|image|italics)+ '**'?
    ;
 
italics
    : '//' (text|href|image|bold)+ '//'
    ;
 
href
    : LBRACKET text ('|' markup+)? RBRACKET
    | LBRACE text '|' markup+ RBRACE // Creole 0.2
    ;
 
image
    : '[' text ']'
    ;
 
hline
    : '----'
    ;
 
listitem
    : ('*'+ markup)
    | ('#'+ markup)
    ;
 
tableheader
    : ('|=' markup+)+ '|' WS*
    ;
 
tablerow
    : ('|' markup+)+ '|' WS*
    ;
 
h1
    : '=' text '='* CR 
    ;
 
nowiki
    : NOWIKI
    ;
 
HASH
    : '#'
    ;
 
LBRACKET
    : '[['
    ;
 
RBRACKET
    : ']]'
    ;
 
LBRACE
    : '{{'
    ;
 
RBRACE
    : '}}'
    ;
 
TEXT
    : (LETTERS
    | DIGITS 
    | SYMBOL 
    | WS)+
    ;
 
WS
    : [ \t]
    ;
 
CR
    : '\n'
    | EOF
    ;
 
NOWIKI
    : '{{{' .*? '}}}'
    ;

RSLASH
    : '/'
    ;

fragment LETTERS
    : [a-zA-Z]
    ;
 
fragment DIGITS
    : [0-9]
    ;
 
fragment SYMBOL
    : '.'
    | ';'
    | ':'
    | ','
    | '('
    | ')'
    | '-'
    | '\\'
    | '\''
    | '~'
    | '"'
    | '+'
    ;
 