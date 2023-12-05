using System;
using System.IO;
using System.Linq;

namespace AdventCalendar
{
    internal class Program2
    {
        static void Main()
        {
            var totalScore = 0;
            var game2score = 0;
            var gameNo = 0;
            string[] gameList = new string[198];

            StreamReader reader = new StreamReader("Docs/AdventCode4.txt");

            for(int i = 0; i < 198 ; i++)
            {
                gameList[i] = reader.ReadLine();
            }

            for(int i = 0; i < gameList.Length; i++)
            {
                var game = gameList[i];
                gameNo++;

                PlayGame(gameNo, ref game2score, game, 0, true, gameList);
            }

            Console.WriteLine(game2score);
        }

        public static void PlayGame(int gameNo, ref int game2score, string game, int totalMatches, bool isRootGame, string[] gameList)
        {
            game2score++;
            if ((totalMatches == 0 && !isRootGame) || gameNo >=198)
            {
                return;
            }
            else
            {
                totalMatches = 0;

                var winningCard = game.Split('|')[0].Trim().Split(':')[1].Trim();
                var myCard = game.Split('|')[1].Trim();

                var winningNums = winningCard.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var myNums = myCard.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var winningNum in winningNums)
                {
                    if (myNums.Contains(winningNum))
                    {
                        totalMatches++;
                    }
                }

                for (int  i = 1; i <= totalMatches; ++i)
                {
                    PlayGame(gameNo+i, ref game2score, gameList[gameNo+i-1], totalMatches, true, gameList);
                }
            }
        }
    }
}
