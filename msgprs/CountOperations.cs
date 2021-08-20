using System;

namespace msgprs
{
    internal class CountOperations : IOperations
    {
        public string Id => "count";

        public void RunOptions(Options opts)
        {
            Console.WriteLine($"Thanks! Input file is {opts.InputFile}");
        }
    }
}