namespace Assessment2_CAB201;

public interface User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string PlaceHolder { get; set; }
    public int Age { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
}

public class PremiumUser : User
{
    public Date RegistrationDate { get; set; }
    public PayID PayID { get; set; }
}