grammar FilterExpressions;

INT : DIGIT+ ; 
FLOAT : DIGIT+ '.' DIGIT* 
		| '.' DIGIT+ ;

STRING : '"' ( ESC | . )*? '"' ; 
fragment ESC : '\\' [btnr"\\] ; 		// \b, \t, \n etc...

WS : [ \t\n\r]+ -> skip;



