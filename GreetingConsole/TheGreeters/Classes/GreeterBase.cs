using System;

using GreetingConsole.TheGreeters;
using GreetingConsole.TheGreeters.Abstract;

// 000
namespace GreetingConsole.TheGreeters.Classes;

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