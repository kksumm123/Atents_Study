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

            #region Sample 4
            // 샘플4 먼지 못봄...
            #endregion


            #region Sample 5
            List<int> numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            IEnumerable<int> filteringQuery =
                from num in numbers
                where num < 3 || num > 7
                select num;

            filteringQuery = numbers.Where(x => x < 3 || x > 7);
            #endregion

            #region Sample 6
            string[] groupingQuery =
                { "carrots", "cabbage", "broccoli", "beans", "barley" };
            IEnumerable<IGrouping<char, string>> queryFoodGroups =
                from item in groupingQuery
                group item by item[0];

            var result = groupingQuery.GroupBy(x => x[0]);
            foreach (IGrouping<char, string> item in result)
            {
                Console.WriteLine($"{item.Key}");
            }
            #endregion
            #region Sample
            #endregion
            #region Sample
            #endregion
            #region Sample
            #endregion
            #region Sample
            #endregion
            #region Sample
            #endregion
            #region Sample
            #region Sample
            #endregion
            #endregion
        }
    }
}
