grammar CreoleParagraphs;


file: paragraph+ EOF; 
paragraph: TEXT '\r'? '\n'; 
blankline: '\r'? '\n';
TEXT   : ~[\n\r]+; 
