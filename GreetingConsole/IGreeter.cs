using System;


namespace GreetingConsole;

public interface IGreeter
{
    public string Greet(params string[]? strs);
}