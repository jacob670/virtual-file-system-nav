using System.Security.AccessControl;
using System.Threading.Channels;

namespace VirturalFileSystem;

public class DirectoryNode
{    
    private String rootUserName;
    private readonly string root = "/Users";

    private List<DirectoryNode> subDirectories { get; set; }
    private List<string> files { get; set; }

    private static readonly HashSet<string> AllowedDirectories = new HashSet<string>
    {
        "Desktop",
        "Downloads",
        "Documents",
        "Applications"
    };
    
    
    public String Root { get; }

    public DirectoryNode(String rootUserName)
    {
        this.rootUserName = rootUserName;
        //this.root = $"{root}/{rootUserName}";
        this.root = Path.Combine("/Users", rootUserName);
        Root = root;

        subDirectories = new List<DirectoryNode>();
        files = new List<string>();
    }

    public void LoadSubDirectories()
    {
        try
        {
            var directories = Directory.GetDirectories(this.root);
            foreach (var directory in directories)
            {
                String dirName = Path.GetFileName(directory);
                
                if (AllowedDirectories.Contains(dirName))
                {
                    //DirectoryNode directoryNode = new DirectoryNode(directory);
                    //directoryNode.LoadSubDirectories();
                    //subDirectories.Add(directoryNode);
                    
                    DirectoryNode directoryNode = new DirectoryNode(Path.GetFileName(directory));
                    directoryNode.LoadSubDirectories();
                    subDirectories.Add(directoryNode);
                    Console.WriteLine(directory);
                }
            }
            //LoadFiles();
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Access denied");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading directories: {ex.Message}");
        }
    }

    private void LoadFiles()
    {
        try
        {
            var currentFiles = Directory.GetFiles(this.root);
            files.AddRange(currentFiles);

            foreach (var f in files)
            {
                Console.WriteLine(f);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied to files");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading files: {ex.Message}");
        }
    }

}