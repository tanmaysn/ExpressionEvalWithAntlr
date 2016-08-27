grammar Expressions;
import CommonLexerRules;

/*
 * Parser Rules
 */

parse 
	:	condition 
		NEWLINE;

condition
	:	expr									#simpleExpression
	|	expr (binary expr)*						#binaryExpression
	;

expr
	:	LPAREN expr RPAREN							#parenExpression
	|	left=value op=Comparer right=value	#comparisonExpression
	;

value
	:	ID
	|	INT 
	|	STRING
	| 	'true'
	| 	'false'
	;
				
binary
	:	AND |	OR
	;

Comparer
	:	EQ | NEQ | GEQ | GT | LT | LEQ 
	;

/*
 * Lexer Rules
 */
AND		:	[Aa][Nn][Dd] ;		//And
OR		:	[Oo][Rr] ;			//Or
EQ		:	[Ee][Qq]			//Equals 
		| 	'='
		;
NEQ		:	[Nn][Ee][Qq] ;		//Not Equal
GEQ		:	[Gg][Ee][Qq] ;		//GreaterThanEqual
GT		:	[Gg][Tt] ;			//GreaterThan
LT		:	[Ll][Tt] ;			//LessThan
LEQ		:	[Ll][Ee][Qq] ;		//LessThanEqual
TRUE	:	[Tt][Rr][Uu][Ee] ;
FALSE	:	[Ff][Aa][Ll][Ss][Ee]   ;