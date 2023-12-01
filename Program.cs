using System;
using System.Collections.Generic;
using System.IO;

namespace AdventCalendar
{
    internal class Program
    {
        static void Main()
        {
            string line;
            int lineCount = 0;
            int sum = 0;
            int combinedValue;

            StreamReader reader = new StreamReader("Docs/AdventCode1.txt");

            line = reader.ReadLine();
            while(line != null)
            {
                lineCount++;
                char[] charString = line.ToCharArray();
                combinedValue = combineFirstAndLastNumber(charString);
                sum += combinedValue;
                line = reader.ReadLine();
            }

            reader.Close();
            
            Console.WriteLine(sum);
        }

        public static int combineFirstAndLastNumber(char[] line)
        {
            int firstNum = 0;
            int lastNum = 0;
            string potentialNumber = "";

            bool firstDigitFound = false;

            foreach(char c in line)
            {
                if (char.IsDigit(c))
                {
                    if (!firstDigitFound)
                    {
                        firstNum = c - 48;
                        firstDigitFound = true;
                    }
                    lastNum = c-48;
                    potentialNumber = "" + c;
                }
                else
                {
                    potentialNumber += c;
                    if(isNumber(potentialNumber) > 0)
                    {
                        if (!firstDigitFound)
                        {
                            firstNum = isNumber(potentialNumber);
                            firstDigitFound = true;
                        }
                        lastNum = isNumber(potentialNumber);
                        potentialNumber = "" + c;
                    }
                }
            }

            return firstNum*10 + lastNum;
        }

        public static int isNumber(string line)
        {
            var keys = new Dictionary<string, int>(){
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }
            };

            foreach (var key in keys)
            {
                if(line.Contains(key.Key))
                {
                    return key.Value;
                }
            }
            return 0;
        }
    }
}
