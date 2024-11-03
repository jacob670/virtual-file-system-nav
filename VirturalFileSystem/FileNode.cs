namespace VirturalFileSystem;

public class FileNode
{
    /* FileNode class is tree based for the directory
     * name: the current name of file
     * 
     */
    
    private string name;

    public FileNode(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    
    
}