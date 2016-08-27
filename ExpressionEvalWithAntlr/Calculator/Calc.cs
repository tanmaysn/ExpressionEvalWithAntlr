using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ExpressionEvalWithAntlr.Calculator
{
    public class Calc: ParserBase
    {
        public int Main(string args)
        {
            Input = args;
            ICharStream input = new AntlrInputStream(GetCharStream());

            LabeledExprLexer lexer = new LabeledExprLexer(input);
            CommonTokenStream stream = new CommonTokenStream(lexer);

            LabeledExprParser parser = new LabeledExprParser(stream);
            IParseTree tree = parser.prog();
            EvalVisitor eval = new EvalVisitor();
            return eval.Visit(tree);
        }
    }
}
