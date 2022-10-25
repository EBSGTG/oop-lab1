using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Sockets;
using System.Xml;

namespace ConsoleApp1.Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var playerOne = new GameAccount("Bender");
            var playerTwo = new GameAccount("STEPAN");
            var gameone = new Game(playerOne, playerTwo, 10); 
            gameone.PowerCheck();
            gameone.PowerCheck();
            gameone.PowerCheck();
            gameone.PowerCheck();
            gameone.PowerCheck();
            Console.WriteLine(playerOne.GetStats());
            Console.WriteLine(playerTwo.GetStats());
        }

        public class GameAccount
        {
            public string UserName { get; }
            public int GamesCount { get; }

            public int GameId
            {
                get
                {
                    int gameId = 1;
                    foreach (var t in allOperations)
                    {
                        gameId += t.GameId;
                    }
            
                    return gameId;
                }
                
            }

            public int CurrentRating
            {
                get
                {
                    int currentRating = 1000;
                    foreach (var t in allOperations)
                    {
                        currentRating += t.Rating;
                    }
                    return currentRating;
                }
            }
            
            public void WinGame(string opponentName, int rating)
            {
                var winGame = new Operation( rating, "Win", opponentName, 1);
                allOperations.Add(winGame);
            }

            public void LoseGame(string opponentName, int rating)
            {
                if (CurrentRating - rating < 1)
                {
                    throw new InvalidOperationException("Game rating cant be less than 1");
                }
               
                var loseGame = new Operation(-rating, "Lose", opponentName, 1);
                allOperations.Add(loseGame);
            }

            public string GetStats()
            {
                var rep = new System.Text.StringBuilder();
                int gameId = 0;
                int currentRating = 1000;
                rep.AppendLine("|Player|\t|CurrentRating|\t\t|Status|\t|OpponentName|\t|GameRating|\t|GameId|");
                foreach (var t in allOperations)
                {
                    currentRating += t.Rating;
                    gameId += t.GameId;
                    rep.AppendLine($"|{UserName}|\t|{currentRating}|\t\t\t|{t.Status}|\t\t|{t.OpponentName}|\t|{t.Rating}|\t\t|{gameId}|");
                }

                return rep.ToString();
            }
            public GameAccount(string name)
            {
                UserName = name;
                GamesCount = 0;
            }
            
            
            
            private List<Operation> allOperations = new List<Operation>();
           
            
        }
        
        public class Operation
        {
            public int Rating { get; }
            public string Status { get; }
            public string OpponentName { get; }
            public int GameId { get; }

            public Operation(int rating, string status, string opponentName, int gameIndex)
            {
                Rating = rating;
                Status = status;
                OpponentName = opponentName;
                GameId = gameIndex;
            }
        }
        
        public class Game
        {
            public readonly GameAccount PlayerOne;
            public readonly GameAccount PlayerTwo;
            
            
            public  int Rating {get;}

            public Game(GameAccount p1, GameAccount p2, int rating)
            {
                
                if (rating <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(rating),"incorrect rating");
                }

                PlayerOne = p1;
                PlayerTwo = p2;
                Rating = rating;

            }

            public void PowerCheck()
            {
                var r = new Random();
                int power1 = r.Next(1, 999);
                int power2 = r.Next(1, 999);
                Console.WriteLine("\nGame #"+PlayerOne.GameId +" for "+ Rating + "pts");
                if (power1 > power2)
                {
                    PlayerOne.WinGame(PlayerTwo.UserName, Rating);
                    PlayerTwo.LoseGame(PlayerOne.UserName, Rating);
                    Console.WriteLine(PlayerOne.UserName  + " " +  power1 +" power " + " wins " + PlayerTwo.UserName +" "+power2 +" power ");
                }
                else {
                    Console.WriteLine(PlayerTwo.UserName  + " " +  power2 +" power " + " wins " + PlayerOne.UserName  +" "+ power1 +" power ");
                    PlayerTwo.WinGame(PlayerOne.UserName, Rating);
                    PlayerOne.LoseGame(PlayerTwo.UserName,Rating);
                }

            }
            
        }
    }
}

