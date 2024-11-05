namespace VirturalFileSystem;

public class CommandStack<T>
{
    private static readonly int MAX = 1000;
    private int top;
    T[] stack = new T[MAX];

    public CommandStack()
    {
        top = -1;
    }

    public bool IsEmpty()
    {
        return top < 0;
    }

    internal bool Push(T data) 
    { 
        if (top >= MAX)
        {
            throw new StackOverflowException("Stack Overflow");
            return false; 
        } 
        else
        { 
            stack[++top] = data; 
            return true; 
        } 
    } 

    public T Pop()
    {
        if (top < 0)
        {
            throw new Exception("Stack Underflow Error");
        }

        T value = stack[top--];
        return value;
    }

    public T Peek()
    {
        if (top < 0)
        {
            throw new Exception("Stack Underflow Error");
        }

        return stack[top];

    }
    
    public void PrintStack() 
    { 
        if (top < 0) 
        { 
            Console.WriteLine("Stack Underflow"); 
        } 
        else
        { 
            Console.WriteLine("Items in the Stack are :"); 
            for (int i = top; i >= 0; i--) 
            { 
                Console.WriteLine(stack[i]); 
            } 
        } 
    } 
    
}