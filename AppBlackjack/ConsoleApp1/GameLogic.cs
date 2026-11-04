namespace ConsoleApp1;

public class GameLogic
{
    // Variabler
    private bool close = false;

    private int currentBet = 0;

    private User player;

    private Deck deck;

    private Hand hand;

    private Highscore highscore;


    public void StartGame()
    {
        Console.Write("Your name: ");

        string name = Console.ReadLine();

        if (name == "")
        {
            Console.WriteLine("Enter your name please");

            return;
        }
         player = new User(name);
         while (!close && player.Balance > 0)
        {
            PlayRound();

            if (player.Balance <= 0)
            {
                Console.WriteLine(
                    "\nYou dont have balance");
                break;
            }

            Console.Write("\nPlay again? (y/n): ");

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
            }
        }

        FinishGame();
    }

     // Delar ut två kort till spelaren och dealern.
    public void InitialDrawCard()
    {
        hand.UserDraw();
        hand.DealerDraw();

        hand.UserDraw();
        hand.DealerDraw();
    }

     public void PlayRound()
    {
        return;
    }

    public void ShowRules()
    {
        Console.WriteLine("\n=== SPELREGLER ===");

        Console.WriteLine("1. Spelaren lägger en insats.");
        Console.WriteLine();

        Console.WriteLine("2. Spelaren och dealern får två kort var. Spelarens kort är uppvända. Dealern har ett uppvänt och ett dolt kort.");
        Console.WriteLine();

        Console.WriteLine("3. Blackjack betyder ess och ett kort värt 10 som de två första korten. Har någon blackjack avgörs rundan direkt. Har båda det blir det oavgjort. Om endast spelaren får blackjack vinner spelaren en bonusvinst motsvarande 1,5 gånger insatsen. Eventuella decimaler avrundas nedåt till närmaste hela belopp. Har bara dealern det förlorar spelaren sin insats.");
        Console.WriteLine();

        Console.WriteLine("4. Annars väljer spelaren om hen vill dra ett kort eller stanna. Det upprepas tills spelaren stannar, når 21 eller går över 21. Går spelaren över 21 förlorar denne direkt.");
        Console.WriteLine();

        Console.WriteLine("5. Dealern vänder upp sitt dolda kort och drar kort tills summan är minst 17. Då stannar dealern. Går dealern över 21 vinner spelaren.");
        Console.WriteLine();

        Console.WriteLine("6. Handen närmast 21 vinner. Vid vinst får spelaren tillbaka sin insats samt en lika stor summa i vinst. Är det lika är det oavgjort och insatsen går tillbaka. Vinner dealern förlorar spelaren sin insats.");
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

        // Spara resultatet "private User player" i topplistan.
        highscore.AddHighscore(player);
    }


}