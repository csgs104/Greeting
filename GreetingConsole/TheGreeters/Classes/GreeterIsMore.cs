using System;

using GreetingConsole.TheGreeters.Abstract;

// 4
namespace GreetingConsole.TheGreeters.Classes;

public class GreeterIsMore : GreeterBase
{
    public GreeterIsMore(IGreeter? successor = default)
    : base(successor)
    { }

    public override string Greet(params string[]? strs)
    {
        if (strs is not null && strs.Length > 2)
        {
            if (!strs.All(s => s == s.ToUpper()))
            {
                return $"Hello, {strs.Take(strs.Length - 1).Aggregate((p, s) => $"{p}, {s}")}, and {strs[strs.Length - 1]}.";
            }
            else if (strs.All(s => s == s.ToUpper()))
            {
                return $"HELLO {strs.Take(strs.Length - 1).Aggregate((p, s) => $"{p} AND {s}")} AND {strs[strs.Length - 1]}!";
            }
            else
            {
                return string.Empty;
            }
        }
        else
        {
            return Succeeding(strs);
        }
    }
}