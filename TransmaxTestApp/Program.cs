using System;
using System.Collections.Generic;
using System.IO;

namespace TransmaxTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("grade-scores");
            Console.WriteLine("------------");
            try
            {
                InputFilePath inputFilePath = new InputFilePath(args);

                GradeScoreFactory factory = new GradeScoreFactory();
                List<GradeScore> scores = new List<GradeScore>();

                using (StreamReader inputFileReader = new StreamReader(inputFilePath.Value, true))
                {
                    int index = 1;
                    string inputLine;

                    while ((inputLine = inputFileReader.ReadLine()) != null)
                    {
                        scores.Add(factory.Create(inputLine, index));
                        index++;
                    }
                }
                scores.Sort(new GradeScoreComparer());

                // create output file name by naming convention
                OutputFilePath outputFilePath = new OutputFilePath(inputFilePath.Value);

                // write sorted scores to the output file and the console
                using (StreamWriter outputFileWriter = new StreamWriter(outputFilePath.Value))
                {
                    foreach (GradeScore score in scores)
                    {
                        outputFileWriter.WriteLine($"{score.FirstName}, {score.LastName}, {score.Score}");
                        Console.WriteLine($"{score.FirstName}, {score.LastName}, {score.Score}");
                    }
                }
                Console.WriteLine($"Finished: created {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
            finally
            {
                Console.WriteLine("------------");
            }
        }

    }
}
