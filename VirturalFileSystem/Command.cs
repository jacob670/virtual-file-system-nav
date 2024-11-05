namespace VirturalFileSystem;

public class Command
{
    public void ExecuteCommand(string command, Navigator navigator, CommandHistory commandHistory, string directory)
    {
        switch (command)
        {
            case "ls":
                List<string> basedDirectories = navigator.LoadDirectories(directory);

                foreach (var dir in basedDirectories)
                {
                    String finalPart = RecieveLastDirectory(dir);
                    Console.WriteLine($"[>>] {finalPart}");
                }
                
                commandHistory.Push("ls");
                break;
            case "cd":
                commandHistory.Push("cd");
                break;

            default:
                break;
        }

    }
    
    private String RecieveLastDirectory(string path)
    {
        return Path.GetFileName(path);
    }

}