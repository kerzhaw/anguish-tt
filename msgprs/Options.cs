using CommandLine;

namespace msgprs
{
    internal class Options
    {
        [Option('p', "parse", Required = false)]
        public bool Parse { get; set; }

        [Option('i', "inputFile", Required = true)]
        public string InputFile { get; set; }
    }
}
