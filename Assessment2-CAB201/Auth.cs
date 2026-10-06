namespace Assessment2_CAB201;

public class Auth
{
    private readonly List<User> users = new();

    public bool HasUsers => users.Count > 0;

    public void Register(User user) => users.Add(user);

    public User? FindByEmail(string email) =>
        users.FirstOrDefault(u => u.Email == email);
}