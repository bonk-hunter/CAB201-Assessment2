namespace Assessment2_CAB201;

/// <summary>
/// RESPONSIBILITY: Runs the logged-in menu loop for a user.
/// </summary>
public abstract class UserMenu
{
    protected readonly User user;

    protected UserMenu(User user)
    {
        this.user = user;
    }

    protected abstract string Title { get; }

    protected abstract List<MenuOption> GetExtraOptions();

    private List<MenuOption> GetOptions()
    {
        List<MenuOption> options = new()
        {
            new MenuOption("See my details", SeeMyDetails),
            new MenuOption("Change my password", ChangePassword)
        };
        options.AddRange(GetExtraOptions());
        return options;
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
}

public class RegularUserMenu : UserMenu
{
    public RegularUserMenu(User user) : base(user) { }

    protected override string Title => "Regular Listener Menu.";

    protected override List<MenuOption> GetExtraOptions() => new()
    {
        new MenuOption("View all podcasts", ViewAllPodcasts),
        new MenuOption("Listen to a podcast episode", ListenToEpisode),
        new MenuOption("Provide feedback on a podcast episode", ProvideFeedback)
    };

    protected void ViewAllPodcasts()
    {
        // TODO
    }

    protected void ListenToEpisode()
    {
        // TODO
    }

    protected void ProvideFeedback()
    {
        // TODO
    }
}

// TODO: check the spec - this assumes a premium listener gets everything a regular listener does
public class PremiumUserMenu : RegularUserMenu
{
    public PremiumUserMenu(User user) : base(user) { }

    protected override string Title => "Premium Listener Menu.";
}

public class PodcasterMenu : UserMenu
{
    public PodcasterMenu(User user) : base(user) { }

    protected override string Title => "Podcaster Menu.";

    protected override List<MenuOption> GetExtraOptions() => new()
    {
        new MenuOption("Create podcast", CreatePodcast),
        new MenuOption("View my podcasts", ViewMyPodcasts)
    };

    private void CreatePodcast()
    {
        // TODO
    }

    private void ViewMyPodcasts()
    {
        // TODO
    }
}
