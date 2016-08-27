using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using ExpressionEvalWithAntlr.Implementation;

namespace ExpressionEvalWithAntlr.Calculator
{
    public class EvalVisitor: LabeledExprBaseVisitor<int>
    {
        IDictionary<string, int> memory = new Dictionary<String, int>();
        public override int VisitAssign(LabeledExprParser.AssignContext context)
        {
            string id = context.ID().GetText();
            int value = Visit(context.expr());
            memory.Add(id, value);
            return value;
        }

        public override int VisitPrintExpr(LabeledExprParser.PrintExprContext context)
        {
            int value = Visit(context.expr());
            Consoler.Write(value.ToString());
            return value;
        }

        public override int VisitInt(LabeledExprParser.IntContext context)
        {
            return int.Parse(context.INT().GetText());
        }

        public override int VisitId(LabeledExprParser.IdContext context)
        {
            string id = context.ID().GetText();
            if (memory.ContainsKey(id))
                return memory[id];
            
            return 0;
        }

        public override int VisitMulDiv(LabeledExprParser.MulDivContext context)
        {
            int left = Visit(context.expr(0));
            int right = Visit(context.expr(1));

            //Notes: what??
            if (context.op.Type == LabeledExprParser.MUL)
                return left*right;

            return left / right;
        }

        public override int VisitAddSub(LabeledExprParser.AddSubContext context)
        {
            int left = Visit(context.expr(0));
            int right = Visit(context.expr(1));

            //Notes: what??
            if (context.op.Type == LabeledExprParser.ADD)
                return left + right;

            return left - right;
        }

        public override int VisitParens(LabeledExprParser.ParensContext context)
        {
            return Visit(context.expr());
        }
    }
}