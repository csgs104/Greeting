using System;


namespace GreetingConsole.Greeters;

public class GreeaterIsOne : GreeterBase
{
    public GreeaterIsOne(IGreeter? successor = default)
    : base(successor)
    { }

    public override string Greet(params string[]? strs)
    {
        if (strs is not null && strs.Length == 1)
        {
            return !(strs[0] == strs[0].ToUpper()) 
		           ? $"Hello, {strs[0]}." 
		           : $"HELLO {strs[0]}!";
        }
        else
        {
            return Succeeding(strs);
        }
    }
}