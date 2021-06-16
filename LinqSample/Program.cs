using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSample
{
    #region Sample Program1
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        #region Sample 1
    //        // Specify the data source.
    //        int[] scores = new int[] { 97, 92, 81, 60 };

    //        // Define the query expression.
    //        IEnumerable<int> scoreQuery =
    //            from score in scores
    //            where score > 80
    //            select score;
    //        // = scoreQuery.Where(score => score > 80);

    //        // Execute the query.
    //        foreach (int i in scoreQuery)
    //        {
    //            Console.Write(i + " ");
    //        }
    //        // Output: 97 92 81
    //        #endregion

    //        #region Sample 2
    //        IEnumerable<int> highScoresQuery =
    //            from score in scores
    //            where score > 80
    //            orderby score descending
    //            select score;
    //        // = highScoresQuery.Where(x => x > 80).OrderByDescending(x => x);
    //        #endregion

    //        #region Sample 3
    //        IEnumerable<string> highScoresQuery2 =
    //            from score in scores
    //            where score > 80
    //            orderby score descending
    //            select $"This score is {score}";

    //        highScoresQuery2 = scores.Where(x => x > 80)
    //            .OrderByDescending(x => x)
    //            .Select(x => $"the score is {x}");
    //        #endregion

    //        #region Sample 4
    //        // 샘플4 먼지 못봄...
    //        #endregion


    //        #region Sample 5
    //        List<int> numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
    //        IEnumerable<int> filteringQuery =
    //            from num in numbers
    //            where num < 3 || num > 7
    //            select num;

    //        filteringQuery = numbers.Where(x => x < 3 || x > 7);
    //        #endregion

    //        #region Sample 6
    //        string[] groupingQuery =
    //            { "carrots", "cabbage", "broccoli", "beans", "barley" };
    //        IEnumerable<IGrouping<char, string>> queryFoodGroups =
    //            from item in groupingQuery
    //            group item by item[0];

    //        var result = groupingQuery.GroupBy(x => x[0]);
    //        #endregion

    //        #region Sample 7
    //        List<int> numbers1 = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
    //        List<int> numbers2 = new List<int>() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };
    //        // Query #4.
    //        double average = numbers1.Average();

    //        // Query #5.
    //        IEnumerable<int> concatenationQuery = numbers1.Concat(numbers2);
    //        #endregion

    //        #region Sample 8
    //        Student.QueryHighScores(1, 90);

    //        // Keep the console window open in debug mode.
    //        Console.WriteLine("Press any key to exit");
    //        Console.ReadKey();
    //        #endregion
    //    }
    //    public class Student
    //    {
    //        #region data
    //        public enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear };

    //        public string FirstName { get; set; }
    //        public string LastName { get; set; }
    //        public int Id { get; set; }
    //        public GradeLevel Year;
    //        public List<int> ExamScores;

    //        protected static List<Student> students = new List<Student>
    //{
    //    new Student {FirstName = "Terry", LastName = "Adams", Id = 120,
    //        Year = GradeLevel.SecondYear,
    //        ExamScores = new List<int> { 99, 82, 81, 79}},
    //    new Student {FirstName = "Fadi", LastName = "Fakhouri", Id = 116,
    //        Year = GradeLevel.ThirdYear,
    //        ExamScores = new List<int> { 99, 86, 90, 94}},
    //    new Student {FirstName = "Hanying", LastName = "Feng", Id = 117,
    //        Year = GradeLevel.FirstYear,
    //        ExamScores = new List<int> { 93, 92, 80, 87}},
    //    new Student {FirstName = "Cesar", LastName = "Garcia", Id = 114,
    //        Year = GradeLevel.FourthYear,
    //        ExamScores = new List<int> { 97, 89, 85, 82}},
    //    new Student {FirstName = "Debra", LastName = "Garcia", Id = 115,
    //        Year = GradeLevel.ThirdYear,
    //        ExamScores = new List<int> { 35, 72, 91, 70}},
    //    new Student {FirstName = "Hugo", LastName = "Garcia", Id = 118,
    //        Year = GradeLevel.SecondYear,
    //        ExamScores = new List<int> { 92, 90, 83, 78}},
    //    new Student {FirstName = "Sven", LastName = "Mortensen", Id = 113,
    //        Year = GradeLevel.FirstYear,
    //        ExamScores = new List<int> { 88, 94, 65, 91}},
    //    new Student {FirstName = "Claire", LastName = "O'Donnell", Id = 112,
    //        Year = GradeLevel.FourthYear,
    //        ExamScores = new List<int> { 75, 84, 91, 39}},
    //    new Student {FirstName = "Svetlana", LastName = "Omelchenko", Id = 111,
    //        Year = GradeLevel.SecondYear,
    //        ExamScores = new List<int> { 97, 92, 81, 60}},
    //    new Student {FirstName = "Lance", LastName = "Tucker", Id = 119,
    //        Year = GradeLevel.ThirdYear,
    //        ExamScores = new List<int> { 68, 79, 88, 92}},
    //    new Student {FirstName = "Michael", LastName = "Tucker", Id = 122,
    //        Year = GradeLevel.FirstYear,
    //        ExamScores = new List<int> { 94, 92, 91, 91}},
    //    new Student {FirstName = "Eugene", LastName = "Zabokritski", Id = 121,
    //        Year = GradeLevel.FourthYear,
    //        ExamScores = new List<int> { 96, 85, 91, 60}}
    //};
    //        #endregion

    //        // Helper method, used in GroupByRange.
    //        protected static int GetPercentile(Student s)
    //        {
    //            double avg = s.ExamScores.Average();
    //            return avg > 0 ? (int)avg / 10 : 0;
    //        }

    //        public static void QueryHighScores(int exam, int score)
    //        {
    //            var highScores = from student in students
    //                             where student.ExamScores[exam] > score
    //                             select new { Name = student.FirstName, Score = student.ExamScores[exam] };

    //            foreach (var item in highScores)
    //            {
    //                Console.WriteLine($"{item.Name,-15}{item.Score}");
    //            }
    //        }
    //    }
    //}
    #endregion
    #region Sample Program2
    class MQ
    {
        // QueryMethhod1 returns a query as its value.
        IEnumerable<string> QueryMethod1(ref int[] ints)
        {
            var intsToStrings = from i in ints
                                where i > 4
                                select i.ToString();
            return intsToStrings;
        }

        // QueryMethod2 returns a query as the value of parameter returnQ.
        void QueryMethod2(ref int[] ints, out IEnumerable<string> returnQ)
        {
            var intsToStrings = from i in ints
                                where i < 4
                                select i.ToString();
            returnQ = intsToStrings;
        }

        static void Main()
        {
            MQ app = new MQ();

            int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // QueryMethod1 returns a query as the value of the method.
            var myQuery1 = app.QueryMethod1(ref nums);

            // Query myQuery1 is executed in the following foreach loop.
            Console.WriteLine("Results of executing myQuery1:");
            // Rest the mouse pointer over myQuery1 to see its type.
            foreach (string s in myQuery1)
            {
                Console.WriteLine(s);
            }

            // You also can execute the query returned from QueryMethod1
            // directly, without using myQuery1.
            Console.WriteLine("\nResults of executing myQuery1 directly:");
            // Rest the mouse pointer over the call to QueryMethod1 to see its
            // return type.
            foreach (string s in app.QueryMethod1(ref nums))
            {
                Console.WriteLine(s);
            }

            IEnumerable<string> myQuery2;
            // QueryMethod2 returns a query as the value of its out parameter.
            app.QueryMethod2(ref nums, out myQuery2);

            // Execute the returned query.
            Console.WriteLine("\nResults of executing myQuery2:");
            foreach (string s in myQuery2)
            {
                Console.WriteLine(s);
            }

            // You can modify a query by using query composition. A saved query
            // is nested inside a new query definition that revises the results
            // of the first query.
            myQuery1 = from item in myQuery1
                       orderby item descending
                       select item;

            // Execute the modified query.
            Console.WriteLine("\nResults of executing modified myQuery1:");
            foreach (string s in myQuery1)
            {
                Console.WriteLine(s);
            }

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    #endregion
}
