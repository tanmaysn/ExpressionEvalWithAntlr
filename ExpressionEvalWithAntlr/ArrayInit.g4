grammar ArrayInit;

/*
 * Parser Rules
 */
init: '{' value  (',' value)* '}';
value: init
	|INT
	;
INT: [0-9]+;

compileUnit
	:	EOF
	;

/*
 * Lexer Rules
 */

WS
	:	[ \t\r\n]+ -> skip ;
