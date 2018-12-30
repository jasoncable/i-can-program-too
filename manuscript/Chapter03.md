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

## Sorting and Encoding Strings

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

## Creating a String

> TMTOWTDI or "There is more than one way to do it."
>
> -Unknown Perl programmer

There are several ways to create a string.  To initialize a string as null:

    string s;
    string s = default;
    string s = null;
    String s = null;

To create an empty string, use one of the first two ways:

    string s = String.Empty;
    string s = "";
    string s = new String("");

To create a string with a value other than `null` or empty:
    string s = "my string";
    string s = new String("my string");

There are several others.  First, `string` can also be expressed by its .NET type of `String`.  They may be used interchangeably.  The same thing goes for `int` and `Int32`, etc.  Also, `String.Empty` and `string.Empty` can be used interchangeably.  Which you you is a up to you.  In this book you will see types used in their lowercase from and special members and methods on the `String` object in the Pascal Case.

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

You can use the `+` operator to combine two `string`s.  This is called string concatenation. 

    string s = "a and" + " b";
    // s created and set to "a and b"

Strings are immutable, therefore the following creates 4 strings in memory.

    string firstName = "John";
    string lastName = "Doe";
    string officialName = lastName + ", " + firstName;
    // officialName is "Doe, John";

You may also use the `+=` operator to add concatenate two strings.

    string name = "Doe";
    name += ", ";
    name += "John";
    // name is "Doe, John"
 
 If you are only using a few string concatenation operations, memory usage won't be _that_ bad.  In the next chapter, we will see how to make concatenation more efficient.

## @ Character

### In Strings

There are times when you do not want C# to interpret escape sequences.  On Windows systems, the directory separator character is a backslash.  Specifying a file in C# could look like this:

    "C:\\Users\\jcable\\Desktop\\my_file.txt"

To simplify this, C# provides a way of telling the compiler to not interpret escape characters.

    @"C:\Users\jcable\Desktop\my_file.txt"

This makes the code more readable.  They only special escape sequence that works in these verbatim string literals is `""` to show a double quote.

    string s = @"Here he is, ""Super"" Mouse";
    // s is: Here he is, "Super" Mouse

### In Variables

C# has a number of words that cannot be used as variable names.  We call these the reserved keywords.  Here are a few of them: `class`, `string`, `int`, `public`, `private`, `checked`, `for`, `foreach`, etc.

To use one of these as a variable name, prefix it with an `@` sign.  You must use the `@` sign every time you use the variable.

    int @class = 3;

Never, ever, ever do this!!!  It is a terribly bad practice and can only lead to confusion and poor code.  There is one exception, however.  This is fast-forwarding us about 66 chapters, but it is important to note the one exception to the rule...  In web development using .NET's ASP.NET Core MVC's Razor syntax, people often use anonymous types for including HTML attributes.  This often includes the @class and and @checked.

## Character Literals

One character may also be specified in C# code.  Instead of the `string`'s double quoted identifiers, `char` uses single quotes.

    char c = `,`;
    // define a char, c, with a value of a comma

Characters for the most part have the same escape sequences as `string`s with the exception of switching double quote for single quote.

| escape sequence | what it outputs |
|-----------------|-----------------|
| `\\`            | a backslash     |
| `\t`            | a tab           |
| `\n`            | a line feed     |
| `\r`            | a carriage return |
| `\x0041` or `\u0041` | a Unicode character `A` |
| `\'`            | a single quote `'` |  

## Nullable Types

### Value Types

Remember that value types \(`int`, `char`, `bool`, etc.\) all have default initial values that do not default to null?  Well, you can make these types _nullable_.  This means that they may sometimes be assigned a null value. To do this, we create a nullable version of the type with the `?` operator.

    int? i = null;

By using the `?`, we create a nullable integer.  There are several ways to create a nullable value.

    // i is null
    int? i;  
    int? i = null;
    int? i = default;
    int? i = default(int?);

    int? i = 1;

### Adding Nullable Numbers

The standard mathematical operations may be performed on nullable value types.  The rule to remember is that adding anything to a null will result in a null.

<<[Adding Nullables](cs/ch03-01.cs)

### Reference Types

A> #### The Number One C# Programming Error
A>
A> One of the classic sources of many bugs in C# is the old "object reference is not set to an instance of an object" error message from the NullReferenceException.  Until C# version 8, there was no good way of preventing this error.  It occurs when you try to use an object that is null.  We finally have a solution: the nullable reference type.

%% JLC: How do you enable?

To use the feature, it must be enabled.  It changes the way the compiler works.  When enabled, 

    string s = null; // not allowed
    string? s = null; // allowed

The compiler looks to see if you are trying to use a `string`, in this case, that may be null.

%% JLC: add some examples

## Array Basics

An array is a list of things.  You can think of a shopping list as an array of groceries.  Earlier in this chapter we talked about sorting strings.  The first step you take is to place the strings to sort into an array.

    string[] sa = new string[] { "life", "life-and-death", "life belt", 
    "lifeblood", "life-support", "life support", "LIFO" };

This is a _single-dimensional_ array.  It is a flat structure that is a simple list of things.  An array can be of any value or reference type.  This means that you can have arrays of numbers \(`int`, etc.\), characters \(`char`\), `byte`s, `string`s or just about anything else.

When you create an array, you specify the type of data it holds along with its size.  An array's size cannot be changed once created.  The size of an array is also called its _bounds_.  Also, the values are initialized to the default value of the data type unless you specify values in the variable assignment.

Brackets `[]` are used to tell us that something is an array.  They are also used to retrieve data from an array, which we will see in a bit.

There are, of course, several ways to create a single-dimensional array.

    // create an array of strings that can hold 5 values
    string[] sa = new string[5];

    // ...with values...
    string[] sa = new string[] { "a", "b", "c" };
    string[] sa = { "a", "b", "c" };

    // ...or...
    string[] sa;
    sa = new string[] { "a", "b", "c" };

A> ### A preview of generics.
A>
A> In C# we have a special concept called generics.  They were introduced in C# 2.0 in 2005.  They provide came with updated data structures for C# to make everyday programming easier than manual array manipulation.  The basic arrays we are talking about here are still used everyday, although usually for lower-level operations.  Network operations such as web servers operate in the form of passing `byte[]`s back and forth.  Nearly all I/O operations use arrays.  In fact, C#'s generic `List<T>` and `Dictionary<TKey,TValue>` are implemented on top of basic .NET arrays.  More on these later.  It is important to know that a basic knowledge of arrays is required to understand more advanced concepts, even if we don't directly use them every day.

To get data out of an array we can pull it out by index.  Slots in an array are all numbered, beginning at `0`.  In the following example, the the indexes are as follows.  Each index refers to what we call an element of the array.

    string[] sa = { "a", "b", "c", "d" };
    // "a" is 0
    // "b" is 1
    // "c" is 2
    // "d" is 3

`sa[0]` will give us the value of the first element of the array.  In this case we end up with `"a"`.

We can use this bare or assign it to a variable.

    string a = sa[0];

The new variable `a` points to the _value_ stored in the first array element.  It does _not_ point to the array's element itself.  It points to the data held within the element of the array.  This is important for a couple of reasons.  First, if we assign a different value to the variable `s`, `sa[0]` is _not_ updated.

    string a = sa[0];
    // both a and sa[0] contain the value "a"
    a = "ab";
    // a is now "ab"; sa[0] is still "a"

We will learn in a little bit that changing data on an object that is contained within an array element may be changed via the reference to the object.  In our case, re-assigning the value of the variable does not change the value in the array.  The assignment rule applies to both value types and reference types.

To update the values in an array element, you simply use the index for assignment.

    string[] sa = { "a", "b", "c", "d" };
    // to change element 0, the first element
    sa[0] = "new a value";

The special combined math/assignment operators also work on array references.

    int[] intArray = { 0, 1, 2 };
    intArray[0] += 5;
    // the first array element is now 5

A> #### The Number Two C# Programming Error
A>
A> The second most common programming error in C# is not checking the bounds of the array \(its length\) before trying to retrieve its value.  Below we will discuss how to do this.  Please remember, always check the length of an array before trying to pull a value from it!

## Multidimensional Arrays

An array may have multiple dimensions.  We have only been looking at single-dimensional arrays.  If you wanted to represent the data in a spreadsheet in array form you could use a two-dimensional array.  It is created as such:

    int[,] intArray = { { 1, 2 }, { 3, 4 } };
    // or
    int[,] intArray = new int[100,10];
    // this creates a two dimensional array that has
    // 100 columns and 10 rows \(in our example\)

To create an array that holds data like the following, do something like this:

    int[,] intArray = new int[5,4];
    intArray[0,0] = 0;
    intArray[1,0] = 1;
    ...
    intArray[3,3] = 5;
    ...

| 0 | 1 | 2 | 3 |
| 1 | 2 | 3 | 4 |
| 2 | 3 | 4 | 5 |
| 3 | 4 | 5 | 6 |
| 4 | 5 | 6 | 7 |

In this example, I am treating the first dimension as rows and the second dimension as columns.  You could easily treat it the opposite way, such as considering the first dimension to be an `x` value and the second to be a `y` value.

Retrieving values is as easy as:

    int x = intArray[2,3];

You may also use the array initializer syntax as follows:

    int[,] array2D = new int[,] 
        { 
            { 1, 2 }, 
            { 3, 4 }, 
            { 5, 6 }, 
            { 7, 8 } }
        };

A three-dimensional array follows the same rules.  Going beyond three dimensions really should be avoided.  You will probably find other data structures that are easier to use.

## Jagged Arrays

C# also supports jagged arrays, also called an array of arrays.  These are named because the dimensions are not of a fixed length.  You can see it thusly: a jagged array defines a base array where each element contains an array.

To create a jagged array, you must specify the size of the base array, but not the arrays it contains.  The following code creates an a jagged integer array.

    int[][] intArray = new int[3][];

To finish creating our array, we need to add arrays that will hold the data.  Our base array only holds references to the other arrays.

    intArray[0] = new int[5];
    intArray[1] = new int[7];
    intArray[2] = new int[2];

We can also use the array initialization syntax.  In this case, you do not have to specify the size of the array, as it is inferred by the number of items between the braces `{}`.

    intArray[0] = new int[] {1,2,3,4,5};

To set data in a jagged array, in this case the third element of the first array.  As this is an array of arrays, we specify the data locations a little bit differently than in a multidimensional array.  Instead of `intArray[0,0]`, we use the following.

    intArray[0][2] = 55;

One last thing of note, the base array of a jagged array may contain multidimensional arrays.

    int[][,] jmArray = new int[3][,];
    jmArray[0] = new int[3,4];
    jmArray[0][0,0] = 42;

### .hasValue vs == null

### type checks

### array length checks

### Control structures
* if then else if else
* do while while do
* foreach
* switch
* goto
* for

> "The __go to__ statement should be abolished from all "higher level" programming languages."
>
> -Edsger Dijkstra \(1968\)

### references on array objects

NO GOTOs