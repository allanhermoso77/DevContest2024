using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        
        static void Main(string[] args)
        {   
            string line;
            int countLine = 0;
            double[] input = new double[12];
            string output = String.Empty;

            while ((line = Console.ReadLine()) != null) {
                input[countLine] = Convert.ToDouble(line);
                countLine++;
            }
            
            int r = 9;
            int n = input.Length;
            printCombination(input, n, r);
            
            double sumScores = 0;
            foreach (Line lineScore in Lines)
            {
                sumScores += lineScore.Score;
            }
            
            double medianScore = findMedian(Lines.Select(x => x.Score).ToList());
            double averageScore = Lines.Select(x => x.Score).Average();
            double worstScore = Lines.Select(x => x.Score).Min();
            double bestScore = Lines.Select(x => x.Score).Max();
            
            Console.WriteLine(worstScore);
            Console.WriteLine(averageScore);
            Console.WriteLine(medianScore);
            Console.WriteLine(bestScore); 
        }
    }
}
