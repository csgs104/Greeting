using System;


namespace GreetingConsole;

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


    // protected abstract bool IsNullOrZero(string str);

    // protected abstract bool IsOne(string str);

    // protected abstract bool IsTwo(string str);

    // protected abstract bool IsMore(string str);

    // protected abstract bool IsComma(string str);

    // protected abstract bool IsShout(string str);

    // protected abstract bool IsSpecial(string str);
}