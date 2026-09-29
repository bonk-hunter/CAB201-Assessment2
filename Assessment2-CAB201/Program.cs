using Assessment2_CAB201;

List<User> users = new List<User>();

Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+==");
Console.WriteLine("         Welcome to PodCastWorld!     ");
Console.WriteLine("      Podcasting all over the world.      ");
Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+==");

PDWorldInstance instance = new PDWorldInstance();
string userChoice = instance.MainMenu();
if (userChoice == "3")
{
    instance.Goodbye();
} else if (userChoice == "2")
{
    instance.RegistrationMenu();
} else if (userChoice == "1" && users.Count != 0)
{
    instance.LogInMenu();
}
