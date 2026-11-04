using System.Text.Json;

namespace ConsoleApp1;

public class Highscore
{
    public List<User> HighScoreList = new List<User>();

    private const string FileName = "highscores.json";


    public void ReadFromJson()
    {
        //Saknas filen eller är den trasig ska programmet ändå starta, med en tom topplista.
        if (!File.Exists(FileName))
        {
            HighScoreList = new List<User>();
            return;
        }
        else if(File.ReadAllText("highscores.json") == null)
        {
            HighScoreList = new List<User>();

            Console.WriteLine("The file is corrupted.");
        }
        //läses in Topplistan från JSON när programmet startar 
        else 
        {
            string jsonFile = File.ReadAllText(FileName);

            HighScoreList = JsonSerializer.Deserialize<List<User>>(jsonFile); //Deserialize omvandlar Json data to Plain text (string)
        }

    }

    //Topplistan visar de fem bästa resultaten, sorterade med högst slutsaldo först
     public void AddHighscore(User user)
    {
        User highestPlayers = new User(user.UserName){
            Balance = user.Balance,
            Rounds = user.Rounds
        };

        HighScoreList.Add(highestPlayers);

        HighScoreList = HighScoreList.OrderBy(u => u.Balance).Take(5).ToList();

        //Topplistan sparas i en JSON-fil 
        SaveToJson();
    }

    public void SaveToJson()
    {
        string json = JsonSerializer.Serialize(HighScoreList); //Serialize omvandlar string till json data

        File.WriteAllText(FileName, json);
    }

    public void ShowHighscore()
    {
        Console.WriteLine("\n Top list");
        
        if (HighScoreList.Count == 0)
        {
            Console.WriteLine("No data");
            return;
        }

        for (int i = 0; i < HighScoreList.Count; i++)
        {
            User user = HighScoreList[i];

            Console.WriteLine($"{i + 1}. {user.UserName} " +   $"{user.Balance} kr " +   $"({user.Rounds} rounds)");
        }

    }
        

}