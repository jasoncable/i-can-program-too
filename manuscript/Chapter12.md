# Creating Value Types

C# allows us to create our own value types.  To this point we have been focusing on reference types, specifically, classes.  Now we will pivot and take a look at two special value types.

## Enumerations

An enumeration in C# is a special type that allows us to pass around numeric values that are named.  Enumeration values can be any C# integer-based numeric-like integral value type except for `char`.  That mouthful of words just means that you should only create enumerations with the following types: `byte`, `sbyte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`.  Enumerations are by default based on `int`.

    public enum PianoType
    {
        Upright,
        BabyGrand,
        FullConcertGrand
    }

Here is a quick overview of what you can do with an enumeration.

    PianoType pt = PianoType.FullConcertGrand;

    if (pt == PianoType.FullConcertGrand) { }

    pt.ToString(); 
    // returns "FullConcertGrand"

    int i = (int)pt;
    // i == 3

    PianoType pt1 = (PianoType)1;
    // PianoType.Upright

Let's take a step back and see what we've done.  First, we declared an enumeration using the `enum` keyword.  It's underlying value is an `int`.  We can explicitly set the type using the colon followed by the type.

    public enum MyEnum : long { ... }

Next, we create an instance of the `PianoType` enum with three values.  You may explicitly set the values.  The default behavior is that the first value is `0` and is incremented from there.  In our sample, `Upright` is set to the value `0` and `FullConcertGrand` is set to `2`.

We continue with checking the value of `pt` against the enum's value.  Enumerations have instances, yet their values may be checked against what appears to be a static representation of the named value.

Enumeration names and their value names are almost always in pascal case and follow the standard C# naming rules.  They don't follow any specific naming _conventions_, but this author's enumerations usually end with the word `Type` because enums tend to be used to describe a characteristic of an object.

We can specify the number values used in an enumeration.  It will become clear why this is important.  It can also be used to help map integer values from a database or another type of external data source to an enumeration.

    public enum PianoType
    {
        Upright = 2,
        BabyGrand = 3,
        FullConcertGrand = 4
    }

It is always wise to include a default value that is 0 and is called something such as `NotSet`, `Unset`, `Undefined`, or `Invalid`.  This is mostly due to the fact that the default value of the enum's underlying type is 0.  If you want the enum to start numbering at `1` you only need to specify the number once.

    public enum PianoType
    {
        Upright = 1,
        BabyGrand,
        FullConcertGrand
    }

Above you can see that we can easily check an enum instance's value with `==`.  The `.ToString()` method prints the name of the enumeration value.  We can also cast an enum instance's value to a numeric type.  This is often useful when saving the enumeration's value to a data store.  

An instance may also be created by explicitly casting a number value to that enumeration type.  You __must__ be extraordinarily careful when doing this.  You can easily set an enumeration instance value to an unspecified value.  Consider the following.

    PianoType pt = (PianoType)5;

In our previous sample, there is _no_ enum value that represents the number `5`.  This does _not_ throw an exception nor does it cause a compiler warning or error.  There _is_ a static method on the `System.Enum` object that allows you to check to see if a number has a defined value on you enumeration.  This method also can be passed a string to see if that enumeration member's name exists.  It returns a `bool`.

    Enum.IsDefined(typeof(PianoType), 5);
    Enum.IsDefined(typeof(PianoType), "Upright");

A better way to check for the existence of an enumeration by member name is to use `Enum.TryParse`.  This is where you will want to have an "undefined" value on the enumeration so you can check for it later.

    public enum PianoType
    {
        None = 0,
        Upright = 1,
        BabyGrand,
        FullConcertGrand
    }

    PianoType pt;
    if (Enum.TryParse(typeof(PianoType), "Upright", out object obj))
        pt = (PianoType)obj;
    else
        pt = PianoType.None;

This is a little ugly.  It gets better which we will see when generics are introduced.

A> I always explicitly set an enum member's value.  That way you help prevent other programmers from adding a new member in the middle of the member list that will most likely break code if your data is saved to any data store or sent via JSON or XML to an external service.

Enumerations, being value types, can also be declared as being nullable.  A nullable enumeration is treated similarly to another nullable value type such as `int`.

    PianoType? pt6 = null;

## Flags

There are times when you will need to assign multiple values from one enumeration to a variable.  You can do this with an array, but it is equally as easy to use the `FlagsAttribute` attribute.

In C#, attributes are used to provide extra information about an object, member, or parameter.  Attribute names always end in the word `Attribute`.  When using an attribute you do not need to include the word `Attribute`.  We will look at attributes in length later, but for now, we will do the following to add the `FlagsAttribute` to an enumeration like this:

    [Flags]
    public enum InstrumentFamily
    {
        None = 0,
        String = 1,
        Percussion = 2,
        Woodwind = 4,
        Brass = 8
    }

The flags attribute tells C# to treat each enumeration member _bitwise_.  That is, each value is represented by a binary position.  Each value is a power of `2`, starting with `1` or 2^0^.  In binary, each enumeration member is represented by having one bit _on_.  The following binary values would represent the values `1`, `2`, `4`, and `8`, respectively.

    00000001
    00000010
    00000100
    00001000

With a flags enum, we can combine these values to allow us to have multiple values pointed to from one enum instance.  A piano is both a string instrument and a percussion instrument, therefore it would be the combination of those binary representations.

    00000011

The good news is that we don't have to manually do this binary math.  C# provides features to do this.  Let's use a more useful example that you might encounter in real life programming.  We are creating an enumeration that specifies different access levels for a website.  The final enum member will be explained in a minute.

    [Flags]
    public enum AccessLevel
    {
        None = 0,
        Admin = 1,
        Reader = 2,
        Writer = 4,
        Commenter = 8,
        All = Admin | Reader | Writer | Commenter
    }

With C# 8, we can actually write the numbers _in_ binary.

    [Flags]
    public enum AccessLevel
    {
        None = 0,
        Admin =     0b00000001,
        Reader =    0b00000010,
        Writer =    0b00000100,
        Commenter = 0b00001000,
        All = Admin | Reader | Writer | Commenter
    }

If you want an enumeration instance to represent both `Reader` and `Writer` we write it like this.

    AccessLevel al = AccessLevel.Reader | AccessLevel.Writer;

`|` is called the _logical OR_ operator.  We can also build up the flag values in multiple statements.  You might do this in a loop or over multiple `if` statements.  We can set the initial value to `0` or `None` because it is _not_ a flag.  A `0` value is the _absence_ of all the other values.

    AccessLevel al = AccessLevel.None;
    al |= AccessLevel.Reader;
    al |= AccessLevel.Writer;

To subtract a value, we use the _bitwise negation_ operator, `~`, and the `logical AND` assignment operator.  The following removes the `Writer` value from `al`.  In essence, we are flipping the bit in our `int` that represents the `Writer` value from `1` to `0`.

    AccessLevel al = AccessLevel.Reader | AccessLevel.Writer;
    al &= ~AccessLevel.Writer;

To check for the presence of a set value on a flags enum instance:

    if((al & AccessLevel.Reader) == AccessLevel.Reader)
    { 
        Console.WriteLine("Got it!"); 
    }

There is an easier way to see if a flags enumeration has a certain value set.  The following returns a `bool`.

    al.HasFlag(AccessLevel.Admin);

A> While I'm not a fan of manually manipulating bits, it is useful in flags enumerations.  C# does have an entire complement of C/C++-like operators for doing so.  There are limits to flags enums.  For example, you can have a limited number of flags enum members due to the size of the underlying data type that you are using.  An `int` only has 32-bits after all.

## String Library

This is somewhat unrelated to enumerations and comes up in questions about enums.  We often we just want a string value that we access _like_ an enum.  Remember, enum member names cannot contain spaces or many different types of special characters.  For class that contains hardcoded strings, you should create a static class with `public static readonly string` members.

    public static class StringLib
    {
        public static readonly string VersionNo = "8.0.0";
        public static readonly string Language = "C#";
    }

    Console.WriteLine( StringLib.Language );

## Structs

A struct is a reference type in C# that is akin to a class, except for the type that it inherits from `System.ValueType` which itself inherits from `System.Object`.  Also like reference types, structs are stored on the stack, not on the heap.  Let's look at some rules relating to structs.

* Fields can only be initialized if they are static, defined with `const` or `static`.
* Stucts cannot have a _parameterless_ constructor, but may have constructors containing parameters.
* Stucts cannot have finalizers.
* When a copy of a struct is made, as with C#'s integral value types, its values are copied.  You do not have a reference to an instance of that struct.
* Creating an instance of a struct doesn't require the `new` keyword.
* Structs may implement interfaces, but cannot inherit from classes or other structs.  
* Structs can't be used like a base class.
* A struct cannot be null unless using a nullable variable.



### Conclusion
