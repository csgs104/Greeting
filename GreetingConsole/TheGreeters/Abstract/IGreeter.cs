namespace GreetingConsole.TheGreeters.Abstract;

public interface IGreeter
{
    public string Greet(params string[]? strs);
}