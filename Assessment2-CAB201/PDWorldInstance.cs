namespace Assessment2_CAB201;

public class PDWorldInstance
{
    private User user;
    private Auth authentication;
    
    public string MainMenu()
    {
        string userChoice;
        Console.WriteLine("");
        Console.WriteLine("Main Menu.");
        Console.WriteLine("Please make a choice from the menu below.");
        Console.WriteLine("1. Log in as a registered user.");
        Console.WriteLine("2. Register as a new user.");
        Console.WriteLine("3. Exit.");
        Console.WriteLine("Please enter a choice between 1 and 3:");
        userChoice = Console.ReadLine();
        return userChoice;
    }

    public void Goodbye()
    {
        Console.WriteLine("See you on the next rotation.");
        Environment.Exit(0);
    }

    public void RegistrationMenu()
    {
        User sessionUser = new User();
        string userChoice;
        Console.WriteLine("");
        Console.WriteLine("Registration Menu.");
        Console.WriteLine("Please enter your user type.");
        Console.WriteLine("1. A regular listener.");
        Console.WriteLine("2. A premium listener.");
        Console.WriteLine("3. A podcaster.");
        Console.WriteLine("4. Please enter a choice between 1 and 3:");
        userChoice = Console.ReadLine();
        switch  (userChoice)
        {
            case "1":
                Console.WriteLine("Register as a regular listener.");
                sessionUser.set(1);
                break;
            case "2":
                Console.WriteLine("Register as a premium listener.");
                sessionUser.set(2);
                break;
            case "3":
                Console.WriteLine("Register as a podcaster.");
                sessionUser.set(3);
                break;
        }
        Console.WriteLine("Please enter your name:");
        sessionUser.set(Console.ReadLine());
        Console.WriteLine("Please enter your age between 18 and 99:");
        sessionUser.set(Console.ReadLine());
        Console.WriteLine("Please enter your mobile number:");
        sessionUser.set(Console.ReadLine());
        Console.WriteLine("Please enter your email:");
        sessionUser.set(Console.ReadLine());
        Console.WriteLine("Please enter your password:");
        Console.WriteLine("Your password must:");
        Console.WriteLine("- be at least 8 characters long");
        Console.WriteLine("- contain a number");
        Console.WriteLine("- contain a lowercase letter");
        Console.WriteLine("- contain a uppercase letter");
        sessionUser.set(Console.ReadLine());
        Console.WriteLine("Congratulations " + sessionUser.Name.get() + ". You have registered as a " + sessionUser.UserType.get() + ".");
    }

    public void LogInMenu()
    {
        
    }
    
}