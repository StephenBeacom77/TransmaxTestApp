using System;

namespace TransmaxTestApp
{
    public class GradeScore
    {
        public GradeScore(string firstName, string lastName, int score, int index)
        {
            if (firstName == null)
            {
                throw new ArgumentNullException($"{nameof(firstName)} is not a valid value on line {index}. It must be a string and cannot be null.");
            }
            if (lastName == null)
            {
                throw new ArgumentNullException($"{nameof(lastName)} is not a valid value on line {index}. It must be a string and cannot be null.");
            }
            FirstName = firstName;
            LastName = lastName;
            Score = score;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Score { get; private set; }
    }
}
