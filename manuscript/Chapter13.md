# Generics

We are going to begin our deep dive into the world of generics.  First, we had to wade through a _lot_ of important information on C# before we were able to realize the power of generics.  They are a quite complex issue to handle, so we will first start with how to _use_ generics then proceed onto how to _construct_ generic things.

A> To this point we have been almost solely focusing on objects contained in the `System` namespace.  For this and future chapters, we are adding `System.Collections.Generic` and `System.Linq`.  You will want to include those namespaces along with `System` in your `.cs` files.

## What is a generic?

In the olden times, long ago, before millennials roamed the planet, reusable objects that could store and perform actions on all objects had to cast everything to and from `object`.  With the .NET Framework 2.0 release Microsoft gave us generics.  They are a language and runtime construct that allow us to treat all objects the same way without having to box and unbox constantly, which as we have seen, can be very error prone.  It is also resource intensive.  How do you always know that an array of objects is always of a certain type?  Enter... generics.

## `List<T>`

`System.Collections.Generic.List<T>` \(pronounced "list of tea"\) is a C# class that acts as a replacement for the standard C# array.  Arrays are a pain because they are fixed length, etc.  Generic lists are expandable and are easier to use, especially with the introduction of Linq, but may not be quite as performant as the standard `System.Array`.  On modern machines, though, we generally don't have to worry too much about that.  Let's see how to use a `List<T>`.  

A> One minor note, in the C# world we start generic parameters at the letter `T`.  I can only imagine that it stands for **t**ype.  It's just one of those common conventions like array iterator variables starting with `i`.

    List<int> ints = new List<int> { 1, 2, 3 };

You can see that generic lists also use the array initialization syntax that we learned earlier.  To specify the data type for the object, you place it in angle brackets `<>`.  This creates a new `List<T>` object that handles objects of type `int`.  Actually, the data type between the angle brackets can be any .NET object including value types \(C# integral types, enums, structs\) and classes.  Please note that some generic classes restrict the type of types that are accepted.

Generic lists effectively replaced a much older C# type called the `ArrayList` from `System.Collections`.  It was essentially an expandable array of objects which required a lot of boxing and unboxing to use.  As you will see soon, generic lists implement their capabilities mostly at the instance level and through extension methods from the `System.Linq` namespace as opposed to the `Array` type which implements its capabilities at the instance and static levels of the `Array` object.

Need to add a value to your array?  It's easy.

    ints.Add(4);

## Rant on a Tangent

**This is important and often overlooked, so please pay attention.**  When adding to most .NET expandable length objects \("collections", as they implement `ICollection`, but this also applies to `StringBuilder`\), the object _doubles_ in size once it hits its maximum _capacity_.  Most of these types have a default capacity which varies between implementations and _versions_ of the various implementations.  Generally the initial capacity of a collection is small, say `0`, `1`, `2`, `16`, etc.  Collection expansion is an expensive operation which can consume a lot of memory.  Collections are generally implemented with fixed length arrays.  `Dictionary<TKey,TValue>` uses two arrays internally.  To expand, a collection creates an empty array that is twice the length of its current array then performs an `Array.Copy` to copy the data from the initial array into the new array.  It then sends the original array to the garbage collector.

If you have a good idea about the number of items that will be in your list, you should specify the capacity using the proper constructor, if available.  You may be wondering when you will have an array with a huge amount of data.  Consider the `System.Text.StringBuilder` class.  It represents a `string` that can be dynamically expanded and is much more performant at creating a string that involves many concatenations.

Let's say that someone is reading in a file as a string line-by-line.  Let's also say that your `StringBuilder` reaches 512MB and has hit its maximum capacity.  Remember, it started small and doubled each time it needed to expand.  That 512MB will grow to 1.5GB at the time of expansion.  It creates an array that is double its current size and copies the original array into the new one which will be 1GB is size.  This doubling will easily eat up all of your available memory in short order.

A> The moral of the story is that you shouldn't read in files in such a way, which is a **common** mistake.  Most programmers don't know about the internal array\(s\) doubling.  I have seen it crash too much code.  If the programmer had, in our case, looked at the file size and say it was 640MB, he or she could have saved a _lot_ of memory by setting the default capacity to a) avoid the doubling to an enormous size and b) prevent the overhead of constantly having to expand the base arrays.  Also, always used `StringBuilder` when you need more than a few string concatenations.

## Back to `List<T>`

We can find the current _size_ of most collections by using the `Count` property; remember that `Array` uses `Length`.  Once we get into Linq, you will see some generic objects that use a `Count()` method, not a property.  The _capacity_ is the current length of the internal array whereas _count_ is the number of items in the array.

You can also loop through the array with `foreach` or using an indexer.  Let's look at _some_ of the interfaces associated with `List<T>`.  Many of these are shared between different collection types.

| Interface | Purpose |
|-----------|---------|
| `ICollection<T>` | `.Count`, `.Add()`, `Clear()`, `Contains()`, `CopyTo()`, and `Remove()` |
| `ICollection` | `.Count`, `CopyTo()` |
| `IList` | `[int]`, `.Contains()`, `.IndexOf()`, `.Insert()`, `.Remove()`, `.RemoveAt()` |
| `IList<T>` | `[int]`, `.IndexOf()`, `.Insert()`, `.RemoveAt()` |
| `IEnumerable<T>` | `.GetEnumerator()` - allows enumeration via `foreach` |
| `IEnumerable` | `.GetEnumerator()` - allows enumeration via `foreach` | 

Let's see a thorough example of using a generic list.

<<[Generic List Example](cs/ch13-01.cs)

As you can see, values are stored in the order in which they are added.  Also, you **must** check the `Count` _before_ accessing an list index!

A> There is one error that a lot of beginners will make.  When enumerating through a generic list, or any collection, you **must not** modify the the collection.  You can't `Add()`, `AddRange()`, `Remove()`, `RemoveAt()`, etc.  You _may_ modify the current object, but don't change the collection!  You will get an exception.  Also do not change a collection when using the `for` loop.  Those errors may be more insidious and harder to find.

### Jagged `List<T>`

As with arrays, you can create a `List<List<T>>`.  It's just the generic form of a jagged array or in this case a list of lists.  As with a regular `List<T>` you will have to add your new array to the list before being able to use it.

    List<List<string>> listOfLists = new List<List<string>>();
    listOfLists.Add(new List<string>());
    listOfLists[0].Add("a string");

Here we create our `List<List<string>>`, add a new element to it which is a `List<string>`, and finally use an indexer to access the first element in the list and call the `Add()` method on the `List<string>` instance contained in that element.  To access the value we just set:

    string s = listOfLists[0][0];

### `Stack<T>`

Related to our generic `List<T>` is `Stack<T>`.  A stack is a _LIFO_ collection.  LIFO stands for **l**ast-**i**n-**f**irst-**o**ut.  It describes an order to how we access elements this type of collection.

    Stack<string> ss = new Stack<string>();
    ss.Push("string 1");
    ss.Push("string 2");
    Console.WriteLine(ss.Pop()); // "string 2"

Imagine that you have a stack of dinner plates.  You create that stack by placing a plate on a table and you keep stacking them one on top of another.  The only way to remove a plate is to take it off the top.  This means that the last item added to the stack of plates is removed first.  Adding to a stack is done with the `Push()` method.  To remove an item from the stack you use the `Pop()` method.  This type of access forces the order in which you access the items on the array.  You can even iterate over the stack, having the values returned in the reverse order in which they were added.  Continuing our previous example:

    ss.Push("string 3");
    foreach(string s1 in ss)
    {
        Console.WriteLine(s1);
    }

`"string 3"` is printed first which is followed by `"string 1"`.  The iterator does _not_ remove any items from the stack.

The `Pop()` method has a counterpart in .NET Core which you can use to safely \(without an exception being thrown\).  `TryPop()` returns a `bool` of `true` if there is another element to remove from the stack.  It has an `out` parameter of the type of item in the collection and removes the last item added.  The `Peek()` and `TryPeek()` methods return the _next_ item to pop off of the stack _without_ removing it.

### `Queue<T>`

Closely related to the `Stack<T>` is the `Queue<T>`.  This is a _FIFO_ collection.  FIFO stands for **f**irst-**i**n-**f**irst-**o**ut.  The first item added to the collection is the first one to be removed.  With a `Queue<T>` we use methods called `Enqueue()` to add to the collection and `Dequeue()` to remove the first item added to the collection.  The first item added with `Enqueue()` is the first to be returned and removed with `Dequeue()`.

    Queue<string> qs = new Queue<string>();
    qs.Enqueue("1");
    qs.Enqueue("2");
    qs.Enqueue("3");
    if (qs.TryDequeue(out string firstValue))
        Console.WriteLine(firstValue); // 1

### Thinking Horizontally

If we think about stacks and queues as simple arrays that go from `0` to `n` length from left to right, this is how the arrays are affected by the various methods.  The first element of the array is _always_ index `0`.  Javascript, perl5, and other languages use the terms push, pop, shift, and unshift.

| push | add an item to the end of the array |
| pop | remove the last item of the array |
| shift \(enqueue\) | add an item to the beginning of the array, thereby shifting the other array indices to the right |
| unshift \(dequeue\) | remove the first element of the array, thereby unshifting the other array elements one to the left |

## Sorting a List

We had an extensive conversation about sorting strings in the .NET frameworks in [Chapter 3](#chapter-03-sorting).  It would be good to review that now.  Let us now look at how to implement our own sorting algorithm using a generic list.

A> JLC TODO... COME BACK TO THIS!!!

## `Dictionary<TKey, TValue>`

A `Dictionary<TKey, TValue>`, or generic dictionary, is a data structure in which each piece of data stores two objects: a _key_ and a _value_.  We call this a key-value collection.  Let's say that you wanted to map postal codes to cities: the key is the postal code and the city is the value.  If we create this collection then we only have to enter a postal code to get its related city.  A generic dictionary, however, is not like a print dictionary.  A print dictionary can list a word multiple times, once for each word form \(noun, verb, etc.\).  A generic dictionary's key must be unique.  You _can_ model a print dictionary with a generic dictionary, but that is a bit more complex.  Let's consider for the moment that record in our generic dictionary contains two pieces of data.

    Dictionary<string, string> cities = new Dictionary<string, string>(4);
    cities.Add("15206", "Pittsburgh");
    cities.Add("15108", "Moon Township");
    cities.Add("15222", "Pittsburgh");
    cities.Add("16365", "Warren");

This creates a new generic dictionary and adds four cities to it.  Here we are modeling cities in the Commonwealth of Pennsylvania in the United States.  In the US, we always store our postal \("zip\) codes as strings, even though they are numeric, as there are many that begin with a zero.  It's much easier to store them as strings.  US postal codes are 5 digits optionally followed by a dash `-` and four digits.

As you can see, we specify our data type for the key and value in between the angle brackets in our variable declaration.  The first type is the key's type and the second is the value's type.  The types used with `Dictionary<TKey, TValue>` can be any valid .NET object \(integral value types and their nullable counterpoints, strings, classes, enumerations, structs\).  

Why do we use dictionaries?  You could simply create an object with two string properties, postal code and city, loop through it with a `foreach` loop and check for the desired value with an `if` statement.  The problem with that is that it is very slow when compared with retrieving a value from a dictionary.  

Dictionary _entries_ are stored and looked up by their _hash code_.  A dictionary can also be called a hash.  The old .NET class for creating these types of data structs is called a `Hashset` from `System.Colections`.  We saw above in the struct section that we implemented a hash code.  The `GetHashCode()` method is on `object`, meaning that every .NET type has it.  A hash code is simply a 32-bit signed integer of type `int` that represents the unique value of our object.  It is a lot like a unique identifier.  .NET is very good at trying to make sure that these codes are unique and that they are quick to compute. 

When you add an object to a generic dictionary, it calls `GetHashCode()` on the object and adds it to the dictionary the hash code of the key.  When you go to retrieve the entry by its key, the hash code for the parameter is calculated and found \(or not\) in the dictionary.  This is called a _dictionary lookup_.  It is orders of magnitude faster than looping through an array or generic list.  We speak of the comparison between the two types of lookup in abstract terms using "Big-O Notation".  For further information, you can look it up on the web.

Here are some of the most important things to know about `Dictionary<TKey, TValue>`:

* A dictionary does **not** store its values in the order in which you added them.
* You **cannot** retrieve dictionary values in the order in which you added them.
* A dictionary iterator \(using `foreach`\) is **not** guaranteed to return values in the same order each time.  It _may_, but **never** rely on it.
* For the critics out there:  When creating a dictionary less than a certain number of items it _is_ more efficient to loop through an array and return the value.  This point is highly variable based on the framework implementation, runtime version, CPU, memory speed, etc.  Do **not** second-guess yourself and try to pre-optimize your code for this.  Use a dictionary where it make sense and a list where that makes sense.
* Just because it's called a "dictionary" does not mean that it is sorted.  It is not sorted by your key.
* Generic dictionaries are like generic lists as they are both not of a fixed size and have capacities and counts.  They also double once they reach their capacities.

A> I learned the hard way many years ago that, at least in .NET Framework 2.0, a generic dictionary was implemented internally with arrays.  I was sending out 10 network requests simultaneously and storing the returned values in a dictionary.  With that code I would get an exception on the `Add()` method telling me that the add failed while expanding the arrays.  What happened: 1.) I thought that `Add()` method could handle being called twice at the same time and 2.) I learned that it does not, especially while performing a slow operation such as expanding the capacity of the dictionary.
A>
A> We'll discuss concurrency, threading, and such in a later chapter.

We have already seen that a generic dictionary has an `Add()` method.  You can also add values by using the indexer, unlike the generic list.

    Dictionary<string, string> cities = new Dictionary<string, string>(4);
    cities["15232"] = "Shadyside";
    cities["15222"] = "Pittsburgh";
    cities["15232"] = "Pittsburgh";

    string s = cities["15232"];
    // s == "Pittsburgh"

There are three functions to the indexer on a generic dictionary.

* Add a key-value to the dictionary.
* Update a key's value in the dictionary.
* Return a value by key from the dictionary.

In the example above, you can see that we are calling the `set` indexer twice with the same value, `cities["15232"]`.  If the key \(specified by the value between the brackets\) does _not_ exist in the dictionary, the key-value pair is added as a new entry to the dictionary.  If the key _does_ exist in the dictionary, it acts as an _assignment_ and simply replaces the value that the key points to.

The `get` indexer isn't quite so forgiving.  If you try to retrieve a value by index and it _doesn't_ exist in the dictionary, it will throw a `System.Collections.KeyNotFoundException`.  This is the first framework exception that we have seen that does _not_ live in the `System` namespace.  If the key is found, the value is returned.  There are two ways around it.  The first way:

    if (cities.ContainsKey(keyToFind))
        Console.WriteLine(cities[keyToFind]);

Instead of calling the indexer twice, you should prefer the following.

    if (cities.TryGetValue("1111", out string theValue))
        Console.WriteLine(theValue);

Another try-type method we have is `TryAdd()`.  This will only add the key-value combination to the dictionary if the key does not exist in the dictionary.

    if (cities.TryAdd("15221", "Not Pittsburgh"))
        Console.WriteLine("success");

A> JLC TODO... stopping for the night.

    foreach

### Conclusion