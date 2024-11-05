namespace VirturalFileSystem;

public class CommandHistory : Command
{
    private readonly CommandStack<string> _commandHistory = new();

    public void Push(string value)
    {
        _commandHistory.Push(value);
    }

    public void Pop()
    {
        _commandHistory.Pop();
    }
    
    public string Peek()
    {
        return _commandHistory.Peek();
    }

    public void PrintStack()
    {
        _commandHistory.PrintStack();
    }
}