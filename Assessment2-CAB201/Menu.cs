using System.Runtime.InteropServices.JavaScript;

namespace Assessment2_CAB201;

public class Menu
{
    
    public void DisplayHeader()
    {
        Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+==");
        Console.WriteLine("         Welcome to PodCastWorld!     ");
        Console.WriteLine("      Podcasting all over the world.      ");
        Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+==");
    }

    public string MainMenu()
    {
        CMDLineUI.DisplayString("");
        CMDLineUI.DisplayString("Main Menu.");
        CMDLineUI.DisplayString("Please make a choice from the menu below.");
        CMDLineUI.DisplayString("1. Log in as a registered user.");
        CMDLineUI.DisplayString("2. Register as a new user.");
        CMDLineUI.DisplayString("3. Exit.");
        CMDLineUI.DisplayString("Please enter a choice between 1 and 3:");
        return Console.ReadLine() ?? "";
    }
    
    public User RegistrationMenu()
    {
        CMDLineUI.DisplayString("Registration Menu.");
        User sessionUser = ChooseUserType();
        CMDLineUI.DisplayString("Registering as a " + sessionUser.UserType+".");
        CMDLineUI.DisplayString("Please enter your name:");
        sessionUser.Username = CMDLineUI.GetString();
        CMDLineUI.DisplayString("Please enter your age between 18 and 99:");
        sessionUser.Age = CMDLineUI.GetInt();
        CMDLineUI.DisplayString("Please enter your mobile number:");
        sessionUser.Mobile = CMDLineUI.GetString();
        CMDLineUI.DisplayString("Please enter your email:");
        sessionUser.Email = CMDLineUI.GetString();
        CMDLineUI.DisplayString("Please enter your password:");
        CMDLineUI.DisplayString("Your password must:");
        CMDLineUI.DisplayString("- be at least 8 characters long");
        CMDLineUI.DisplayString("- contain a number");
        CMDLineUI.DisplayString("- contain a lowercase letter");
        CMDLineUI.DisplayString("- contain a uppercase letter");
        sessionUser.Password = CMDLineUI.GetString();
        CMDLineUI.DisplayString("Congratulations " + sessionUser.Username + ". You have registered as a " + sessionUser.UserType + ".");
        return sessionUser;
    }
    
    private User ChooseUserType()
    {
        while (true)
        {
            CMDLineUI.DisplayString("Please enter your user type.");
            CMDLineUI.DisplayString("1. A regular listener.");
            CMDLineUI.DisplayString("2. A premium listener.");
            CMDLineUI.DisplayString("3. A podcaster.");
            CMDLineUI.DisplayString("Please enter a choice between 1 and 3:");

            User? user = UserFactory.CreateUser(CMDLineUI.GetString());
            if (user != null)
            {
                return user;
            }
            CMDLineUI.DisplayErrorAgain("Invalid choice");
        }
    }
    
}