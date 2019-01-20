﻿using System;
using FluentAssertions;

namespace SampleConsoleApp.Chapter10
{
    public class TypeCasting
    {
        public static void RunMe()
        {
            int a = 1234;
            decimal b = a;

            decimal c = 12.34m;
            int d = (int)c;

            decimal e = 4 / 3;
            e.Should().Be(1m);

            decimal f = (decimal)4 / (decimal)3;
            Console.WriteLine($"f - {f}");

            decimal g = 4m / 3m;
            Console.WriteLine(g);

            int h = 4;
            int i = 3;
            decimal j = (decimal)h / (decimal)i;
            Console.WriteLine(j);
        }
    }
}
