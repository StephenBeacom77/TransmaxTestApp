using System;

namespace TransmaxTestApp
{
    public class GradeScoreFactory
    {
        public GradeScore Create(string line, int index)
        {
            if (line == null)
            {
                throw new ArgumentNullException($"{nameof(line)} {index} is not a valid score. It cannot be null.");
            }

            string[] parts = line.Split(',');
            if (parts == null || parts.Length != 3)
            {
                throw new ArgumentException($"{nameof(line)} {index} is not a valid score. It must have the format \"First Name, Last Name, Score\".");
            }
            string firstName = parts[0].Trim();
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException($"{nameof(firstName)} is not a valid value on line {index}. It must be a string and cannot be empty.");
            }
            string lastName = parts[1].Trim();
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException($"{nameof(lastName)} is not a valid value on line {index}. It must be a string and cannot be empty.");
            }
            int score;
            bool isValidScore = int.TryParse(parts[2].Trim(), out score);
            if (!isValidScore)
            {
                throw new ArgumentException($"{nameof(score)} is not a valid value on line {index}. It must be an integer.");
            }
            return new GradeScore(firstName, lastName, score, index);
        }
    }
}
