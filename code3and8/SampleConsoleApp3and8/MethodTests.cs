using System;
using System.Collections.Generic;
using System.Text;

namespace SampleConsoleApp3and8
{
    public class MethodTests
    {
        public void Method1(string s = "string") { }

        public void Method2(string s = "1", int i = 1) { }

        public void Method3(
            string a = "one",
            int b = new Int32(),
            string c = "",
            string d = default(string),
            string e = default,
            string f = null,
            int? g = null,
            int h = default(int),
            int i = default,
            int? j = default(int?),
            int? k = default,
            int? l = new Int32?()
            ) {}
    }
}
