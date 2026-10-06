namespace Assessment2_CAB201;

public static class UserMenuFactory
{
    public static UserMenu CreateUserMenu(User user) => user switch
    {
        PremiumUser => PremiumUserMenu(user),
        RegularUser => RegularUserMenu(user),
        Podcaster => PodcasterMenu(user),
        _ => throw new ArgumentException($"No menu for {user.UserType}")
    };
}