grammar CreoleParagraphs;

  
document
    : paragraph*
    ;

paragraph
	: ~'%' CR
	;

CR
    : '\r'? '\n'
    | EOF
    ;