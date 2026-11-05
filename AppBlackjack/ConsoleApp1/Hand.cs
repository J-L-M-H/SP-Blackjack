namespace ConsoleApp1;

public class Hand
{
    public List<string> drawCardsUser = new List<string>();
    public List<string> drawnCardsDealer = new List<string>();

    public void DealerDraw(Deck deck)
    {
        string d = deck.DrawCard();
        drawnCardsDealer.Add(d);
    }
    
    public void UserDraw(Deck deck)
    {
       string c = deck.DrawCard();
        drawCardsUser.Add(c);
    }

    // Räknar värdet på korten.
    public int DealerCalculateTotal(List<string> Dhand)
    {
        int DealerTotal = 0;

        int DealerAces = 0;

        foreach (string h in Dhand)
        {
            if (h == "Ace")
            {
                DealerTotal += 11;
                DealerAces++;
            }

            else if(h== "Jack" || h=="Queen" || h=="King")
            {
                DealerTotal += 10;
            }
            else
            {
                DealerTotal += int.Parse(h);
            }

            //Ess som 1 när handen annars skulle gå över 21:
            while (DealerAces > 0 && DealerTotal > 21)
            {
                DealerTotal -= 10;
                DealerAces--;
            }
        }
       return DealerTotal;
    }
    public int UserCalculateTotal(List<string> Uhand)
    {
        int UserTotal = 0;
        int UserAces = 0;

        foreach (string h in Uhand)
        {
            if (h == "Ace")
            {
                UserTotal += 11;
                UserAces++;
            }

            else if (h == "Jack" || h == "Queen" || h == "King")
            {
                UserTotal += 10;
            }
            else
            {
                UserTotal += int.Parse(h);
            }

            //Ess som 1 när handen annars skulle gå över 21:
            while (UserAces > 0 && UserTotal > 21)
            {
                UserTotal -= 10;
                UserAces--;
            }
        }
        return UserTotal;
    }

    public bool userIsBlackJack(List<string> hand)
    {   
        if(UserCalculateTotal(hand) == 21)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool DealerIsBlackJack(List<string> hand)
    {
        if (DealerCalculateTotal(hand) == 21)
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
