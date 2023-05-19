using System;


namespace GreetingConsole.Greeters;

public class GreeaterIsMore : GreeterBase
{
    public GreeaterIsMore(IGreeter? successor = default)
    : base(successor)
    { }

    public override string Greet(params string[]? strs)
    {
        if (strs is not null && strs.Length > 2)
        {
            return !(strs[0] == strs[0].ToUpper())
                   ? $"Hello, {strs.Take(strs.Length - 1).Aggregate((p, s) => $"{p}, {s}")}, and {strs[strs.Length - 1]}."
                   : $"HELLO {strs.Take(strs.Length - 1).Aggregate((p, s) => $"{p} AND {s}")} AND {strs[strs.Length - 1]}!";
        }
        else
        {
            return Succeeding(strs);
        }
    }
}