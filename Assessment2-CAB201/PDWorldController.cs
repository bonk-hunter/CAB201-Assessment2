namespace Assessment2_CAB201;

public class PDWorldController
{
    private Menu menu = new Menu();
    
    private List<User> users = new List<User>();
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
            } else if (userChoice == "2")
            {
                users.Add(menu.RegistrationMenu());
            } else if (userChoice == "1" && users.Count != 0)
            {
                LogInMenu();
            }
        }
    }
    
    public void Goodbye()
    {
        CMDLineUI.DisplayString("See you on the next rotation.");
        Environment.Exit(0);
    }

    public void LogInMenu()
    {
        
    }
    
}
