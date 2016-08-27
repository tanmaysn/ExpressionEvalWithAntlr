using System.IO;

namespace ExpressionEvalWithAntlr
{
    public class ParserBase
    {
        public MemoryStream GetCharStream()
        {
            Write("Write an array");
            string readLine = Read();

            MemoryStream mem = new MemoryStream();
            StreamWriter writer = new StreamWriter(mem);
            writer.Write(readLine);
            writer.Flush();
            mem.Position = 0;
            return mem;
        }

        public MemoryStream GetCharStream(string input)
        {
            MemoryStream mem = new MemoryStream();
            StreamWriter writer = new StreamWriter(mem);
            writer.Write(input);
            writer.Flush();
            mem.Position = 0;

            return mem;
        }

        public static void Write(string message)
        {
            //Console.WriteLine(message);
        }

        protected string Read()
        {
            return Input;
        }

        public string Input { get; set; }
    }
}