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
            float lastArrive = 0;
            string lineString;
            string lastCountry = "";
            while ((lineString = Console.ReadLine()) != null) {
                
                if (countLines > 0)
                {
                    var splitLine = lineString.Split(" ");
                    string country = splitLine[0];
                    float distance = Convert.ToInt32(splitLine[1]);
                    float speed = Convert.ToInt32(splitLine[2]);
                
                    float arrive = distance / speed;
                
                    if (arrive > lastArrive)
                    {
                        lastArrive = arrive;
                        lastCountry = country;
                    }
                        
                }
                
                countLines++;
            }

            Console.WriteLine(lastCountry);
        }
    }
}
