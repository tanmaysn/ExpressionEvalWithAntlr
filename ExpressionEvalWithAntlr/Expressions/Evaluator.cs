using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ExpressionEvalWithAntlr.Expressions
{
    public class Evaluator : ParserBase
    {

        class ExpressionObject
        {
            public string Val1 { get; set; }
            public string Val2 { get; set; }
            public string Val3 { get; set; }
        }

        public Dictionary<string, object> GetStringValue(string expression)
        {
            string returnValue = null;
            ExpressionsLexer lexer = new ExpressionsLexer(new AntlrInputStream(GetCharStream(expression)));
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            ExpressionsParser expressionsParser = new ExpressionsParser(tokenStream);
            ExpressionsParser.ParseContext tree = expressionsParser.parse();
            
            ParseTreeWalker walker = new ParseTreeWalker();
            ExpressionLoader loader = new ExpressionLoader();
            walker.Walk(loader, tree);

            var dictionary = loader.GetMap();
            return dictionary;
        }

    }
}
