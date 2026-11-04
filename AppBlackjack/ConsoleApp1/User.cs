
namespace ConsoleApp1;


public class User
{
    public string UserName { get; set; }
    public int Rounds { get; set; }
    public int  Balance { get; set; }
    public User(string username)
    {
        UserName = username;
        Rounds = 0;
        Balance = 100;
    }
}