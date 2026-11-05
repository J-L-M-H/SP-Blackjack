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
    int dealerTotal = 0;
    int userTotal = 0;
    int userAces = 0;
    int dealerAces = 0;
    // Räknar värdet på korten.
    public int DealerCalculateTotal(List<string> Dhand)
    {
     

        foreach(string h in Dhand)
        {
            if (h == "Ace")
            {
                dealerTotal=+11;
                dealerAces++;
            }

            else if(h== "Jack" || h=="Queen" || h=="King")
            {
                dealerTotal=+10;
            }
            else
            {
                dealerTotal=+int.Parse(h);
            }

            //Ess som 1 när handen annars skulle gå över 21:
            while (dealerAces > 0 && dealerTotal > 21)
            {
                dealerTotal=-10;
                dealerAces--;
            }
        }
       return dealerTotal;
    }
    public int UserCalculateTotal(List<string> hand)
    {


        foreach (string h in hand)
        {
            if (h == "Ace")
            {
                userTotal = +11;
                userAces++;
            }

            else if (h == "Jack" || h == "Queen" || h == "King")
            {
                userTotal = +10;
            }
            else
            {
                userTotal = +int.Parse(h);
            }

            //Ess som 1 när handen annars skulle gå över 21:
            while (userAces > 0 && userTotal > 21)
            {
                userTotal = -10;
                userAces--;
            }
        }
        return userTotal;
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
        dealerTotal = 0;
        userTotal = 0;
        dealerAces = 0;
        userAces = 0;
    }
}
