namespace VirturalFileSystem;

public class Node
{
    public String name;
    public string path;
    public List<Node> children;

    public Node(String name, String path)
    {
        this.name = name;
        this.path = path;
        children = new List<Node>();
    }
}