using VirturalFileSystem;
using System;

CommandStack<string> stack = new CommandStack<string>();
stack.Push("yo");
stack.Push("hi");
stack.Push("alasl");

stack.PrintStack();
Console.WriteLine($"popping now: {stack.Peek()}");
stack.Pop();
stack.PrintStack();

CommandStack<int> a = new CommandStack<int>();
a.Push(10);
a.Push(20);
a.PrintStack();
a.Pop();
a.PrintStack();

// bool applicationRunning = true; 
//
//
// string userHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); // Get the user's home directory
// List<string> allowedPaths = new List<string>
// {
//     Path.Combine(userHome, "Downloads"), // Allowed path for Downloads
//     Path.Combine(userHome, "Desktop"),   // Allowed path for Desktop
//     Path.Combine(userHome, "Documents"),  // Allowed path for Documents
//     Path.Combine(userHome, "Applications") // Allowed path for Applications (if it exists on Windows)
// };
// Navigator navigator = new Navigator(allowedPaths);

// do
// {
//     Console.ForegroundColor = ConsoleColor.Magenta;
//     
//     Console.WriteLine("---VIRTUAL FILE_SYSTEM NAVIGATOR---");
//     Console.WriteLine("**MacOS operating system can only run this application");
//     Thread.Sleep(1500);
//  
//     Console.Clear();
//     Console.ForegroundColor = ConsoleColor.Red;
//     
//     String rootUser = GetValidDirectory();
//     DirectoryNode directoryNode = new DirectoryNode(rootUser);
//     
//     directoryNode.LoadSubDirectories();
//
// } while (applicationRunning);

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