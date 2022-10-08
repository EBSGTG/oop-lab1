namespace ConsoleApp1.Lab1
{
    internal class Lab1
    {
        

         class GameAccount
        {
            
             string UserName { get; set; }
             int GamesCount { get; set; }
             int CurrentRating { get; set; }


            public GameAccount(string name, int games, int rating)
            {
                UserName = name;
                GamesCount = games;
                CurrentRating = rating;
                
            }
            static void Main(string[] args)
            {
                GameAccount aw = new GameAccount("jopka", 0, 100);
                Console.WriteLine(aw.UserName + " " + aw.GamesCount + " " + aw.CurrentRating);
            }
            
            public class WinGame 
            {
                
            }

            public class LoseGame
            {
                
            }

            public class GetStats
            {
                
            }
        }
    }
}
