namespace VirturalFileSystem;

public class Navigator
{
    private readonly List<string> _locationsAllowed = new List<string>()
    {
        "Desktop", "Documents", "Downloads", "Applications"
    };
    
    public List<string> LoadDirectories(string path)
    {
        var directoriesAllowed = new List<string>();
        
        try
        {
            var directories = Directory.GetDirectories(path, "*").ToList();
            foreach (var dir in directories)
            {
                foreach (var location in _locationsAllowed)
                {
                    if (dir.Contains(location))
                    {
                        directoriesAllowed.Add(dir);
                    }
                } 
            }
            return directoriesAllowed;
        }
        catch (UnauthorizedAccessException)
        {
            return new List<string>();
        }
    }

    private bool IsValidDirectory(string dirName)
    {
        string[] systemDirs = { "System", "Library", "Applications", "bin", "etc", "lib", "usr", "var", "tmp" };
        return systemDirs.Contains(dirName, StringComparer.OrdinalIgnoreCase);
    }

    
}