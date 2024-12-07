using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.CompilerServices;

/*******
* Read input from Console
* Use: Console.WriteLine to output your result to STDOUT.
* Use: Console.Error.WriteLine to output debugging information to STDERR;
*       
* ***/

namespace CSharpContestProject
{
    public class Line
    {
        public string Combination { get; set; }
        public double Score { get; set; }
        public double Median { get; set; }
    }

    class Program
    {
        public static List<Line> Lines = new List<Line>();

        // Function to find maximum
        // of the two variables
        static int max(int x, int y)
        {
            return (x > y) ? x : y;
        }

        // Function to find the longest
        // palindromic subString : Recursion
        static int longestPalindromic(String str,
                     int i, int j, int count)
        {

            // Base condition when the start
            // index is greater than end index
            if (i > j)
                return count;

            // Base condition when both the 
            // start and end index are equal
            if (i == j)
                return (count + 1);

            // Condition when corner characters
            // are equal in the String
            if (str[i] == str[j])
            {

                // Recursive call to find the
                // longest Palindromic String
                // by excluding the corner characters
                count = longestPalindromic(str, i + 1,
                          j - 1, count + 2);
                return max(count,
                max(longestPalindromic(str, i + 1, j, 0),
                 longestPalindromic(str, i, j - 1, 0)));
            }

            // Recursive call to find the 
            // longest Palindromic String
            // by including one corner 
            // character at a time
            return Math.Max(
               longestPalindromic(str, i + 1, j, 0),
               longestPalindromic(str, i, j - 1, 0));
        }

        // Function to find the longest 
        // palindromic sub-String
        static int longest_palindromic_substr(String str)
        {
            // Utility function call
            return longestPalindromic(str, 0,
                         str.Length - 1, 0);
        }

        static void Main(string[] args)
        {
            string[] arr = {   "30 30",
"....#....#......#........#....",
".....#...#......#........#....",
".....#....#......#........#...",
".....#....#......#........#...",
"......#....#.....#........#...",
"......#....#......#.......#...",
"......#....#......#........#..",
"......#.....#.....#........#..",
".......#....#......#.......#..",
".......#.A..#......#.......#..",
".......#.....#.....#.......#..",
".......#.....#.....#.......#..",
".......#.....#......#......#..",
".......#.....#......#......#..",
".......#......#.....#......#..",
".......#......#.....#......#..",
".......#......#.....#......#..",
".......#......#.....#......#..",
".......#......#.....#......#..",
".......#......#.....#.....#...",
".......#......#.....#.....#...",
"......#.......#.....#.....#...",
"......#.......#.....#.....#...",
"......#.......#.....#..B.#....",
"......#.......#.....#....#....",
".....#........#....#.....#....",
".....#........#....#....#.....",
".....#.......#.....#....#.....",
"....#........#.....#....#.....",
"....#........#....#....#......"};

            int countLines = 0;
            int blocoA = 0;
            int blocoB = 0;
            foreach (string lineString in arr)
            {
                if (countLines > 0)
                {
                    int countBlocos = 0;
                    char lastChar = '0';
                    foreach (char c in lineString)
                    {
                        if (c == '#' && lastChar != c) {
                            countBlocos++;
                        }
                        
                        if (c == 'A') 
                            blocoA = countBlocos;
                        if (c == 'B') 
                            blocoB = countBlocos;

                        lastChar = c;
                    }
                }
                countLines++;
            }

            int resultado = blocoB - blocoA;
            string strOutput = (resultado < 0 ? resultado * -1 : resultado).ToString();
            Console.WriteLine(strOutput);

                /*string[] arr = {   "5 6",
                                    "###.#",
                                    "###..",
                                    "..##.",
                                    "..#..",
                                    "..#..",
                                    "###..", };

                String str = "aaaabbaa";
                String strOutput = longest_palindromic_substr(arr[1]).ToString();

                // Function Call
                Console.WriteLine(strOutput);*/


            /*double sumScores = 0;
            foreach (string lineString in arr)
            {
                sumScores += line.Score;
            }

            double medianScore = findMedian(Lines.Select(x => x.Score).ToList());
            double averageScore = Lines.Select(x => x.Score).Average();
            double worstScore = Lines.Select(x => x.Score).Min();
            double bestScore = Lines.Select(x => x.Score).Max();*/

            }
    }


    /*public class Line
    {
        public string Combination { get; set; }
        public double Score { get; set; }
        public double Median { get; set; }
    }

    class Program
    {
        public static List<Line> Lines = new List<Line>();

        static void combinationUtil(double[] arr, double[] data,
                                    int start, int end,
                                    int index, int r)
        {
            if (index == r)
            {
                string combination = string.Empty;
                double score = 0;
                for (int j = 0; j < r; j++)
                {
                    combination += data[j] + " ";
                    score += data[j];
                }
                

                Lines.Add(new Line { 
                    Combination = combination,
                    Score = score / 9
                });
                return;
            }

            for (int i = start; i <= end &&
                      end - i + 1 >= r - index; i++)
            {
                data[index] = arr[i];
                combinationUtil(arr, data, i + 1,
                                end, index + 1, r);
            }
        }

        static void printCombination(double[] arr,
                                     int n, int r)
        {
            double[] data = new double[r];

            combinationUtil(arr, data, 0,
                            n - 1, 0, r);
        }

        static void Main(string[] args)
        {
            double[] arr = {   6.7,
                                4.2,
                                4.3,
                                7.0,
                                0.0,
                                2.8,
                                3.9,
                                1.3,
                                6.9,
                                6.0,
                                7.3,
                                3.2 };
            int r = 9;
            int n = arr.Length;
            printCombination(arr, n, r);

            double sumScores = 0;
            foreach (Line line in Lines)
            {
                sumScores += line.Score;
            }

            double medianScore = findMedian(Lines.Select(x => x.Score).ToList());
            double averageScore = Lines.Select(x => x.Score).Average();
            double worstScore = Lines.Select(x => x.Score).Min();
            double bestScore = Lines.Select(x => x.Score).Max();

        }

        public static double findMedian(List<double> arr)
        {
            arr.Sort();
            int mid = arr.Count / 2;
            double median = 0;
            if (mid % 2 != 0)
            {
                median = arr[mid];
            }
            else
            {
                median = (arr[mid - 1] + arr[mid]) / 2;
            }

            return median;
        }
    }*/
}
