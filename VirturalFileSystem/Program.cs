using VirturalFileSystem;
using System;

bool applicationRunning = true;

do
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    
    Console.WriteLine("---VIRTUAL FILE_SYSTEM NAVIGATOR---");
    Console.WriteLine("**MacOS operating system can only run this application");
    Thread.Sleep(1500);
 
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    
    String rootUser = GetValidDirectory();
    DirectoryNode directoryNode = new DirectoryNode(rootUser);
    
    directoryNode.LoadSubDirectories();

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