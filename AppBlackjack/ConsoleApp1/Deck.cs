namespace ConsoleApp1;

public class Deck
{
     private Cards cards = new Cards();

    public int cardsavailable
    {
        get { return cards.availableDeck.Count; }
    }


    public void Shuffle()
    {
        Random rand = new Random();

        for(int i= cards.availableDeck.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i+1);

            string temp = cards.availableDeck[i];

            cards.availableDeck[i] = cards.availableDeck[j];

            cards.availableDeck[j] = temp;
        }
    }


    
}