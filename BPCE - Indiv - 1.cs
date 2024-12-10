bpce indiv 2

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
            int countLines = 0;
            int countBobsled = 0;
            string bobsled = "....";
            while ((line = Console.ReadLine()) != null) {
                
                if (countLines > 0)
                {
                    var splitBobsled = line.Split(bobsled);
                    countBobsled = countBobsled + (splitBobsled.Count() - 1);
                }
                
                countLines++;
                
            }

            Console.WriteLine(countBobsled); 
        }
    }
}
