namespace Assessment2_CAB201;

public class PDWorldInstance
{
    private User user;
    private Auth authentication;
    
    public string startMenu()
    {
        string userChoice;
        Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+==");
        Console.WriteLine("         Welcome to PodCastWorld!     ");
        Console.WriteLine("      Podcasting all over the world.      ");
        Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+==");
        Console.WriteLine("");
        Console.WriteLine("Main Menu.");
        Console.WriteLine("Please make a choice from the menu below.");
        Console.WriteLine("1. Log in as a registered user.");
        Console.WriteLine("2. Register as a new user.");
        Console.WriteLine("3. Exit");
        Console.WriteLine("Please enter a choice between 1 and 3:");
        userChoice = Console.ReadLine();
        if (userChoice == "3")
        {
            goodbye();
        }
        return userChoice;
    }

    public void goodbye()
    {
        Console.WriteLine("See you on the next rotation.");
        Environment.Exit(0);
    }
}