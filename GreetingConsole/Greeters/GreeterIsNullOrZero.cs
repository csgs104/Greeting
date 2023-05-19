﻿using System;


namespace GreetingConsole.Greeters;

public class GreeterIsNullOrZero : GreeterBase
{
    public GreeterIsNullOrZero(IGreeter? successor = default)
    : base(successor)
    { }

    public override string Greet(params string[]? strs)
    {
        if (strs is null || strs.Length == 0)
        {
            return "Hello, my friend.";
        }
        else
        {
            return Succeeding(strs);
        }
    }
}