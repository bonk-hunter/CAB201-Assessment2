namespace Assessment2_CAB201;

public class PDWorldController
{
    private Menu menu = new Menu();
    private Auth authentication = new Auth();

    public void Run()
    {
        bool keepRunning = true;
        menu.DisplayHeader();
        while (keepRunning)
        {
            string userChoice = menu.MainMenu();
            if (userChoice == "3")
            {
                Goodbye();
                keepRunning = false;
            } else if (userChoice == "2")
            {
                authentication.Register(menu.RegistrationMenu());
            } else if (userChoice == "1")
            {
                if (!authentication.HasUsers)
                {
                    CMDLineUI.DisplayError("There are no people registered");
                }
                else
                {
                    User user = menu.LogInMenu(authentication);
                    UserMenuFactory.CreateUserMenu(user).RunUserMenu();
                }
            } else
            {
                CMDLineUI.DisplayErrorAgain("Invalid choice");
            }
        }
    }

    public void Goodbye()
    {
        CMDLineUI.DisplayString("See you on the next rotation.");
    }

}
