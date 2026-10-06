namespace Assessment2_CAB201;

public static class UserFactory
{
    public static User? CreateUser(string choice)
    {
        return choice switch
        {
            "1" => new RegularUser(),
            "2" => new PremiumUser(),
            "3" => new Podcaster(),
            _ => null
        };
    }
}