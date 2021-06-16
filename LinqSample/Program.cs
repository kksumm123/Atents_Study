using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Sample 1
            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;
            // = scoreQuery.Where(score => score > 80);

            // Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }
            // Output: 97 92 81
            #endregion

            #region Sample 2
            IEnumerable<int> highScoresQuery =
                from score in scores
                where score > 80
                orderby score descending
                select score;
            // = highScoresQuery.Where(x => x > 80).OrderByDescending(x => x);
            #endregion

            #region Sample 3
            IEnumerable<string> highScoresQuery2 =
                from score in scores
                where score > 80
                orderby score descending
                select $"This score is {score}";

            highScoresQuery2 = scores.Where(x => x > 80)
                .OrderByDescending(x => x)
                .Select(x => $"the score is {x}");
            #endregion

        }
    }
}
