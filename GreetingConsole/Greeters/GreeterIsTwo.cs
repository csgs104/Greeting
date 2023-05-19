using System;


namespace GreetingConsole.Greeters;

public class GreeaterIsTwo : GreeterBase
{
    public GreeaterIsTwo(IGreeter? successor = default)
    : base(successor)
    { }

    public override string Greet(params string[]? strs)
    {
        if (strs is not null && strs.Length == 2)
        {
            return !(strs[0] == strs[0].ToUpper()) 
		           ? $"Hello, {strs[0]} and {strs[1]}." 
		           : $"HELLO {strs[0]} AND {strs[2]}!";
        }
        else
        {
            return Succeeding(strs);
        }
    }
}