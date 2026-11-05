
namespace ConsoleApp1;

public class Deck
{
    private Cards cards = new Cards();

    public int cardsavailable
    {
        get { return cards.availableDeck.Count; }
    }

    public string DrawCard()
    {
        return cards.PickCard();
    }

    public void Shuffle()
    {
        cards = new Cards();
    }
}
