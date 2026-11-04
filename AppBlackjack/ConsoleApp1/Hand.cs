namespace ConsoleApp1;

public class Hand
{
    public List<string> drawCardsUser = new List<string>();
    public List<string> drawnCardsDealer = new List<string>();

    Cards card = new Cards();
    public void DealerDraw()
    {
        string d = card.PickCard();
        drawnCardsDealer.Add(d);
    }
    
    public void UserDraw()
    {
       string c = card.PickCard();
        drawCardsUser.Add(c);
    }

    // Räknar värdet på korten.
    public int CalculateTotal(List<string> hand)
    {
        int total = 0;
        int aces = 0;

        foreach(string h in hand)
        {
            if(h == "Ace")
            {
                total=+11;
                aces++;
            }

            else if(h== "Jack" || h=="Queen" || h=="King")
            {
                total=+10;
            }
            else
            {
                total=+int.Parse(h);
            }

            //Ess som 1 när handen annars skulle gå över 21:
            while (aces > 0)
            {
                total=-10;
                aces--;
            }
        }
       return total;
    }

    public bool isBlackJack(List<string> hand)
    {   
        if(CalculateTotal(hand) == 21)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CardOnTable()
    {
        Console.Write("User: ");
        foreach (string card in drawCardsUser)
        {
            Console.WriteLine($"[{card}] ");

        }

        Console.Write("Dealer: ");
        foreach (string card in drawnCardsDealer)
        {
            Console.Write($"[{card}] ");
        }
    }

    public void ClearHand()
    {
        drawCardsUser.Clear();
        drawnCardsDealer.Clear();
    }
}
