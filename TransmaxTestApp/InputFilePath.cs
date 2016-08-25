using System;

namespace TransmaxTestApp
{
    public class InputFilePath
    {
        public InputFilePath(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException($"Only 1 argument is required to specify the input file but {args.Length} arguments have been specified.");
            }
            Value = args[0];
        }

        public string Value { get; private set; }
    }
}
