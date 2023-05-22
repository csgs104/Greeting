using System;
using System.Text;

using GreetingConsole.TheGreeters.Abstract;
using GreetingConsole.TheGreeters.Classes;


namespace GreetingConsole.TheGreeters;

public  static class GreeterFactory
{
    public static string Build(params string[]? strs) 
    {
        var chain = (new GreeterChain()).Chain;
        var names = Normalizer.Naming(strs);

        var result = new StringBuilder();
        if (names.Item1 is null && names.Item2 is null)
        {
            return chain.Greet(null);
        }
        else
        {
            var n = names.Item1 is not null ? chain.Greet(names.Item1) : string.Empty;
            var s = names.Item2 is not null ? chain.Greet(names.Item2) : string.Empty;
            if (n != string.Empty) result.Append(n);
            if (n != string.Empty && s != string.Empty) result.Append(" AND ");
            if (s != string.Empty) result.Append(s);
        }
        return result.ToString();
    }
}