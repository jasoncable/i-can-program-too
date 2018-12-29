# Strings, Arrays, and Logic

## Strings

Strings are reference types.  The variable that you create to made a new string only points to the actual data, it does not contain the data.  Strings are also immutable.  They cannot be changed once created.  You can, however, change the reference that your string variable points to.  Strings are also objects, which we will learn more about in the next chapter.  Let's check it out.

    // create string, s, and assign the value "C# String 1"
    string s = "C# String 1";

`"C# String 1"` is created and saved to the computer's memory.  The variable `s` currently points to it.  Continuing, 

    // create a NEW string, "Another String" and
    // point the variable s to it
    s = "Another String";

So now, we have two strings in memory: `"C# String 1"` and `"Another String"`.  Only one of these has a reference to it.  `s` references `"Another String"`.  You can no longer access the string, `"C# String 1"`.  The .NET runtime tracks the references to each object \(at least objects that are reference types\).  Remember that everything in C# can be _treated_ as an object, but we are only referring to reference types here.

## Garbage Collection

When the .NET runtime determines that an object is no longer being used, such as when no references point to it, it is marked as eligible for garbage collection.  C#, like Java and unlike C and C++, employs a system to take unused objects from the heap and place them into the garbage collection heap.  There are three garbage collection heaps called generation 0, 1, and 2.  The first stop for our string `"C# String 1"` will be generation 0 \(gen0\).  

.NET employs garbage collection as a way to make it easier on programmers to develop software.  With .NET we do not have to manually allocate and deallocate memory.  Memory allocation is the process of telling the computer that we want to use the memory in the machine that resides at XYZ location.  This does not mean that C# code is free of memory leaks.  The result of a memory leak in an application that runs a long time is its increasing use of memory that is no longer being used.  There are many causes of memory leaks, many of which, in C#, stem the programmers use of the `string` object.  Memory leaks are often very difficult to diagnose and require advanced techniques including the use of a "native" debugger, such as the Windows debugger, `windbg.exe`.

The .NET garbage collectors run at varying times.  gen0 is run the most frequently, whereas gen2 is run the least frequently.  Not all objects will be be moved \(promoted\) from one generation to the next.  It is enough to know that objects in gen2 were promoted from gen1 and previously from gen0.  Objects that make it to gen2 tend to be ones that were active in the program for long periods of time.

Objects that are larger than 85,000 bytes are placed on the large object heap.  These objects are garbage collected when the gen2 collection runs.  Objects on the large object heap are deleted directly without being placed in any of the garbage collection heaps.  Each character in a string is two bytes long, therefore, a string that is 42,500 characters or longer will be placed on the large object heap, not the standard heap.

Garbage collection is rarely a problem.  It should not be called directly, though it may be.  Your code should always respect the garbage collection process.  You don't generally need to know the internal working of the garbage collector, but knowing that it exists and some of the basics will come in handy when performing advanced debugging techniques.

## Back to Strings

### Sorting and Encoding

Since computer hardware only knows about numbers, the text that we type is converted into its numeric equivalent to be understood by the computer's processor.  We call this character encoding.  There are several character encodings.  Have you ever noticed that when things are sorted by a computer that numbers come first, followed by capital letters, then by lowercase letters?  Have you ever noticed that printed dictionaries have different sorting compared to something that was computer sorted?  Have you seen numbers sorted in this order: `1`, `11`, `2`, `3`?  This is all due to character encodings and sorting algorithms called collations.  

A> For our purposes, an algorithm is a piece of code that performs a task in a specific way.  Algorithms are used to define how to do something.  Sorting is one type of algorithm.  It may be implemented in any one of many ways.  For sorting, we provide the algorithm with a list of `string`s which outputs a list of `string`s.
A>
A> Let's focus on two types of algorithms for a minute.  The first type, a deterministic algorithm, will always produce the same result for the same data that is used as its input.  We always want our `string`s to be sorted the same every time we call the sort algorithm.  The second type, nondeterministic algorithms, are typically much harder to create.  They return different results each time they are run.  An example of this would be if we wanted to randomly pick someone's name from a list.

| dictionary sorted | C# sorted \(default\) | C# sorted \(ordinal\) |
|-------------------|-----------------------|-----------------------|
| life              | life                  | LIFO                  |
| life-and-death    | life belt             | life                  |
| life belt         | life support          | life belt             | 
| lifeblood         | life-and-death        | life support          |
| life-support      | life-support          | life-and-death        |
| life support      | lifeblood             | life-support          |
| LIFO              | LIFO                  | lifeblood             |

The first column in our table shows the sort order used in Merriam-Webster's Collegiate Dictionary, 11th Edition.  It sorts in a case-insensitive way where upper- and lower-case letters are treated as the same \(a equals A\) and ignores dashes and spaces.  The second column shows the default .NET sort order of .NET Core on macOS.  The third sorts by the numerical equivalent of the characters in Unicode.

%% https://docs.microsoft.com/en-us/dotnet/standard/globalization-localization/performing-culture-insensitive-string-operations?view=netframework-4.7.2

A> __Important Note:__  It is a very bad idea to rely on .NET's default sort order.  On Windows, .NET's default encoding is set by the operating system.  This applies to both the .NET Framework and .NET Core.  It may vary slightly by operating system version.  On Linux and macOS, .NET Core uses the Unicode Collation Algorithm by default.  If you are writing your code to be run on multiple systems, you results could differ depending on which system it is running on.
A>
A> .NET also has a concept called culture.  Culture is generally a combination of the language \(ex. English\) and the country \(ex. United States\).  This is expressed by the two character language code and the two character country code separated by a dash \(ex. en-US\).  You will often see things sorted by the current culture in a case-insensitive manner.
A> 
A> If you are writing something such as a web application, your application will use the sort order specified on the machine that is running the code.  If you tell it to use the default culture, it will default to that which is specified on the machine running the code, not the machine running the web browser.

In the 1960s, two types of character encodings emerged and became prevalent, EBCDIC from IBM and ASCII from early automated telegraph machines.  The two are not compatible.  The numerical representation of the numbers in one are not the same in the other.  One major difference is that in EBCDIC, lowercase letters come before uppercase letters.  Both encodings were designed and developed for the English language.

.NET stores characters in a form called UTF-16.  There are two other UTF types called UTF-8 and UTF-32.  They all refer to how a character is stored in memory.  They all use the same character set called Unicode.

Programming on small, non-mainframe, systems, ASCII was the preferred character set.  This evolved, at least in the United States, into a character encoding called ISO 8859-1 or Latin-1, which included more characters.  Windows in the US evolved using what is called Code Page 1252, which was meant to be compatible with ASCII and Latin-1.  Unicode developed from the these traditional encodings.  It is compatible with ASCII and Latin-1.  Unicode defines 100,000 characters, whereas ASCII  defines 128 characters.  Unicode has become the standard to use as it allows computers to communicate in all languages.  For the most part, you will use UTF-8 encoding.  It is the most widely used on the web and in communicating between two machines.

All of this is important for several reasons, especially when sorting `string`s.

* Do upper- or lower-case letters come first?
* Do we treat upper- and lower-case letters as the same?
* Do we consider characters with diacritical marks to be the same or different.  Example: `a`, `à`, `á`, `â`, `ä`, etc.
* Certain written languages sort diacritical marks differently.
* How do we treat right-to-left languages \(such as Arabic and Hebrew\)?
* How do we order to non-text characters come such as whitespace \(spaces, tabs\), dashes, underscores, etc.?
* How do we treat numbers in our sorts?  Do we sort digits or do we sort the whole number?
* How do we sort dates?

Most .NET methods for sorting strings offer ways to customize the sort.  We will cover these in subsequent chapters.  We will also cover the issues with displaying numbers and dates.

### Creating a String

There are several ways to create a string.  To initialize a string as null:

    string s;
    string s = default;
    string s = null;

To create an empty string, use one of the first two ways:

    string s = String.Empty;
    string s = string.Empty;
    string s = "";
    string s = new String("");

To create a string with a value other than `null` or empty:
    string s = "my string";
    string s = new String("my string");

There are special ways to handle special characters in our strings.  Some characters require escape sequences.  An escape sequence is a way of specifying certain types of characters.  These all start with a backslash \(\\\).  The following list covers sequences that are commonly used.

| escape sequence | what it outputs |
|-----------------|-----------------|
| `\\`            | a backslash     |
| `\t`            | a tab           |
| `\n`            | a line feed     |
| `\r`            | a carriage return |
| `\x0041` or `\u0041` | a Unicode character `A` |
| `\"`            | a double-quote `"` |      

The strings between double quotes \(string literals\) do not span multiple lines.  The following is NOT allowed in C#:

    string s = "Hello
    there";

To add a new line in C#, use:

    string s = "Hello\nthere";

As you can see, we have used the new-line escape character.  

A> A note about line endings in Windows versus Linux and macOS.  On Windows systems, a line ending is in actually a carriage return followed by a line feed, `\r\n`.  In C# this is automatically handled by using the `\n` character.  If you code C# on Windows then switch over to Linux or macOS, you will see that the lines end in `\r\n`.  Linux and macOS generally don't understand this difference.  You may see carriage returns show as the unprintable character `^M` also known as Control+M.

### Concatenation

### Character Literals

### String Interpolation

### @ Character

### Splitting Strings

### Joining Strings

### Convert.ToString()

### Nullable Strings