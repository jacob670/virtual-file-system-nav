namespace VirturalFileSystem;

public class Navigator
{
    
    public List<string> LoadDirectories(string path)
    {
        try
        {
            return Directory.GetDirectories(path, "*").ToList();
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