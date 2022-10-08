using System;
using System.Collections.Generic;
namespace ConsoleApp1.Lab1
{
    internal class Lab1
    {
        static void Main(string[] args)
        {
            var p1 = new CreateUser("jopka");
            var p2 = new CreateUser("jorgik");
            Console.WriteLine(p1.UserName + " " + p1.GamesCount + " " + p1.CurrentRating);
            Console.WriteLine(p2.UserName + " " + p2.GamesCount + " " + p2.CurrentRating);
        }

         class CreateUser
        {
            public string UserName {get;}
            public int  GamesCount {get;}
            public  int CurrentRating {get;}
            
            public CreateUser(string name)
            {
                UserName = name;
                GamesCount = 0;
                CurrentRating = 100;

            }
        }
        
         
         
         
            
            public class GetStats
            {
                
            }
        
    }
}
