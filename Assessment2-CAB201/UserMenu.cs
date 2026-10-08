namespace Assessment2_CAB201;

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
            new MenuOption("See my details", user.SeeMyDetails()),
            new MenuOption("Change my password", user.ChangePassword())
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
    protected virtual void SeeMyDetails()
    {
        CMDLineUI.DisplayString($"Name: {user.Username}");
        CMDLineUI.DisplayString($"Age: {user.Age}");
        CMDLineUI.DisplayString($"Mobile phone number: {user.Mobile}");
        CMDLineUI.DisplayString($"Email: {user.Email}");
		CMDLineUI.DisplayString($"Episodes started: {user.GetEpisodesStarted()}");
		CMDLineUI.DisplayString($"Episodes completed: {user.GetEpisodesCompleted()}");
		CMDLineUI.DisplayString($"Total minutes listened: {user.GetTotalMinutesListened()}")
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
		public RegularUserMenu(User user) : base(user)
		protected override string Title => $"{user.UserType} Menu";
        public override List<MenuOption> GetExtraOptions => new()
        {
            new MenuOption()
        }
		options.AddRange(GetExtraOptions);
		
		protected override void SeeMyDetails()
		{
			base.SeeMyDetails();
			CMDLineUI.DisplayString($"Advertisements listened to: {user.GetAdvertisementsListenedTo()}");
		}
    }

    public class PremiumUserMenu : UserMenu
    {
		public PremiumUserMenu(User user) : base(user)
		protected override string Title => $"{user.UserType} Menu";

        protected override List<MenuOption> GetExtraOptions => new()
        {
            
        };
		options.AddRange(GetExtraOptions);

		protected override void SeeMyDetails()
		{
			base.SeeMyDetails();
			CMDLineUI.DisplayString($"Registration Date: {user.RegistrationDate.ToString()}");
			CMDLineUI.DisplayString($"Pay ID: {user.PayID}");
		}
    }

    public class PodcasterMenu : UserMenu
    {
		public PodcasterMenu(User user) : base(user)
		protected override string Title => $"{user.UserType} Menu";
        public override List<MenuOption> GetExtraOptions => new()
        {
            new MenuOption("Create podcast", NotImplemented),
			new MenuOption("View my podcasts", NotImplemented),
        }
		options.AddRange(GetExtraOptions);
    }
}