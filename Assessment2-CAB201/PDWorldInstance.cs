namespace Assessment2_CAB201;

using CLIUI;

public class PDWorldInstance
{
    private User user;
    private Auth authentication;
    
    public string MainMenu()
    {
        string userChoice;
        CLIUI.DisplayString("");
        CLIUI.DisplayString("Main Menu.");
        CLIUI.DisplayString("Please make a choice from the menu below.");
        CLIUI.DisplayString("1. Log in as a registered user.");
        CLIUI.DisplayString("2. Register as a new user.");
        CLIUI.DisplayString("3. Exit.");
        CLIUI.DisplayString("Please enter a choice between 1 and 3:");
        userChoice = Console.ReadLine();
        return userChoice;
    }

    public void Goodbye()
    {
        CLIUI.DisplayString("See you on the next rotation.");
        Environment.Exit(0);
    }

    public void RegistrationMenu()
    {
        User sessionUser = new User();
        string userChoice;
        CLIUI.DisplayString("");
        CLIUI.DisplayString("Registration Menu.");
        CLIUI.DisplayString("Please enter your user type.");
        CLIUI.DisplayString("1. A regular listener.");
        CLIUI.DisplayString("2. A premium listener.");
        CLIUI.DisplayString("3. A podcaster.");
        CLIUI.DisplayString("4. Please enter a choice between 1 and 3:");
        userChoice = Console.ReadLine();
        switch  (userChoice)
        {
            case "1":
                CLIUI.DisplayString("Register as a regular listener.");
                sessionUser.set(1);
                break;
            case "2":
                CLIUI.DisplayString("Register as a premium listener.");
                sessionUser.set(2);
                break;
            case "3":
                CLIUI.DisplayString("Register as a podcaster.");
                sessionUser.set(3);
                break;
        }
        CLIUI.DisplayString("Please enter your name:");
        sessionUser.set(Console.ReadLine());
        CLIUI.DisplayString("Please enter your age between 18 and 99:");
        sessionUser.set(Console.ReadLine());
        CLIUI.DisplayString("Please enter your mobile number:");
        sessionUser.set(Console.ReadLine());
        CLIUI.DisplayString("Please enter your email:");
        sessionUser.set(Console.ReadLine());
        CLIUI.DisplayString("Please enter your password:");
        CLIUI.DisplayString("Your password must:");
        CLIUI.DisplayString("- be at least 8 characters long");
        CLIUI.DisplayString("- contain a number");
        CLIUI.DisplayString("- contain a lowercase letter");
        CLIUI.DisplayString("- contain a uppercase letter");
        sessionUser.set(Console.ReadLine());
        CLIUI.DisplayString("Congratulations " + sessionUser.Name.get() + ". You have registered as a " + sessionUser.UserType.get() + ".");
    }

    public void LogInMenu()
    {
        
    }
    
}