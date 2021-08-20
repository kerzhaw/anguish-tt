using CommandLine;

namespace msgprs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parser.
                Default
                .ParseArguments<Options>(args)
                .WithParsed(RunOptions);
        }

        private static void RunOptions(Options opts)
        {
            if(opts.Count) {
                new CountOperations().RunOptions(opts);
            }
        }
    }
}
