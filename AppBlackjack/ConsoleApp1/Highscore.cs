
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ConsoleApp1;

public class HighScore
{
    // Property med get och set. Då kan System.Text.Json läsa och spara listan korrekt.
    public List<User> HighScoreList { get; set; } = new List<User>();

    public const string FileName = "highscores.json";

    public void ReadFromJson()
    {
        if (!File.Exists(FileName))
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

    public void AddHighscore(User user)
    {
        User result = new User(user.UserName);
        result.Balance = user.Balance;
        result.Rounds = user.Rounds;

        HighScoreList.Add(result);

        HighScoreList = HighScoreList
            .OrderByDescending(u => u.Balance)
            .Take(5)
            .ToList();

        SaveToJson();
    }

    public void SaveToJson()
    {
        string json = JsonSerializer.Serialize(
            HighScoreList,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText(FileName, json);
    }

    public void ShowHighscore()
    {
        Console.WriteLine("\nTop list");

        if (HighScoreList.Count == 0)
        {
            Console.WriteLine("No data");
            return;
        }

        for (int i = 0; i < HighScoreList.Count; i++)
        {
            User user = HighScoreList[i];

            Console.WriteLine(
                $"{i + 1}. {user.UserName} {user.Balance} kr ({user.Rounds} rounds)"
            );
        }
    }
}
