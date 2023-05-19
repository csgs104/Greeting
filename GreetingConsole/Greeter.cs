using System;


namespace GreetingConsole;

public abstract class Greeter : IGreeter
{
    private IGreeter? _successor;

    protected IGreeter? Successor { get => _successor; }


    public Greeter(IGreeter? successor = default)
    {
        _successor = successor;
    }


    public void SetSuccessor(IGreeter? successor)
    {
        _successor = successor;
    }


    public abstract string Greet(params string[]? strs);
}