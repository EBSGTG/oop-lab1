using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Sockets;

namespace ConsoleApp1.Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var playerOne = new GameAccount("ANTON");
            var playerTwo = new GameAccount("STEPAN");
            var gameone = new Game(playerOne, playerTwo, 10); 
            gameone.Start();
            Console.WriteLine(playerOne.GetStats());
        }

        public class GameAccount
        {
            public string UserName { get; }
            public int GamesCount { get; }

            public int GameId
            {
                get
                {
                    int gameId = 0;
                    foreach (var t in allRatingCalculations)
                    {
                        gameId += t.GameIndex;
                    }
            
                    return gameId;
                }
                
            }

            public int RatingPoints
            {
                get
                {
                    int ratingPoints = 100;
                    foreach (var t in allRatingCalculations)
                    {
                        ratingPoints = t.Rating;
                    }
                    return ratingPoints;
                }
            }

            public void GameStart(int rating, string status, int gameId)
            {
                var gameStart = new RatingCalculation(rating, status, "Start of game", GameId);
                allRatingCalculations.Add(gameStart);
            }

            public void WinGame(string opponentName, int rating)
            {
                var winGame = new RatingCalculation( rating, "Win", opponentName, 1);
                allRatingCalculations.Add(winGame);
            }

            public void LoseGame(string opponentName, int rating)
            {
                if (RatingPoints - rating < 1)
                {
                    throw new InvalidOperationException("Game rating cant be less than 1");
                }
                var loseGame = new RatingCalculation(rating, "Lose", opponentName, 1);
                allRatingCalculations.Add(loseGame);
            }

            public string GetStats()
            {
                var rep = new System.Text.StringBuilder();
                int gameId = 0;
                int ratingPoints = 1000;
                rep.AppendLine("|Player|\t\t|CurrentRating|\\t\t|Status|\t\t|OpponentName|\t\t|GameRating|\t\t|GameId|");
                foreach (var t in allRatingCalculations)
                {
                    ratingPoints += t.Rating;
                    gameId += t.GameIndex;
                    rep.AppendLine($"|{UserName}|\t\t|{ratingPoints}| \t\t|{t.Status}|\t\t|{t.OpponentName}|\t\t|{t.Rating}|\t\t|{GameId}|");
                }

                return rep.ToString();
            }
            public GameAccount(string name)
            {
                UserName = name;
                GamesCount = 0;
                GameStart(10,"Game",10);
            }
            
            
            private List<RatingCalculation> allRatingCalculations = new List<RatingCalculation>();
           
            
        }
        
        public class RatingCalculation
        {
            public int Rating { get; }
            public string Status { get; }
            public string OpponentName { get; }
            public int GameIndex { get; }

            public RatingCalculation(int rating, string status, string opponentName, int gameIndex)
            {
                Rating = rating;
                Status = status;
                OpponentName = opponentName;
                GameIndex = gameIndex;
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

            public void Start()
            {
                var random = new Random();
                int oor = random.Next(0, 2);
                if (oor != 0)
                {
                    PlayerOne.WinGame(PlayerTwo.UserName, Rating);
                    PlayerTwo.LoseGame(PlayerOne.UserName, Rating);
                }
                else {
                    PlayerTwo.WinGame(PlayerOne.UserName, Rating);
                    PlayerOne.LoseGame(PlayerTwo.UserName,Rating);
                }

            }
            
        }
    }
}
