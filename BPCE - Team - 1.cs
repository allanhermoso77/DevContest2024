using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpContestProject
{
    class Program
    {
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
            int countLines = 0;
            string newLine = string.Empty;
            string line;
            while ((line = Console.ReadLine()) != null) {
                 if (countLines > 0)
                 {
                     int half = line.Length / 2;
                     
                     int countHalf = 0;
                     foreach (char c in line.Substring(0, half))
                     {
                         char newChar = c;
                         if (c != line[(line.Length - countHalf) - 1])
                         {
                             newChar = replaceCharacter(c);
                         }
                
                         newLine = newLine + newChar;
                         countHalf++;
                     }
                 }                
                 
                 if(newLine != string.Empty)
                 {
                     if ((line.Length % 2) == 0)
                     {
                         newLine = newLine + Reverse(newLine);
                     }
                     else
                     {
                         newLine = newLine + line[newLine.Length] + Reverse(newLine);
                     }
                     Console.WriteLine(newLine);
                 }
                     
                 newLine = string.Empty;
                 countLines++;
            }

            // Vous pouvez aussi effectuer votre traitement ici après avoir lu toutes les données 
        }
    }
}
