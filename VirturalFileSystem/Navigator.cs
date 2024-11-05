namespace VirturalFileSystem;

public class Navigator
{
    private readonly Node CurrentDirectory;
    public static String rootName;

    private List<String> AllowedPaths;

    public Navigator(List<string> allowedPaths)
    {
        AllowedPaths = allowedPaths; // Initialize allowed paths
        rootName = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        CurrentDirectory = new Node(new DirectoryInfo(rootName).Name, rootName);
        LoadDirectories(CurrentDirectory);
    }
    
    
    
    private void LoadDirectories(Node currentNode, int depth = 0, int maxDepth = 2)
    {
        if (depth > maxDepth)
            return;
        
        try
        {
            foreach (var dir in Directory.GetDirectories(currentNode.path))
            {
                // Exclude hidden directories (like .git) and system directories
                string dirName = Path.GetFileName(dir);
                if (!dirName.StartsWith(".") && !IsValidDirectory(dirName))
                {
                    var childNode = new Node(dirName, dir);
                    currentNode.children.Add(childNode);
                    Console.WriteLine(childNode.path);// Add the directory node
                    LoadDirectories(childNode, depth + 1, maxDepth); // Recursively load its subdirectories
                }
            }

            // Load files
            foreach (var file in Directory.GetFiles(currentNode.path))
            {
                // Exclude hidden files
                string fileName = Path.GetFileName(file);
                if (!fileName.StartsWith("."))
                {
                    currentNode.children.Add(new Node(fileName, file)); // Add file node
                    Console.WriteLine(fileName);// Add the directory node
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Access denied to {currentNode.path}.");
        }
    }
    
    private bool IsValidDirectory(string dirName)
    {
        string[] systemDirs = { "System", "Library", "Applications", "bin", "etc", "lib", "usr", "var", "tmp" };
        return systemDirs.Contains(dirName, StringComparer.OrdinalIgnoreCase);
    }

    
}