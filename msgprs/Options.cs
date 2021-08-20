using CommandLine;

namespace msgprs
{
    internal class Options
    {
        [Option('c', "count", Required = false)]
        public bool Count { get; set; }

        [Option('i', "inputFile", Required = true)]
        public string InputFile { get; set; }
    }
}
