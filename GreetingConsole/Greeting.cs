using System;
using System.Text;


namespace GreetingConsole;

public class Greeting
{
    public Greeting()
    { }


    public string Greet1(string name)
    {
        return $"Hello, {name}.";
    }


    public string Greet2(string? name = default)
    {
        return name is null
            ? $"Hello, my friend."
            : $"Hello, {name}.";
    }


    public string Greet3(string? name = default)
    {
        return name is null
            ? $"Hello, my friend."
            : (name == name.ToUpper())
                ? $"HELLO {name}!"
                : $"Hello, {name}.";
    }


    public string Greet4(params string[]? names)
    {
        return names is null
            ? $"Hello, my friend."
            : (names.Length > 1)
                ? $"Hello, {names[0]} and {names[1]}."
                : (names[0] == names[0].ToUpper())
                    ? $"HELLO {names[0]}!"
                    : $"Hello, {names[0]}.";
    }


    public string Greet5(params string[]? names)
    {
        return names is null
            ? $"Hello, my friend."
            : (names.Length == 2)
                ? $"Hello, {names[0]} and {names[1]}."
                : (names.Length > 2)
                    ? $"Hello, {names.Take(names.Length - 1).Aggregate((p, s) => $"{p}, {s}")}, and {names[names.Length - 1]}."
                    : (names[0] == names[0].ToUpper())
                        ? $"HELLO {names[0]}!"
                        : $"Hello, {names[0]}.";
    }


    public string Greet6(params string[]? names)
    {
        var greeting = new StringBuilder();
        if (names is null)
        {
            greeting.Append($"Hello, my friend.");
        }
        else
        {
            var normal = GreetNormal(names?.Select(n => n != n.ToUpper() ? n : string.Empty).Except(new string[] { string.Empty }).ToArray());
            var shout = GreetShout(names?.Select(n => n == n.ToUpper() ? n : string.Empty).Except(new string[] { string.Empty }).ToArray());
            if (normal != string.Empty) greeting.Append(normal);
            if (normal != string.Empty && shout != string.Empty) greeting.Append(" AND ");
            if (shout != string.Empty) greeting.Append(shout);
        }
        return greeting.ToString();
    }


    public string Greet7(params string[]? names)
    {
        var greeting = new StringBuilder();
        if (names is null) 
	    { 
	        greeting.Append($"Hello, my friend.");
	    }
        else
        {
            var list = names?.Aggregate((p, s) => $"{p}, {s}").Split(',', StringSplitOptions.TrimEntries);
            var normal = GreetNormal(list?.Select(n => n != n.ToUpper() ? n : string.Empty).Except(new string[] { string.Empty }).ToArray());
            var shout = GreetShout(list?.Select(n => n == n.ToUpper() ? n : string.Empty).Except(new string[] { string.Empty }).ToArray());
            if (normal != string.Empty) greeting.Append(normal);
            if (normal != string.Empty && shout != string.Empty) greeting.Append(" AND ");
            if (shout != string.Empty) greeting.Append(shout);
        }
        return greeting.ToString();
    }


    public string Greet8(params string[]? names)
    {
        var greeting = new StringBuilder();
        if (names is null) 
	    {
	        greeting.Append($"Hello, my friend."); 
	    }
        else
        {
            var normal = GreetNormal(Builder(shout: false, names: names));
            var shout = GreetShout(Builder(shout: true, names: names));
            if (normal != string.Empty) greeting.Append(normal);
            if (normal != string.Empty && shout != string.Empty) greeting.Append(" AND ");
            if (shout != string.Empty) greeting.Append(shout);
        }
        return greeting.ToString();
    }

    private string[]? Builder(bool shout, char sep = ',', char specialsep = '"', params string[]? names)
    {
        var namesDic = names?.ToDictionary(n => n, n =>
                                        (isShout: n == n.ToUpper(),
                                         isComma: n.Contains(sep),
                                         isSpecial: n != n.TrimStart(specialsep) && n != n.TrimEnd(specialsep) && n != n.Trim(specialsep)));

        return namesDic?.Select(n => shout == n.Value.isShout ? n.Value.isSpecial
                                                       ? n.Key.Trim(specialsep)
                                                       : n.Value.isComma
                                                       ? n.Key.Split(sep, StringSplitOptions.TrimEntries).Aggregate((p, s) => $"{p}{Environment.NewLine}{s}")
                                                       : n.Key
                                                       : string.Empty)
                                          .Aggregate((p, s) => $"{p}{Environment.NewLine}{s}")
                                          .Split(Environment.NewLine, StringSplitOptions.TrimEntries)
                                          .Except(new string[] { string.Empty })
                                          .ToArray();
    }

    private string GreetNormal(params string[]? names)
    {
        return names is null || names.Length == 0
            ? string.Empty
            : (names.Length == 1)
            ? $"Hello, {names[0]}."
            : (names.Length == 2)
            ? $"Hello, {names[0]} and {names[1]}."
            : (names.Length > 2)
            ? $"Hello, {names.Take(names.Length - 1).Aggregate((p, s) => $"{p}, {s}")}, and {names[names.Length - 1]}."
            : string.Empty;
    }

    private string GreetShout(params string[]? names)
    {
        return names is null || names.Length == 0
            ? string.Empty
            : (names.Length == 1)
            ? $"HELLO {names[0]}!"
            : (names.Length == 2)
            ? $"HELLO {names[0]} AND {names[1]}!"
            : (names.Length > 2)
            ? $"HELLO {names.Take(names.Length - 1).Aggregate((p, s) => $"{p} AND {s}")} AND {names[names.Length - 1]}!"
            : string.Empty;
    }

    public string Greet(params string[]? namesList)
    {
        var str = new StringBuilder();
        if (namesList is null)
        {
            str.Append("Hello, my friend.");
        }
        else
        {
            var names = new List<string>();
            var greeted = new List<string>();
            var shouted = new List<string>();

            foreach (var nameList in namesList)
            {
                if (nameList is null)
                {
                    names.Add("my friend");
                }
                else
                {
                    if (nameList != nameList.TrimStart('"') && 
			            nameList != nameList.TrimEnd('"') && 
			            nameList != nameList.Trim('"'))
                    {
                        names.Add(nameList.Trim('"'));
                    }
                    else
                    {
                        foreach (var name in nameList.Split(","))
                        {
                            names.Add(name.Trim());
                        }
                    }
                }
            }

            foreach (var name in names)
            {
                if (name != name.ToUpper())
                {
                    greeted.Add(name);
                }
                else
                {
                    shouted.Add(name);
                }
            }

            if (greeted.Count >= 1)
            {
                str.Append("Hello, ");
            }
            if (greeted.Count == 1)
            {
                str.Append(greeted[0]);
                str.Append(".");
            }
            if (greeted.Count == 2)
            {
                str.Append(greeted[0]);
                str.Append(" and ");
                str.Append(greeted[1]);
                str.Append(".");
            }
            if (greeted.Count > 2)
            {
                foreach (var name in greeted.SkipLast(1))
                {
                    str.Append(name);
                    str.Append(", ");
                }
                str.Append("and ");
                str.Append(greeted.Last());
                str.Append(".");
            }

            if (greeted.Count >= 1 && shouted.Count >= 1) 
	        {
                str.Append(" AND ");
            }

            if (shouted.Count >= 1)
            {
                str.Append("HELLO ");
            }
            if (shouted.Count == 1)
            {
                str.Append(shouted[0]);
                str.Append("!");
            }
            if (shouted.Count == 2)
            {
                str.Append(shouted[0]);
                str.Append(" AND ");
                str.Append(shouted[1]);
                str.Append("!");
            }
            if (shouted.Count > 2)
            {
                foreach (var name in shouted.SkipLast(1))
                {
                    str.Append(name);
                    str.Append(", ");
                }
                str.Append("AND ");
                str.Append(shouted.Last());
                str.Append("!");
            }
        }
        return str.ToString();
    }
}