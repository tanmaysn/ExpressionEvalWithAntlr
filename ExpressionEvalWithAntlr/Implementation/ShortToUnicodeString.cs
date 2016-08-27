namespace ExpressionEvalWithAntlr.Implementation
{
    public class ShortToUnicodeString: ArrayInitBaseListener
    {
        public override void EnterInit(ArrayInitParser.InitContext context)
        {
            Consoler.Write("\"");
        }

        public override void ExitInit(ArrayInitParser.InitContext context)
        {
            Consoler.Write("\"");
        }

        public override void EnterValue(ArrayInitParser.ValueContext context)
        {
            int value = int.Parse(context.INT().GetText());
            Consoler.Write(value.ToString("\\u%04x"));
        }
    }
}
