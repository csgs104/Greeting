using GreetingConsole;
using Xunit.Abstractions;


namespace GreetingTest;

public class GreetingTest
{
    private readonly Greeting _sut;
    private readonly ITestOutputHelper _output;


    public GreetingTest(ITestOutputHelper output)
    {
        _sut = new Greeting();
        _output = output;
    }


    [Fact]
    public void SimpleGreet()
    {
        Assert.True(true);
    }

    [Theory] // called 3 times
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(6)]
    public void TestTheory(int number) 
    {
        Assert.False(number % 2 == 1);
    }

    [Fact]
    public void Should_Greet1()
    {
        Assert.Equal("Hello, Bob.", _sut.Greet1("Bob"));
    }

    [Fact]
    public void Should_Greet2()
    {
        Assert.Equal("Hello, Bob.", _sut.Greet2("Bob"));
        Assert.Equal("Hello, my friend.", _sut.Greet2(null));
    }

    [Fact]
    public void Should_Greet3()
    {
        Assert.Equal("Hello, Bob.", _sut.Greet3("Bob"));
        Assert.Equal("Hello, my friend.", _sut.Greet3(null));
        Assert.Equal("HELLO JERRY!", _sut.Greet3("JERRY"));
    }

    [Fact]
    public void Should_Greet4()
    {
        Assert.Equal("Hello, Bob.", _sut.Greet4("Bob"));
        Assert.Equal("Hello, my friend.", _sut.Greet4(null));
        Assert.Equal("HELLO JERRY!", _sut.Greet4("JERRY"));
        Assert.Equal("Hello, Jill and Jane!", _sut.Greet4("Jill", "Jane"));
    }

    [Fact]
    public void Should_Greet5()
    {
        Assert.Equal("Hello, Bob.", _sut.Greet5("Bob"));
        Assert.Equal("Hello, my friend.", _sut.Greet5(null));
        Assert.Equal("HELLO JERRY!", _sut.Greet5("JERRY"));
        Assert.Equal("Hello, Jill and Jane.", _sut.Greet5("Jill", "Jane"));
        Assert.Equal("Hello, Amy, Brian, and Charlotte.", _sut.Greet5("Amy", "Brian", "Charlotte"));
    }

    [Fact]
    public void Should_Greet6()
    {
        Assert.Equal("Hello, Bob.", _sut.Greet6("Bob"));
        Assert.Equal("Hello, my friend.", _sut.Greet6(null));
        Assert.Equal("HELLO JERRY!", _sut.Greet6("JERRY"));
        Assert.Equal("Hello, Jill and Jane.", _sut.Greet6("Jill", "Jane"));
        Assert.Equal("Hello, Amy, Brian, and Charlotte.", _sut.Greet6("Amy", "Brian", "Charlotte"));
        Assert.Equal("Hello, Amy and Charlotte. AND HELLO BRIAN!", _sut.Greet6("Amy", "BRIAN", "Charlotte"));
        Assert.Equal("Hello, Amy, Jill, and Charlotte. AND HELLO BRIAN!", _sut.Greet6("Amy", "Jill", "BRIAN", "Charlotte"));
    }

    [Fact]
    public void Should_Greet7()
    {
        Assert.Equal("Hello, Bob.", _sut.Greet7("Bob"));
        Assert.Equal("Hello, my friend.", _sut.Greet7(null));
        Assert.Equal("HELLO JERRY!", _sut.Greet7("JERRY"));
        Assert.Equal("Hello, Jill and Jane.", _sut.Greet7("Jill", "Jane"));
        Assert.Equal("Hello, Amy, Brian, and Charlotte.", _sut.Greet7("Amy", "Brian", "Charlotte"));
        Assert.Equal("Hello, Amy and Charlotte. AND HELLO BRIAN!", _sut.Greet7("Amy", "BRIAN", "Charlotte"));
        Assert.Equal("Hello, Amy, Jill, and Charlotte. AND HELLO BRIAN!", _sut.Greet7("Amy", "Jill", "BRIAN", "Charlotte"));
        Assert.Equal("Hello, Amy, Jill, Jim, and Charlotte. AND HELLO BRIAN!", _sut.Greet7("Amy", "Jill, Jim", "BRIAN", "Charlotte"));
    }

    [Fact]
    public void Should_Greet8()
    {
        Assert.Equal("Hello, Bob.", _sut.Greet8("Bob"));
        Assert.Equal("Hello, my friend.", _sut.Greet8(null));
        Assert.Equal("HELLO JERRY!", _sut.Greet8("JERRY"));
        Assert.Equal("Hello, Jill and Jane.", _sut.Greet8("Jill", "Jane"));
        Assert.Equal("Hello, Amy, Brian, and Charlotte.", _sut.Greet8("Amy", "Brian", "Charlotte"));
        Assert.Equal("Hello, Amy and Charlotte. AND HELLO BRIAN!", _sut.Greet8("Amy", "BRIAN", "Charlotte"));
        Assert.Equal("Hello, Amy, Jill, and Charlotte. AND HELLO BRIAN!", _sut.Greet8("Amy", "Jill", "BRIAN", "Charlotte"));
        Assert.Equal("Hello, Amy, Jill, Jim, and Charlotte. AND HELLO BRIAN!", _sut.Greet8("Amy", "Jill, Jim", "BRIAN", "Charlotte"));
        Assert.Equal("Hello, Amy, Jill, Jim, and Charlotte, Michael, Lucas. AND HELLO BRIAN!", _sut.Greet8("Amy", "Jill, Jim", "BRIAN", "\"Charlotte, Michael, Lucas\""));
        Assert.Equal("Hello, Amy, Charlotte, Michael, Lucas, Jill, and Jim. AND HELLO BRIAN!", _sut.Greet8("Amy", "\"Charlotte, Michael, Lucas\"", "Jill, Jim", "BRIAN"));
        Assert.Equal("Hello, Amy, Jill, Jim, Charlotte, Michael, Lucas.", _sut.Greet8("\"Amy, Jill, Jim, Charlotte, Michael, Lucas\""));
    }

    [Fact]
    public void Should_Greet()
    {
        Assert.True(true);
        Assert.Equal("Hello, Bob.", _sut.Greet("Bob"));
        Assert.Equal("Hello, my friend.", _sut.Greet(null));
        Assert.Equal("HELLO JERRY!", _sut.Greet("JERRY"));
        Assert.Equal("Hello, Jill and Jane.", _sut.Greet("Jill", "Jane"));
        Assert.Equal("Hello, Amy, Brian, and Charlotte.", _sut.Greet("Amy", "Brian", "Charlotte"));
        Assert.Equal("Hello, Amy and Charlotte. AND HELLO BRIAN!", _sut.Greet("Amy", "BRIAN", "Charlotte"));
        Assert.Equal("Hello, Amy, Jill, and Charlotte. AND HELLO BRIAN!", _sut.Greet("Amy", "Jill", "BRIAN", "Charlotte"));
        Assert.Equal("Hello, Bob, Charlie, and Dianne.", _sut.Greet("Bob", "Charlie, Dianne"));
        Assert.Equal("Hello, Bob and Charlie, Dianne.", _sut.Greet("Bob", "\"Charlie, Dianne\""));
    }

    [Fact(Skip = "Sandbox")]
    public void SandBox() 
    {
        _output.WriteLine(_sut.Greet("Pippo"));
    }
}