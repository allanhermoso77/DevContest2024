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
            int countLines = 0;
            int blockA = 0;
            int blockB = 0;
            
            string line;
            while ((line = Console.ReadLine()) != null) {
                if (countLines > 0)
                {
                    int countBlocks = 0;
                    char lastChar = '0';
                    foreach (char c in line)
                    {
                        if (c == '#' && lastChar != c) {
                            countBlocks++;
                        }
                        
                        if (c == 'A') 
                            blockA = countBlocks;
                        if (c == 'B') 
                            blockB = countBlocks;
                
                        lastChar = c;
                    }
                }
                countLines++;
            }

            int diff = blockB - blockA;
            string strOutput = (diff < 0 ? diff * -1 : diff).ToString();
            Console.WriteLine(strOutput);
        }
    }
}
