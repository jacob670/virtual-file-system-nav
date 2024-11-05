using VirturalFileSystem;
using System;

CommandHistory commandHistory = new CommandHistory();
Navigator navigator = new Navigator();

bool applicationRunning = true; 
string userHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


Console.ForegroundColor = ConsoleColor.Magenta;
    
Console.WriteLine("---VIRTUAL FILE_SYSTEM NAVIGATOR---");
Console.WriteLine("**MacOS operating system can only run this application");
Thread.Sleep(1500);
Console.Clear();

do
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine($"<$> {userHome}");

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("-> ");
    String command = Console.ReadLine();

    if (command == "ls")
    {
        List<string> a = navigator.LoadDirectories(userHome);
        foreach (var i in a)
        {
            Console.WriteLine(i);
        }
        
    }
    
    commandHistory.Push(command);
    

    



} while (applicationRunning);

static String GetValidDirectory()
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("osUser -> ");
        String rootUser = Console.ReadLine();
        
        string directoryPath = $"/Users/{rootUser}";

        if (Directory.Exists(directoryPath))
        {
            return rootUser;
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{rootUser} does not exist.");
        Console.WriteLine();
        
        Thread.Sleep(1000);
        Console.Clear();
    }
}