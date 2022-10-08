using System;
using System.Collections.Generic;
namespace ConsoleApp1.Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var usO = new CreateUser("ANTON");
            var UsT = new CreateUser("STEPAN");
            Console.WriteLine(usO.UserName + " " + usO.GamesCount + " " + usO.CurrentRating);
            Console.WriteLine(UsT.UserName + " " + UsT.GamesCount + " " + UsT.CurrentRating);
        }

        public class CreateUser
        {
            public string UserName { get; }
            public int GamesCount { get; }
            public int CurrentRating { get; }

            public CreateUser(string name)
            {
                UserName = name;
                GamesCount = 0;
                CurrentRating = 100;

            }
        }

        public class Game
        {
            public readonly CreateUser usO;
            public readonly CreateUser UsT;
            
        }
    





    public class GetStats
            {
                
            }
        
    }
}
