namespace ConsoleApp1;

public class Program
{
    
    static void Main()
    {

        GameLogic g = new GameLogic();
        HighScore h = new HighScore();

        bool run = true;

        while (run)
        {
            
            Console.WriteLine("=== Blackjack ===");
            Console.WriteLine("1. Play");
            Console.WriteLine("2. Top list");
            Console.WriteLine("3. Rules");
            Console.WriteLine("4. Exit");

            Console.Write("Enter: ");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    g.StartGame();
                    break;

                case 2:
                    h.ShowHighscore();
                    break;

                case 3:
                    g.ShowRules();
                    break;

                case 4:
                    g.FinishGame();
                    run = false;
                    break;

                default:
                    Console.WriteLine("invalid input choose betwwen 1 and 4.");
                    break;
            }

            Console.WriteLine();
        }
    }

}