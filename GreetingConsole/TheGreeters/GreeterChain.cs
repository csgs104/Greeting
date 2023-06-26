namespace GreetingConsole.TheGreeters;

using Abstract;
using Classes;

// 3
public class GreeterChain
{
    private readonly IGreeter _chain;

    public IGreeter Chain { get => _chain; }


    public GreeterChain()
    {
        var list = Greeters();
        for (int c = 0; c < (list.Count - 1); c++)
        {
            list[c].SetSuccessor(list[c + 1]);
        }
        list.Last().SetSuccessor(null);
        _chain = list.First();
    }


    public virtual IList<Greeter> Greeters()
    {
        var list = new List<Greeter>(5);
        list.Add(new GreeterBase());
        list.Add(new GreeterIsNullOrZero());
        list.Add(new GreeterIsOne());
        list.Add(new GreeterIsTwo());
        list.Add(new GreeterIsMore());
        return list;
    }
}