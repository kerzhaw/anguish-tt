using System.Threading.Tasks;
using CommandLine;

namespace msgprs
{
    internal class Program
    {
        private static Task Main(string[] args) =>
            Parser.Default.ParseArguments<Options>(args).WithParsedAsync(RunOptionsAsync);

        private static async Task RunOptionsAsync(Options opts)
        {
            if (opts.Count)
            {
                var operation = new CountOperations();
                await operation.RunOptionsAsync(opts);
            }
        }
    }
}
