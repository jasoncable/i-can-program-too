using System;
using System.Collections.Generic;
using System.Text;

namespace SampleConsoleApp.Chapter13
{
    public class GenericList
    {
        public static void RunMe()
        {
            List<int> ints = new List<int> { 1, 2, 3 };
            Console.WriteLine(ints.Count);

            // create a List<T> with the type int and initial capacity of 128
            List<int> list = new List<int>(128);

            // add 100 values to the array
            for (int i = 0; i < 100; i++)
                list.Add(i * 100);

            Console.WriteLine(list.Capacity); // 128
            Console.WriteLine(list.Count); // 100
            Console.WriteLine(list[2]); // 200

            foreach(var i in list)
                Console.WriteLine(i); // 0 through 9900

            list.Add(10000); // index 100
            list.Remove(200); // remove items with this value
            Console.WriteLine(list[2]); // value is now 300

            list.RemoveRange(5, 10); // remove 10 items starting at index 5
            list.AddRange(new int[]{ 1, 2, 3 }); // add 3 items to the end
            list.Clear(); // remove all values; Capacity remains the same

            //list[102] = 42;

            List<List<string>> listOfLists = new List<List<string>>();
            listOfLists.Add(new List<string>());
            listOfLists[0].Add("a string");
            string s = listOfLists[0][0];

            Stack<string> ss = new Stack<string>();
            ss.Push("string 1");
            ss.Push("string 2");
            Console.WriteLine(ss.Pop()); // "string 2"
            ss.Push("string 3");
            foreach(string s1 in ss)
            {
                Console.WriteLine(s1);
            }

            Console.WriteLine();
            Console.WriteLine(ss.Count);
            bool isTrue = ss.TryPop(out string s2);
            Console.WriteLine(s2);
            Console.WriteLine(ss.Count);
            isTrue = ss.TryPeek(out string s3);
            Console.WriteLine(s3);

            Console.WriteLine();
            Queue<string> qs = new Queue<string>();
            qs.Enqueue("1");
            qs.Enqueue("2");
            qs.Enqueue("3");
            if (qs.TryDequeue(out string firstValue))
                Console.WriteLine(firstValue); // 1

        }
    }
}
