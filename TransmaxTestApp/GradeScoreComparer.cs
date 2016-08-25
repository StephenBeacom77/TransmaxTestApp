using System.Collections.Generic;

namespace TransmaxTestApp
{
    public class GradeScoreComparer : IComparer<GradeScore>
    {
        public int Compare(GradeScore x, GradeScore y)
        {
            if (y == null)
            {
                if (x == null)
                {
                    return 0;
                }
                return -1;
            }
            else
            {
                if (x == null)
                {
                    return 1;
                }
                int result = y.Score.CompareTo(x.Score);
                if (result != 0)
                {
                    return result;
                }
                result = x.LastName.CompareTo(y.LastName);
                if (result != 0)
                {
                    return result;
                }
                return x.FirstName.CompareTo(y.FirstName);
            }
        }
    }
}
