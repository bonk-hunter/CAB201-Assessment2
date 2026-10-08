namespace Assessment2_CAB201;

public static class UserMenuFactory
{
    public static UserMenu CreateUserMenu(User user) => user switch
    {
        PremiumUser premium => PremiumUserMenu(premium),
        RegularUser regular => RegularUserMenu(regular),
        Podcaster podcaster => PodcasterMenu(podcaster),
        _ => throw new ArgumentException($"No menu for {user.UserType}")
    };
} 
