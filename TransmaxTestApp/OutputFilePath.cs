using System.IO;

namespace TransmaxTestApp
{
    public class OutputFilePath
    {
        public OutputFilePath(string inputFilePath)
        {
            FileInfo inputFileInfo = new FileInfo(inputFilePath);
            Value = inputFileInfo.DirectoryName + Path.DirectorySeparatorChar +
                inputFileInfo.Name.Replace(inputFileInfo.Extension, "-graded" + inputFileInfo.Extension);
        }

        public string Value { get; private set; }
    }
}
