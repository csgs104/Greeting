namespace GreetingConsole.TheGreeters.Classes;

using Abstract;

// 000
public class GreeterBase : Greeter
{
    public GreeterBase(IGreeter? successor = default)
    : base(successor)
    { }

    public override string Greet(params string[]? strs)
    {
        if (Successor is not null)
        {
            return Successor.Greet(strs);
        }
        else
        {
            return Succeeding(strs);
        }
    }

    protected string Succeeding(params string[]? strs) 
    {
        if (Successor is not null)
        {
            return Successor.Greet(strs);
        }
        else
        {
            return string.Empty;
        }
    }
}