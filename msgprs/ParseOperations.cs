using System.Text;
using System.Collections.Generic;
using System.IO;

namespace msgprs
{
    internal class ParseOperations : IOperations
    {
        private static readonly IReadOnlyDictionary<string, string> Levels = new Dictionary<string, string>
        {
            {"0",     "<f0eeaff>[ 0 ]<088> %0"},
            {"1",     "<fb1ff91>[ 1 ]<088> %0"},
            {"2",     "<fbfe062>[ 2 ]<088> %0"},
            {"3-4",   "<fcac13b>[ 3-4 ]<088> %0"},
            {"5-9",   "<fd09f1d>[ 5-9 ]<088> %0"},
            {"10-19", "<fd37c11>[ 10-19 ]<088> %0"},
            {"20-29", "<fcf561a>[ 20-29 ]<088> %0"},
            {"30+",   "<fc62828>[ 30+ ]<088> %0"},
        };

        private readonly TextWriter _writer;

        public ParseOperations(TextWriter writer)
        {
            _writer = writer;
        }

        private static string TransformMessage(string raw)
        {
            // You cleaved %1'{s?} %2 violently.
            // You hewed opponent's bodypart crudely.

            var builder = new StringBuilder(raw);
            builder.Replace("opponent's", "%1'{s?}");
            builder.Replace("bodypart", "%2");
            return builder.ToString();
        }

        public void RunOptions(Options opts)
        {
            using var inputFile = File.Open(opts.InputFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var reader = new StreamReader(inputFile);

            var lineInput = reader.ReadLine();

            while (!string.IsNullOrEmpty(lineInput))
            {
                var parts = lineInput.Split('=');
                if (parts.Length < 1) continue;

                var damage = parts[0].Trim();
                var message = parts[1].Trim();

                var damageTransformed = Levels[damage];
                var messageTransformed = TransformMessage(message);

                _writer.WriteLine($"#SUB {{{messageTransformed}}} {{{damageTransformed}}}");

                lineInput = reader.ReadLine();
            }
        }
    }
}