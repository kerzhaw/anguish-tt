using CommandLine;

namespace msgprs
{
    internal class Program
    {
        private static void Main(string[] args) =>
            Parser.Default.ParseArguments<Options>(args).WithParsed(RunOptions);

        private static void RunOptions(Options opts)
        {
            if (opts.Parse)
            {
                var operation = new ParseOperations();
                operation.RunOptions(opts);
            }
        }
    }
}
