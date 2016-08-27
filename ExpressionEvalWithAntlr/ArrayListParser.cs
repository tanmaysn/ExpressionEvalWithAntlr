using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using ExpressionEvalWithAntlr.Implementation;

namespace ExpressionEvalWithAntlr
{
    public class ArrayListParser : ParserBase
    {
        public string ParseToString(string args)
        {
            IParseTree context;
            ArrayInitParser parser = Parse(args, out context);
            Write(context.ToStringTree(parser));
           
            return context.ToStringTree(parser);
        }

        private ArrayInitParser Parse(string args, out IParseTree context)
        {
            Input = args;
            MemoryStream mem = GetCharStream();

            ICharStream input = new AntlrInputStream(mem);
            ArrayInitLexer lexer = new ArrayInitLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            ArrayInitParser parser = new ArrayInitParser(tokens);

            context = parser.init();
            return parser;
        }

        public string Walk(string args)
        {
            IParseTree context;

            var parsed = Parse(args, out context);
            ParseTreeWalker walker = new ParseTreeWalker();
            walker.Walk(new ShortToUnicodeString(), context);
            string read = Consoler.Read();
            return read;

        }
    }
}
