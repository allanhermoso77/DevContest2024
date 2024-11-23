using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpContestProject
{
    class Program
    {
        static void Main(string[] args)
        {   string line;
            int tanksNumber = 0;
            int output = 0;
            while ((line = Console.ReadLine()) != null) {
                if(tanksNumber == 0){
                    int lineValue = Convert.ToInt32(line);
                    tanksNumber = lineValue;
                }
                else
                    {
                        var splitTanks = line.Split();
                        int maxTankValue = 0;
                        
                        foreach(string splitTankValue in splitTanks){
                            int tankValue = Convert.ToInt32(splitTankValue);
                            if(tankValue > maxTankValue)
                                maxTankValue = tankValue;
                        }
                        
                        foreach(string splitTankValue in splitTanks){
                            int tankValue = Convert.ToInt32(splitTankValue);
                            output += maxTankValue - tankValue;
                        }
                    }
            }           
            
            Console.WriteLine(output);
        }
    }
}
