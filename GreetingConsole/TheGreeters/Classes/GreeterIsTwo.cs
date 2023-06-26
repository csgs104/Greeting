namespace GreetingConsole.TheGreeters.Classes;

using Abstract;

// 2
public class GreeterIsTwo : GreeterBase
{
    public GreeterIsTwo(IGreeter? successor = default)
    : base(successor)
    { }

    public override string Greet(params string[]? strs)
    {
        if (strs is not null && strs.Length == 2)
        {
            if (!strs.All(s => s == s.ToUpper()))
            {
                return $"Hello, {strs[0]} and {strs[1]}.";

            }
            else if (strs.All(s => s == s.ToUpper()))
            {
                return $"HELLO {strs[0]} AND {strs[1]}!";
            }
            else 
	        {
                var n = (strs[0] == strs[0].ToUpper()) ? strs[0] : strs[1];
                var s = strs[0] == strs[0].ToUpper() ? strs[1] : strs[0];
                return @$"Hello, {n}. AND HELLO {s}!";
	        }
        }
        else
        {
            return Succeeding(strs);
        }
    }
}