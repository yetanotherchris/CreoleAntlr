grammar CreoleParagraphs;

file: paragraph+ EOF; 
paragraph: TEXT CRNL*?;
blankpara: CRNL;
CRNL : '\r'* '\n'+;
TEXT   : ~([\n\r])+;
