namespace Assessment2_CAB201;

public class Menu
{
    
    Auth authenticator;
    
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
        CMDLineUI.DisplayString($"Registering as a {sessionUser.UserType.ToLower()}.");
        CMDLineUI.DisplayString("Please enter your name:");
        userName = CMDLineUI.GetString();
		while (!User.IsValidName(userName)) 
		{
			CMDLineUI.DisplayErrorAgain("Invalid name");
			userName = CMDLineUI.GetString();
		}
        CMDLineUI.DisplayString("Please enter your age between 18 and 99:");
        int age = int.Parse(CMDLineUI.GetString());
        while (!int.TryParse(CMDLineUI.GetString(), out age) || !User.IsValidAge(age))
        {
            CMDLineUI.DisplayErrorAgain("Invalid age");
			age = int.Parse(CMDLineUI.GetString());
        }
        sessionUser.Age = age;
        CMDLineUI.DisplayString("Please enter your mobile number:");
        string mobile = CMDLineUI.GetString();
        while (!User.IsValidMobile(mobile))
        {
            CMDLineUI.DisplayErrorAgain("Invalid mobile");
            mobile = CMDLineUI.GetString();
        }
        sessionUser.Mobile = mobile;
        CMDLineUI.DisplayString("Please enter your email:");
		string email = CMDLineUI.GetString();
        while (!User.IsValidEmail(email))
        {
            CMDLineUI.DisplayErrorAgain("Invalid email");
            email = CMDLineUI.GetString();
       	}
        sessionUser.Email = email;
        CMDLineUI.DisplayString("Please enter your password:");
        CMDLineUI.DisplayString("Your password must:");
        CMDLineUI.DisplayString("- be at least 8 characters long");
        CMDLineUI.DisplayString("- contain a number");
        CMDLineUI.DisplayString("- contain a lowercase letter");
        CMDLineUI.DisplayString("- contain an uppercase letter");
        string password = CMDLineUI.GetString();
        while (!User.IsValidPassword(password))
        {
            CMDLineUI.DisplayErrorAgain("Invalid password");
            password = CMDLineUI.GetString();
        }
        sessionUser.Password = password;
		        
        CMDLineUI.DisplayString($"Congratulations {sessionUser.Username}. You have registered as a {sessionUser.UserType}.");
        return sessionUser;
    }

    public User LogInMenu(Auth authenticator)
    {
        CMDLineUI.DisplayString("Log in Menu.");
        CMDLineUI.DisplayString("Please enter your email:");
        User? user = authenticator.FindByEmail(CMDLineUI.GetString());
        while (user == null)
        {
            CMDLineUI.DisplayErrorAgain("Email is not registered");
            user = authenticator.FindByEmail(CMDLineUI.GetString());
        }

        CMDLineUI.DisplayString("Please enter your password:");
        while (!user.CheckPassword(CMDLineUI.GetString()))
        {
            CMDLineUI.DisplayErrorAgain("Entered password does not match existing password");
        }
        CMDLineUI.DisplayString($"Welcome back {user.Username}.");
        UserMenu(user);
        return user;
    }

    public User UserMenu(User user)
    {
        CMDLineUI.DisplayString(user.UserType + " Menu");
        for(int i = 0; i < user.MenuOptions.Length; i++)
        {
            CMDLineUI.DisplayString($"{i+1}. {user.MenuOptions[i]}.");
        }
        CMDLineUI.DisplayString($"Please enter a choice between 1 and {user.MenuOptions.Length}.");
        
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