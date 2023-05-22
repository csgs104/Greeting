/* This [Kata](https://en.wikipedia.org/wiki/Kata_(programming) is designed to 
 * help practice what a test of a pure function ought to look like. 
 * It is intentionally designed to start with a very easy, 
 * non-branching base case which slowly becomes addled with complexity 
 * as additional requirements are added that will require significant 
 * branching and eventually a pressure to compose additional units.
 * 
 * This Kata was suggested by Nick Gauthier and inspired a bit by Bob from Exercism.
 * This Kata is designed to be used with Detroit-school TDD.
 *
 * Kata Source: https://github.com/testdouble/contributing-tests/wiki/Greeting-Kata
 *
 * Requirement1: Write a method greet(name) that interpolates name in a simple greeting. 
 * For example, when name is "Bob", the method should return a string "Hello, Bob.".
 *
 * Requirement2: Handle nulls by introducing a stand-in. For example, when 
 * name is null, then the method should return the string "Hello, my friend."
 *
 * Requirement3: Handle shouting. When name is all uppercase, then the method 
 * should shout back to the user. For example, when name is "JERRY" then the method 
 * should return the string "HELLO JERRY!"
 *
 * Requirement4: Handle two names of input. When name is an array of two names 
 * (or, in languages that support it, varargs or a splat), then both names should be printed. 
 * For example, when name is ["Jill", "Jane"], then the method should return 
 * the string "Hello, Jill and Jane."
 *
 */

using Microsoft.Extensions.DependencyInjection;

using GreetingConsole;
using GreetingConsole.IoC;
using GreetingConsole.TheGreeters;

Console.WriteLine("Hello.");

Console.WriteLine("#### #### #### #### #### #### #### ####");

var start = Startup.CreateHostBuilder()
            ?? throw new Exception("Not Started.");
var host = start.Build()
           ?? throw new Exception("Host Not Found.");
var greeting = host.Services.GetService<Greeting>()
         ?? throw new Exception("Greeting not Found.");

Console.WriteLine("Services Started.");

Console.WriteLine("#### #### #### #### #### #### #### ####");

Console.WriteLine(greeting.Greet8("Stefano", "PIPPO", "\"Pluto, Pippa, Peppa\"", "Gigia, Gigio", "PIPPOLINO"));
Console.WriteLine(GreeterFactory.Build("Stefano", "PIPPO", "\"Pluto, Pippa, Peppa\"", "Gigia, Gigio", "PIPPOLINO"));


Console.WriteLine("#### #### #### #### #### #### #### ####");

Console.WriteLine("Bye.");