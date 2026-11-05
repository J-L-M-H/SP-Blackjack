namespace ConsoleApp1;

public class GameLogic
{
    private HighScore highscore;

    public GameLogic(HighScore score)
    {
        highscore = score;
    }
    // Variabler
    public bool close = false;

    public int currentBet = 0;

    public User player;

    public Deck deck = new Deck();
    public Cards cards = new Cards();


    public Hand hand = new Hand();



    public void StartGame()
    {
        Console.Write("Your name: ");

        close = false;

        string name = Console.ReadLine();

        if (name == "")
        {
            Console.WriteLine("Enter your name please");

            return;
        }
        player = new User(name);
        StartRound();
    }
    public void StartRound()
    {
        while (!close && player.Balance > 0)
        {


            if (player.Balance <= 0)
            {
                Console.WriteLine(
                    "You dont have enough balance");
                break;
            }

            Console.WriteLine($"""
                Current balance: {player.Balance} kr
                """);
            PlayRound();
        }
    }

     // Delar ut två kort till spelaren och dealern.
    public void InitialDrawCard()
    {
        hand.UserDraw(deck);
        hand.DealerDraw(deck);

        hand.UserDraw(deck);
        hand.CardOnTable();
        hand.DealerDraw(deck);
    }

     public void PlayRound()
    {

        Console.WriteLine($"How much do want to bet? Current balance: {player.Balance}");
        currentBet = int.Parse(Console.ReadLine());
        InitialDrawCard();
        if (hand.DealerCalculateTotal(hand.drawnCardsDealer) == 21 || hand.UserCalculateTotal(hand.drawCardsUser) == 21)
        {
            hand.CardOnTable();
            if (hand.DealerIsBlackJack(hand.drawnCardsDealer))
            {
                Console.WriteLine("Dealer has blackjack! You lose your bet.");
                player.Balance -= currentBet;
            }
            else if (hand.userIsBlackJack(hand.drawCardsUser))
            {
                Console.WriteLine("\nYou have blackjack! You win 1.5 times your bet.");
                player.Balance += (int)(currentBet * 1.5);
            }
        }
        else
        {
            // Spelaren drar kort eller stannar.
            while (true)
            {
                Console.WriteLine("Draw card or stay? (d/s): ");
                string choice = Console.ReadLine();
                if (choice == "d")
                {
                    hand.UserDraw(deck);
                    if(cards.availableDeck.Count < 16)
        {
            deck.Shuffle();
        }
                    Console.WriteLine($"You drew a {hand.drawCardsUser.Last()}");
                    if (hand.UserCalculateTotal(hand.drawCardsUser) > 21)
                    {
                        Console.WriteLine("\nYou went over 21! You lose your bet.");
                        player.Balance -= currentBet;
                        break;
                    }
                }
                else if (choice == "s")
                {
                    // Dealern drar kort tills summan är minst 17.
                    Console.WriteLine($"Dealer reveals a {hand.drawnCardsDealer.Last()}");
                    while (hand.DealerCalculateTotal(hand.drawnCardsDealer) < 17)
                    {
                        hand.DealerDraw(deck);
                        if(cards.availableDeck.Count < 16)
        {
            deck.Shuffle();
        }
                        Console.WriteLine($"Dealer drew a {hand.drawnCardsDealer.Last()}");
                    }
                    int dealerTotal = hand.DealerCalculateTotal(hand.drawnCardsDealer);
                    int userTotal = hand.UserCalculateTotal(hand.drawCardsUser);
                    if (dealerTotal > 21 || userTotal > dealerTotal)
                    {
                        Console.WriteLine("You win! You get your bet back and win the same amount.");
                        player.Balance += currentBet;
                        break;
                    }
                    else if (userTotal < dealerTotal)
                    {
                        Console.WriteLine("Dealer wins! You lose your bet.");
                        player.Balance -= currentBet;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("It's a tie! Your bet is returned.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose 'd' to draw or 's' to stay.");
                }
            }
        }
        hand.ClearHand();
        player.Rounds++;
        Console.WriteLine("Enter 'y' to play again or 'n' to exit the game.");
        string answer = Console.ReadLine();

        if (answer == "n")
        {
            close = true;
        }
        else if (answer == "y")
        {

            close = false;
        }
        else
        {
            Console.WriteLine("invalid input");
            close = true;
        }//need to move second half into own method to avoid code duplicatio

    if (close == true)
    {
        FinishGame();
    }
    Console.WriteLine($"{ deck.cardsavailable }");
    StartRound();
    }

    public void ShowRules()
    {
        Console.WriteLine("\n=== SPELREGLER ===");

        Console.WriteLine("1. Spelaren lägger en insats.");
        Console.WriteLine();

        Console.WriteLine("""
            2. Spelaren och dealern får två kort var. Spelarens kort är uppvända.
            Dealern har ett uppvänt och ett dolt kort.
            """);
        Console.WriteLine();

        Console.WriteLine("""
            3. Blackjack betyder ess och ett kort värt 10 som de två första korten. Har någon blackjack avgörs rundan direkt.
             Har båda det blir det oavgjort. Om endast spelaren får blackjack vinner spelaren en bonusvinst motsvarande 1,5 gånger insatsen.
             Eventuella decimaler avrundas nedåt till närmaste hela belopp. Har bara dealern det förlorar spelaren sin insats.
            """);
            
        Console.WriteLine();

        Console.WriteLine("""
            4. Annars väljer spelaren om hen vill dra ett kort eller stanna.
             Det upprepas tills spelaren stannar, när 21 eller går över 21. Går spelaren över 21 förlorar denne direkt.
            """);
            
        Console.WriteLine();

        Console.WriteLine("""
            
            5. Dealern vänder upp sitt dolda kort och drar kort tills summan är minst 17. Då stannar dealern.
             Går dealern över 21 vinner spelaren.
            
            """);
            
        Console.WriteLine();

        Console.WriteLine("""
            
            6. Handen närmast 21 vinner. Vid vinst får spelaren tillbaka sin insats samt en lika stor summa i vinst.
             Är det lika är det oavgjort och insatsen går tillbaka. Vinner dealern förlorar spelaren sin insats.
            
            """);
            
        Console.WriteLine();

        Console.WriteLine("PENGAR OCH KORTLEK");
        Console.WriteLine();

        Console.WriteLine("- Spelaren börjar med 100 kr.");
        Console.WriteLine();

        Console.WriteLine("- Minsta insats är 1 kr och högsta är hela saldot.");
        Console.WriteLine();

        Console.WriteLine("- Spelet slutar när spelaren väljer att sluta eller när pengarna är slut.");
        Console.WriteLine();

        Console.WriteLine("- Spelet använder en vanlig lek med 52 kort som blandas vid start.");
        Console.WriteLine();

        Console.WriteLine("- Är det färre än 15 kort kvar innan en ny runda skapas en ny blandad lek.");
        Console.WriteLine();
    }


    // Rensar korten inför nästa runda.
    public void RoundReset()
    {
        hand.ClearHand();
    }

    // Avslutar spelet.
    public void FinishGame()
    {
        Console.WriteLine("\n=== The game is over ===");

        Console.WriteLine(
            $"Player: {player.UserName}");

        Console.WriteLine(
            $"Rounds: {player.Rounds}");

        Console.WriteLine(
            $"Balance: {player.Balance} kr");

        // Spara resultatet "public User player" i topplistan.
    highscore.AddHighscore(player);
    }


}