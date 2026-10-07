namespace Assessment2_CAB201;

public static class UserMenuFactory
{
    public static UserMenu CreateUserMenu(User user) => user switch
    {
        PremiumUser => new PremiumUserMenu(user),
        RegularUser => new RegularUserMenu(user),
        Podcaster => new PodcasterMenu(user),
        _ => throw new ArgumentException($"No menu for {user.UserType}")
    };
}
