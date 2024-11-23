using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpContestProject
{
    class Program
    {
        static void Main(string[] args)
        {   
            string line;
            int countLine = 0;
            int[] input = new int[2];
            string output = String.Empty;
            
            while ((line = Console.ReadLine()) != null) {
                input[countLine] = Convert.ToInt32(line);
                countLine++;
            }
            
            int result = (input[0] * input[0]) - (input[1] * input[1]);
            Console.WriteLine(result); 
        }
    }
}
