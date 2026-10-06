namespace Assessment2_CAB201;
using System.Globalization;


/// <summary>
/// The class will use the console to write and read user input and output. 
/// 
/// RESPONSIBILITY: User interaction.
/// </summary>
public class CMDLineUI
{


    /// <summary>
    /// Displays a blank line to the console screen.
    /// </summary>
    public static void DisplayString()
    {
        Console.WriteLine();
    }

    /// <summary>
    /// Displays a message to the console screen.
    /// </summary>
    /// <param name="msg">The message to display</param>
    public static void DisplayString(string msg)
    {
        Console.WriteLine(msg);
    }

    /// <summary>
    /// Displays an object's ToString method 
    /// </summary>
    /// <param name="msg">The message to display</param>
    public static void DisplayString(object o)
    {
        Console.WriteLine(o.ToString());
    }

    /// <summary>
    /// Displays an error message to the console screen.
    /// </summary>
    /// <param name="msg">The message to display</param>
    public static void DisplayError(string msg)
    {
        Console.WriteLine("#####");
        Console.WriteLine($"#Error - {msg}.");
        Console.WriteLine("#####");
    }

    /// <summary>
    /// Displays an error message to the console screen and asks the user to try again.
    /// </summary>
    /// <param name="msg">The message to display</param>
    public static void DisplayErrorAgain(string msg)
    {

        Console.WriteLine("#####");
        Console.WriteLine($"#Error - {msg}, please try again.");
        Console.WriteLine("#####");
    }


    /// <summary>
    /// Reads in a string from console and returns it
    /// </summary>
    /// <returns>A string representation of the users input</returns>
    public static string GetString()
    {
        string input = Console.ReadLine() ?? "";
        return input;
    }

    /// <summary>
    /// Reads in a string from console, converts it to a Int32
    /// and returns the converted value
    /// </summary>
    /// <returns>A Int32 representation of the users input</returns>
    public static int GetInt()
    {
        string input = Console.ReadLine() ?? "";
        int i = int.Parse(input);
        return i;
    }

    /// <summary>
    /// Print the message and the,
    /// Reads in a string from console, converts it to a Int32
    /// and returns the converted value
    /// </summary>
    /// <param name="msg">A message to print out</param>
    /// <returns>A Int32 representation of the users input</returns>      
    public static int GetInt(string msg)
    {
        Console.WriteLine($"{msg}");
        string input = Console.ReadLine() ?? "";
        int i = int.Parse(input);
        return i;
    }

    /// <summary>
    /// Reads in a string from console, converts it to a double
    /// and returns the converted value
    /// </summary>
    /// <returns>A double floating point representation of the users input</returns>
    public static double GetDouble()
    {
        string input = Console.ReadLine() ?? "";
        double d = Double.Parse(input);
        return d;
    }

    /// <summary>
    /// Reads in a string from console, converts it to a boolean
    /// and returns the converted value
    /// </summary>
    /// <returns>A boolean representation of the users input</returns>
    public static bool GetBool()
    {
        string input = Console.ReadLine() ?? "";
        bool b = Boolean.Parse(input);
        return b;
    }

    /// <summary>
    /// Reads in a string and converts it to a DateTime using the QUT consistent HH:mm dd/MM/yyyy format
    /// All dates must be in this format so 1/2/2000 should be 01/02/2000 or you will ge an error
    /// https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tryparseexact?view=net-8.0
    /// </summary>
    /// <returns></returns>
    public static DateTime GetDateTime()
    {
        string input = Console.ReadLine() ?? "";
        DateTime result;
        string format = PDWorldConsts.DATETIMEFORMAT; // Expected format is "HH:mm dd/MM/yyyy"
        bool dtWorked = DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        if (!dtWorked)
        {
            DisplayError("Incorrect Date Format");
        }
        return result;
    }

}
