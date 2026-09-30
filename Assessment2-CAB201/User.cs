namespace Assessment2_CAB201;

public class User
{
    public string UserType { get; set; } = "";
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string PlaceHolder { get; set; } = "";
    public int Age { get; set; }
    public string Mobile { get; set; } = "";
    public string Email { get; set; } = "";
}

public class PremiumUser : User
{
    public DateTime RegistrationDate { get; set; }
    public string PayID { get; set; } = "";
}
