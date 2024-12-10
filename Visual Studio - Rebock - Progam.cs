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

        public static void Mutate (char[] Nums, int Idx = 0)
        {
            if (Idx == Nums.Length)
            {
                Console.WriteLine(string.Join(' ', Nums));
                return;
            }
            for (var i = Idx; i < Nums.Length; i++)
            {
                (Nums[Idx], Nums[i]) = (Nums[i], Nums[Idx]);
                Mutate(Nums, Idx + 1);
                (Nums[Idx], Nums[i]) = (Nums[i], Nums[Idx]);
            }
        }
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

        static char replaceCharacter(char str)
        {
            return str == '.' ? '#' : str;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void Main(string[] args)
        {
            string[] arr = {"10",
"X.X.X...X.",
"....X.....",
"X.X.X.....",
"......XX..",
"...X......",
"X.........",
"..X......X",
"X.X.XX.X..",
"XXXX......",
".....X....",};

            int countLines = 0;
            int countBobsled = 0;
            string bobsled = "....";
            foreach (string line in arr)
            {
                if (countLines > 0)
                {
                    var splitBobsled = line.Split(bobsled);
                    countBobsled = countBobsled + (splitBobsled.Count() - 1);
                }

                countLines++;
            }

            Console.WriteLine(countBobsled);

            /*int countLines = 0;
            string newLine = string.Empty;
            foreach (string lineString in arr)
            {
                if (countLines > 0)
                {
                    int half = lineString.Length / 2;
                    
                    int countHalf = 0;
                    foreach (char c in lineString.Substring(0, half))
                    {
                        char newChar = c;
                        if (c != lineString[(lineString.Length - countHalf) - 1])
                        {
                            newChar = replaceCharacter(c);
                        }

                        newLine = newLine + newChar;
                        countHalf++;
                    }
                }                
                
                if(newLine != string.Empty)
                {
                    if ((lineString.Length % 2) == 0)
                    {
                        newLine = newLine + Reverse(newLine);
                    }
                    else
                    {
                        newLine = newLine + lineString[newLine.Length] + Reverse(newLine);
                    }
                    Console.WriteLine(newLine);
                }
                    
                newLine = string.Empty;
                countLines++;
            }*/

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
