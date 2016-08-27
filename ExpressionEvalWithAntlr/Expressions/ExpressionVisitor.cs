using System.Collections.Generic;
using Antlr4.Runtime.Tree;

namespace ExpressionEvalWithAntlr.Expressions
{
    public class ExpressionLoader : ExpressionsBaseListener
    {
        Dictionary<string, object> map = new Dictionary<string, object>();

        //public override void EnterValue(ExpressionsParser.ValueContext context)
        //{
        //    Debug.Write("Enter value" + context.GetToken(1, 1));
        //    base.EnterValue(context);
        //}

        public override void EnterComparisonExpression(ExpressionsParser.ComparisonExpressionContext context)
        {
            map.Add(context.left.GetText(), context.right.GetText());
            base.EnterComparisonExpression(context);
        }


        public override void EnterExpr(ExpressionsParser.ExprContext context)
        {
            string expressionText = context.GetText();
            ITerminalNode[] node = context.GetTokens(0);
            map.Add(expressionText, node);
        }

        public override void ExitExpr(ExpressionsParser.ExprContext context)
        {
            string expressionText = context.GetText();
            ITerminalNode[] node = context.GetTokens(0);
            map.Add(expressionText, node);
            //base.ExitExpr(context);
        }

        public Dictionary<string, object> GetMap()
        {
            return map;
        }
    }
}
