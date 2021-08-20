using System.Threading.Tasks;
using System;

namespace msgprs
{
    internal class CountOperations : IOperations
    {
        public Task RunOptionsAsync(Options opts)
        {
            return Task.Run(() => Console.WriteLine($"Thanks! Input file is {opts.InputFile}"));
        }
    }
}