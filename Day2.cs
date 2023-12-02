using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace AdventCalendar
{
    internal class Program
    {
        static void Main()
        {
            string line;
            var gameID = 0;
            int sum = 0;
            int powerSum = 0;

            StreamReader reader = new StreamReader("Docs/AdventCode2.txt");

            line = reader.ReadLine();
            while(line != null)
            {
                gameID++;
                if (isValidGame(line))
                {
                    sum += gameID;
                }

                powerSum += Part2(line);

                line = reader.ReadLine();
            }
            reader.Close();
            
            Console.WriteLine("Part 1:" + sum);
            Console.WriteLine("Part 2:" + powerSum);
        }

        public static bool isValidGame(string line)
        {
            const int MaxRed = 12;
            const int MaxGreen = 13;
            const int MaxBlue = 14;

            //Get rid of the "Game ##:" part of the string
            string data = line.Split(':')[1].Trim();

            string[] sets = data.Split("; ");
            foreach(string set in sets)
            {
                string[] colors = set.Split(", ");
                foreach(string color in colors)
                {
                    if (color.Contains("red"))
                    {
                        int pulledRed = Int32.Parse(color.Split(' ')[0]);
                        if (pulledRed > MaxRed)
                        {
                            return false;
                        }
                    }
                    else if (color.Contains("blue"))
                    {
                        int pulledBlue = Int32.Parse(color.Split(' ')[0]);
                        if (pulledBlue > MaxBlue)
                        {
                            return false;
                        }
                    }
                    else if (color.Contains("green"))
                    {
                        int pulledGreen = Int32.Parse(color.Split(' ')[0]);
                        if (pulledGreen > MaxGreen)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static int Part2(string line)
        {
            //Get rid of the "Game ##:" part of the string
            string data = line.Split(':')[1].Trim();

            int MaxRed = 0;
            int MaxGreen = 0;
            int MaxBlue = 0;

            string[] sets = data.Split("; ");
            foreach (string set in sets)
            {
                string[] colors = set.Split(", ");
                foreach (string color in colors)
                {
                    if (color.Contains("red"))
                    {
                        int pulledRed = Int32.Parse(color.Split(' ')[0]);
                        if (pulledRed > MaxRed)
                        {
                            MaxRed = pulledRed;
                        }
                    }
                    else if (color.Contains("blue"))
                    {
                        int pulledBlue = Int32.Parse(color.Split(' ')[0]);
                        if (pulledBlue > MaxBlue)
                        {
                            MaxBlue = pulledBlue;
                        }
                    }
                    else if (color.Contains("green"))
                    {
                        int pulledGreen = Int32.Parse(color.Split(' ')[0]);
                        if (pulledGreen > MaxGreen)
                        {
                            MaxGreen = pulledGreen;
                        }
                    }
                }
            }
            return MaxRed*MaxGreen*MaxBlue;
        }
    }
}
