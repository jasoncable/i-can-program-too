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

// IndexOutOfRangeException thrown
list[102] = 42;