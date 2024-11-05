using VirturalFileSystem;
using System;

CommandHistory commandHistory = new CommandHistory();
Navigator navigator = new Navigator();
Command com = new Command();

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
    string command = Console.ReadLine();
    
    com.ExecuteCommand(command, navigator, commandHistory, userHome);

    commandHistory.PrintStack();

    // switch (command)
    // {
    //     case "ls":
    //         List<string> basedDirectories = navigator.LoadDirectories(userHome);
    //     
    //         foreach (var dir in basedDirectories)
    //         {
    //             String a = getLast(dir);
    //             Console.WriteLine($"[>>] {a}");
    //         }
    //         
    //         
    //         commandHistory.Push(command);
    //         break;
    //
    //     default:
    //         break;
    // }





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