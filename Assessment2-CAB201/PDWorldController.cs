namespace Assessment2_CAB201;

public class PDWorldController
{
    private readonly Menu menu = new Menu();
    private readonly Auth authentication = new Auth();

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
            } else if (userChoice == "2")
            {
                authentication.Register(menu.RegistrationMenu());
            } else if (userChoice == "1")
            {
                menu.LogInMenu(authentication);
            }
        }
    }
    
    public void Goodbye()
    {
        CMDLineUI.DisplayString("See you on the next rotation.");
        Environment.Exit(0);
    }
    
}
