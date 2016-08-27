lexer grammar CommonLexerRules;


/*
 * Lexer Rules
 */

LPAREN      :   '(';
RPAREN      :   ')';
DOT			:	'.' ;
MUL			:   '*' ; // assigns token name to '*' used above in grammar
DIV			:   '/' ;
ADD			:   '+' ;
SUB			:   '-' ;
ID			:   ID_LETTER (ID_LETTER | DIGIT)*;      // match identifiers
fragment
ID_LETTER	:	'a'..'z'|'A'..'Z'|'_' ;				
INT			:   [0-9]+ ;         // match integers
NUMBER		:   '-'? ('.' DIGIT+ | DIGIT+ ('.' DIGIT*)? ) ;
fragment
DIGIT 		: 	[0-9] ;
STRING		: 	'"' .*? '"';	 // match anything between " " 
NEWLINE		:  	'\r'? '\n' ;     // return newlines to parser (is end-statement signal)
WS  		:   [ \t]+ -> skip ; // toss out whitespace