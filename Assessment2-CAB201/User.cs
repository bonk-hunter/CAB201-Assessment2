namespace Assessment2_CAB201;

public abstract class User
{
    public abstract string UserType { get; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public int Age { get; set; }
    public string Mobile { get; set; } = "";
    public string Email { get; set; } = "";
    
    public static bool IsValidAge(int age) => age >= 18 && age <= 99;

    public static bool IsValidPassword(string password) =>
        password.Length >= 8 &&
        password.Any(char.IsDigit) &&
        password.Any(char.IsLower) &&
        password.Any(char.IsUpper);
    
    public bool CheckPassword(string attempt) => Password == attempt;

    public override string ToString() => $"{Username} ({UserType})";
    
    public abstract string[] MenuOptions { get; }
}

public class PremiumUser : User
{
    public override string UserType => "premium listener";
    public DateTime RegistrationDate { get; set; }
    public string PayID { get; set; } = "";
    
    public override string[] MenuOptions => new[] { "Create podcast", "View my podcasts", "Log out" };
}

public class RegularUser : User
{
    public override string UserType => "regular listener";
    
    public override string[] MenuOptions => new[] { "Create podcast", "View my podcasts", "Log out" };
}

public class Podcaster : User
{
    public override string UserType => "podcaster";
    
    public override string[] MenuOptions => new[] { "Create podcast", "View my podcasts", "Log out" };
}
