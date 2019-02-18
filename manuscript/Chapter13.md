# Generics

We are going to begin our deep dive into the world of generics.  First, we had to wade through a _lot_ of important information on C# before we were able to realize the power of generics.  They are a quite complex issue to handle, so we will first start with how to _use_ generics then proceed onto how to _construct_ generic things.

A> To this point we have been almost solely focusing on objects contained in the `System` namespace.  For this and future chapters, we are adding `System.Collections.Generic` and `System.Linq`.  You will want to include those namespaces along with `System` in your `.cs` files.

## What is a generic?

In the olden times, long ago, before millennials roamed the planet, reusable objects that could store and perform actions on all objects had to cast everything to and from `object`.  With the .NET Framework 2.0 release Microsoft gave us generics.  They are a language and runtime construct that allow us to treat all objects the same way without having to box and unbox constantly, which as we have seen, can be very error prone.  How do you always know that an array of objects is always of a certain type?  Enter... generics.

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

## Jagged `List<T>`

## Sort



## Two More Flat Generic Collections

### `Stack<T>`

### `Queue<T>`

## `IConvertible<T>`

## `Dictionary<TKey, TValue>`