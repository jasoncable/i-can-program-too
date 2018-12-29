using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace SampleConsoleApp.Chapter03
{
    public class SortingMirriam
    {
        public static void SortIt()
        {
            string[] sa = new string[] { "life", "life-and-death", "life belt", "lifeblood", "life-support", "life support", "LIFO" };
            Array.Sort(sa);
            Console.WriteLine(String.Join(',', sa));
            // OUTPUT: life,life belt,life support,life-and-death,life-support,lifeblood,LIFO

            List<string> sa1 = new List<string>() { "life", "life-and-death", "life belt", "lifeblood", "life-support", "life support", "LIFO" };
            sa1 = sa1.OrderBy(x => x).ToList();
            Console.WriteLine(String.Join(',', sa1));
            // OUTPUT: life,life belt,life support,life-and-death,life-support,lifeblood,LIFO

            List<string> sa2 = new List<string>() { "life", "life-and-death", "life belt", "lifeblood", "life-support", "life support", "LIFO" };
            sa2 = sa2.OrderBy(x => x, StringComparer.CurrentCulture).ToList();
            Console.WriteLine(String.Join(',', sa2));
            // OUTPUT: life,life belt,life support,life-and-death,life-support,lifeblood,LIFO

            List<string> sa3 = new List<string>() { "life", "life-and-death", "life belt", "lifeblood", "life-support", "life support", "LIFO" };
            sa3 = sa3.OrderBy(x => x, StringComparer.Ordinal).ToList();
            Console.WriteLine(String.Join(',', sa3));
            // OUTPUT: LIFO,life,life belt,life support,life-and-death,life-support,lifeblood

        }
    }
}
