using System;
using System.Collections;
using FluentAssertions;

namespace SampleConsoleApp.Chapter03
{
    public class ArrayReferences
    {
        private class Foo
        {
            public string Name { get; set; }
        }

        public void RunIt()
        {
            string[] sa = { "life", "life-and-death", "life belt", "lifeblood", "life-support", "life support", "LIFO" };

            string s0 = sa[0];
            s0.Should().Be("life");
            s0 = "life0";
            s0.Should().Be("life0");
            sa[0].Should().Be("life");
            sa[0] = "life0a";
            sa[0].Should().Be("life0a");

            Foo[] fa = { new Foo { Name = "name0" } };

            fa[0].Name.Should().Be("name0");
            fa[0].Name = "name1";
            fa[0].Name.Should().Be("name1");
            string name = fa[0].Name;
            name = "name2";
            name.Should().Be("name2");
            fa[0].Name.Should().Be("name1");
            Foo obj = fa[0];
            obj.Name.Should().Be("name1");
            obj.Name = "name3";
            obj.Name.Should().Be("name3");
            fa[0].Name.Should().Be("name3");

        }
    }
}
