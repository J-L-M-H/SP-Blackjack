using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
namespace ConsoleApp1;

public class Cards

{

    public List<string> availableDeck { get; set; }

    public Cards()
    {
        availableDeck = JsonSerializer.Deserialize<List<string>>(File.ReadAllText("Cards.json")) ?? new List<string>();
    }

    public virtual string PickCard()
    {
        Random random = new Random();
        int index = random.Next(availableDeck.Count);
        string card = availableDeck[index];
        availableDeck.RemoveAt(index);
        return card;
    }
}