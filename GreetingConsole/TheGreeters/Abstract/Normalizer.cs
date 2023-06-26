namespace GreetingConsole.TheGreeters.Abstract;

public static class Normalizer
{
    private static string[]? Normalize(bool shout = false, char sep = ',', char specialsep = '"', params string[]? names)
    {
        var namesDic = names?.ToDictionary(n => n, n =>
                                (isShout: n == n.ToUpper(),
                                 isSeparate: n.Contains(sep),
                                 isSpecial: n != n.TrimStart(specialsep) && n != n.TrimEnd(specialsep) && n != n.Trim(specialsep)));

        return namesDic?.Select(n => shout == n.Value.isShout ? n.Value.isSpecial
                                                       ? n.Key.Trim(specialsep)
                                                       : n.Value.isSeparate
                                                       ? n.Key.Split(sep, StringSplitOptions.TrimEntries).Aggregate((p, s) => $"{p}{Environment.NewLine}{s}")
                                                       : n.Key
                                                       : string.Empty)
                        .Aggregate((p, s) => $"{p}{Environment.NewLine}{s}")
                        .Split(Environment.NewLine, StringSplitOptions.TrimEntries)
                        .Except(new string[] { string.Empty })
                        .ToArray();
    }

    public static (string[]?, string[]?) Naming(params string[]? names)
    {
        return names is null ? (null, null) : (Normalize(false, names: names), Normalize(true, names: names));
    }
}