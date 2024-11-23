using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpContestProject
{
    public class Line
    {
        public string Values { get; set; }
        public int TotalOverlaps { get; set; }
    }
    
    class Program
    {
        public static List<Line> Lines = new List<Line>();

        static string GetLetter(int number)
        {
            if (number == 0) return "A";
            if (number == 1) return "B";
            if (number == 2) return "C";
            if (number == 3) return "D";
            if (number == 4) return "E";
            return "";
        }
                
        static int LongestSuffixPrefix(string strSuffix, string strPrefix)
        {
            string s = strPrefix.Replace(" ", "") + " " + strSuffix.Replace(" ", "");
            int res = 0;
            int n = s.Length;

            // Iterating over all possible lengths
            for (int len = 1; len < n; len++)
            {

                // Starting index of proper prefix
                int i = 0;

                // Starting index of suffix
                int j = s.Length - len;

                bool flag = true;

                // Comparing proper prefix with suffix of length 'len'
                for (int k = 0; k < len; k++)
                {
                    if (s[i + k] != s[j + k])
                    {
                        flag = false;
                        break;
                    }
                }

                // If they match, update the result
                if (flag)
                    res = len;
            }

            return res;
        }
        
        static void Mutate(string[] Nums, int Idx = 0)
        {
            if (Idx == Nums.Length)
            {
                //Console.WriteLine(string.Join(',', Nums));
        
                int totalOverlap = 0;
                for (int i = 0; i < 4; i++)
                {
                    totalOverlap = totalOverlap + LongestSuffixPrefix(Nums[i], Nums[i + 1]);
                }
        
                //Console.WriteLine("Total overlap" + totalOverlap);
                Line line = new Line()
                {
                    Values = string.Join(',', Nums),
                    TotalOverlaps = totalOverlap
                };
        
                Lines.Add(line);
        
                return;
            }
            for (var i = Idx; i < Nums.Length; i++)
            {
                (Nums[Idx], Nums[i]) = (Nums[i], Nums[Idx]);
                Mutate(Nums, Idx + 1);
                (Nums[Idx], Nums[i]) = (Nums[i], Nums[Idx]);
            }
        }
        
        static void Main(string[] args)
        {   string line;
            int countLine = 0;
            string[] input = new string[5];
            string output = String.Empty;
            List<Line> listLines = new List<Line>();

            while ((line = Console.ReadLine()) != null) {
                input[countLine] = line;
                countLine++;
            }
            
            Mutate(new string[] { input[0], input[1], input[2], input[3], input[4] });
            
            var maxLine = Lines.OrderByDescending(x => x.TotalOverlaps).FirstOrDefault()?.Values;
            
            string[] values = maxLine.Split(',');
            
            foreach(string valueSplit in values)
            {
                for (int c = 0; c < input.Length; c++)
                    if (valueSplit == input[c]) output += GetLetter(c);
            }
            
            Console.WriteLine(output);
        }
    }
}
