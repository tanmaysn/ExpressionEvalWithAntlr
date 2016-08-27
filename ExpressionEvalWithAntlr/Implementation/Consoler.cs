using System.Text;

namespace ExpressionEvalWithAntlr.Implementation
{
    public class Consoler
    {
        static Consoler()
        {
            Text = new StringBuilder();
        }
        public static StringBuilder Text { get; private set; }

        public static void Write(string message, params string [] args)
        {
            Text.AppendFormat(message, args);
        }

        public static string Read()
        {
            return Text.ToString();
        }
    }
}