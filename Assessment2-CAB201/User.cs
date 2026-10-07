namespace Assessment2_CAB201;

public abstract class User
{
    public abstract string UserType { get; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public int Age { get; set; }
    public string Mobile { get; set; } = "";
    public string Email { get; set; } = "";

    public static bool IsValidName(string name) =>
        !string.IsNullOrEmpty(name) &&
        !name.Any(char.IsDigit);
    
    public static bool IsValidAge(int age) => 
        age >= 18 && 
        age <= 99;

    public static bool IsValidEmail(string email)
    {
        int atSymbol = email.IndexOf('@');
        return atSymbol > 0 &&
               atSymbol < email.Length - 1 &&
               email.IndexOf('@', atSymbol + 1) == -1;
    }

    public static bool IsValidMobile(string mobile) =>
        mobile.Length == 10 &&
        mobile[0] == '0' &&
        mobile.All(char.IsDigit);

    public static bool IsValidPassword(string password) =>
        password.Length >= 8 &&
        password.Any(char.IsDigit) &&
        password.Any(char.IsLower) &&
        password.Any(char.IsUpper);
    
    public bool CheckPassword(string attempt) => Password == attempt;
    
}

public class PremiumUser : User
{
    public override string UserType => "Premium Listener";
    public string RegistrationDate { get; set; }
    public string PayID { get; set; } = "";

    public static bool IsValidRegistrationDate(string date) =>
        date == date.ToString(PDWorldConsts.DATEFORMAT);
    
    public override string[] MenuOptions => new[] { "Create podcast", "View my podcasts", "Log out" };
}

public class RegularUser : User
{
    public override string UserType => "Regular Listener";
    
    public override string[] MenuOptions => new[] { "See my details", "Change my password", "View all podcasts", "Listen to a podcast episode", "Provide feedback on a podcast episode","Log out" };
}

public class Podcaster : User
{
    public override string UserType => "Podcaster";
    
    public override string[] MenuOptions => new[] { "Create podcast", "View my podcasts", "Log out" };
}
