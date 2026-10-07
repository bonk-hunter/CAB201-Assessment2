namespace Assessment2_CAB201;

public abstract class UserMenu
{
    protected readonly User user;

    protected UserMenu(User user)
    {
        this.user = user;
    }

    protected abstract string Title { get; }

    protected abstract List<MenuOptions> GetExtraOptions();
    
    private List<MenuOptions> GetOptions()
    {
        List<MenuOptions> options = new()
        {
            new MenuOptions("See my details", SeeMyDetails),
            new MenuOptions("Change my password", ChangePassword)
        };
    }

    public void RunUserMenu()
    {
        bool loggedIn = true;
        while (loggedIn)
        {
            List<MenuOption> options = GetOptions();
            options.Add(new MenuOption("Log out", () => loggedIn = false));   // always last

            CMDLineUI.DisplayString("");
            CMDLineUI.DisplayString(Title);
            for (int i = 0; i < options.Count; i++)
            {
                CMDLineUI.DisplayString($"{i + 1}. {options[i].Label}.");
            }
            CMDLineUI.DisplayString($"Please enter a choice between 1 and {options.Count}:");

            int choice;
            while (!int.TryParse(CMDLineUI.GetString(), out choice) || choice < 1 || choice > options.Count)
            {
                CMDLineUI.DisplayErrorAgain("Invalid choice");
            }
            options[choice - 1].Run();
        }
    }

    // Shared by every user type
    protected void SeeMyDetails()
    {
        CMDLineUI.DisplayString($"Name: {user.Username}");
        CMDLineUI.DisplayString($"Age: {user.Age}");
        CMDLineUI.DisplayString($"Mobile: {user.Mobile}");
        CMDLineUI.DisplayString($"Email: {user.Email}");
    }

    protected void ChangePassword()
    {
        CMDLineUI.DisplayString("Please enter your new password:");
        string password = CMDLineUI.GetString();
        while (!User.IsValidPassword(password))
        {
            CMDLineUI.DisplayErrorAgain("Invalid password");
            password = CMDLineUI.GetString();
        }
        user.Password = password;
    }

    public class RegularUserMenu : UserMenu
    
    {
        public override List<MenuOptions> GetExtraOptions => new()
        {
            new MenuOptions()
        }
    }

    public class PremiumUserMenu : UserMenu
    {
        public override List<MenuOptions> GetExtraOptions => new()
        {
            new MenuOptions()
        }
    }

    public class PodcasterMenu : UserMenu
    {
        public override List<MenuOptions> GetExtraOptions => new()
        {
            new MenuOptions
        }
    }
}