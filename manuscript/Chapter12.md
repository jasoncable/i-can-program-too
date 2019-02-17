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
* Structs _always_ have a _default_ constructor \(one without parameters\).  It cannot be explicitly defined.
* Stucts cannot have finalizers.
* When a copy of a struct is made, as with C#'s integral value types, its values are copied.  You do not have a reference to an instance of that struct.
* Creating an instance of a struct doesn't require the `new` keyword.
* Structs may implement interfaces, but cannot inherit from classes or other structs.  
* Structs can't be used like a base class.
* A struct cannot be null unless using a nullable variable.

We will be seeing an example of a struct version of our old British money sample from an earlier chapter.  It is a good example of what a struct _should_ be used for.  Structs have traditionally been used to define types that hold a value where you want the implementation to remain hidden.  We often use structs when representing date/time values and guids \(globally unique identifiers\).  In our example, we are storing our monetary values as total pence.  We are not separating out pounds, shillings, and pence.  If done properly, this should make dealing with this old money amounts fairly easy.

One interesting thing to note: we are used to instance fields and auto-properties to have their default values set for us.  This is handled by the implicit default constructor in structs.  If you have a constructor in a struct it must have parameters and _each_ constructor _must_ initialize the instance fields and auto-properties to a value.  In classes, instance types such as `int` default to `0` without us having to do anything.  In a struct, the default constructor does this.  To make it happen automatically, you should call add `: this()` to your constructor's declaration which will auto-initialize all instance fields and auto-properties.

You will see in this example that we have used a `ulong` for our pence value as it is the largest native C# integer data type.  A negative value is specified by a `bool`.  We could also use a `decimal` as it is also a large number.  In the end, it was a little more interesting to show how multiple data types can be used together to represent a value with a struct.

<<[Old Pounds Sterling Amount as Struct](cs/ch12-01.cs)

There is a lot going on here.  Let's break it down.  First, we are using many of the concepts that we have learned earlier.  Specifically, we have:

* `static readonly` fields.
* Expression-bodied members.
* Constructors with parameters.
* Constructors that call other constructors.
* Exception throwing.
* Type casting.
* Auto-properties and auto-properties with expression bodied members.
* Static properties.
* Methods.
* Operator overloading.
* Method overriding of `.ToString()`.

These concepts are represented here to give you a feature-rich example of how all of these concepts may be used in real life.  There are a couple of ways this implementation could be better.  The most important one is that our backing values, `TotalPence` and `IsNegative` _should_ be stored in private instance fields in structs.  This makes it easier to specify the _layout_ of the struct.  Stucts, unlike classes, store their internal data in the order in which it is defined.  There may be memory optimizations associated with this, but that is beyond the scope of this book.  Let us now look at equality checking with structs and classes.

## Equals and GetHashCode

When you check to see if two classes are equal with `==`, the default behavior is to check to see if both instance variables of that object are pointing to the same instance in memory.  There are times that we will want to override that behavior.  There are several steps to implementing this.  In a struct, the `==` operator will need to be manually implemented.

* Override the `Equals()` method.
* Override the `GetHashCode()` method.
* Implement `IEquatable<T>`.
* In addition to the above, for structs:
    * Implement the `==` operator.
    * Implement the `!=` operator.

All of these are implemented in our example above.  Let's take them one by one.

The `Equals()` method on `object` is an instance method that takes an object as a parameter.  `this` is always guaranteed to be an instance of our type, as it represents the instance of the object that contains the override of the `Equals()` method.  Your checks in here should first check to see if the `object` parameter is of the correct type.  Next, compare the values of each piece of data that makes your class or struct instance that make it _unique_ from another instance.  In the sample, we have already implemented the `==` operator and we use it to check the equality in the `Equals()` method.  This does not work for a class.

The `GetHashCode()` method provides a way to differentiate different instances of an object when you are using a data structure that uses `GetHashCode()`.  We will learn more about these data structures in the next chapter.  There are a couple of ways to perform the calculation that returns a hash code.  A hash code is a 32-bit signed integer that represents the _uniqueness_ of your object.  In our struct example we use the `HashCode.Combine()` method.  You could also do the following.

    return TotalPence.GetHashCode() ^ TotalPence.GetHashCode();

The `IEquatable<T>` interface is a generic interface that gives us an `Equals()` method that has a parameter of the type of our object _in addition to_ the `object` version.  Generics are introduced in the next chapter.  For now, follow the pattern presented in our example code.

Structs must also implement the `==` and `!=` operators.  These were explained in a previous chapter.

The result of all of this is that you will have a class or struct whose underlying values are compared in order to be able to check the equality of the aggregate _data_ contained in the instances.  You will not always be checking _all_ of the data contained within the instance, but sometimes only part of it.  The amount of data you are comparing should be thoroughly be documented to assist others that my be using your classes/structs.

## Useful Framework Structs

The various .NET frameworks all have the following three structs that are used in most applications.  We will use them as an example of how structs are used and their importance.

### `Guid`

A guid is a **g**lobally **u**nique **id**entifier, sometimes called a UUID.  It is a struct that represents one of a large number of possible values.  C# uses a _type/version 4_ guid that is implemented in the `System.Guid` struct.  A guid is a 128-bit number with a few bits reserved for the version of guid and some other things.  C# guids can have represent 2^122^ different values.  There is an extraordinarily slim chance of any two guids being the same.   Guids are generally represented in string form as hex characters that are dash separated.  The letters may be in upper or lowercase.

    d5d51a13-1fe3-418f-a44f-bb3eb9e79288

A guid in .NET Core is implemented as a struct with the following data types making up the guid: 1 `int`, 2 `short`s, and 8 `byte`s.  Together that is 128 bits.

We use guids when we need a unique ID for any piece of data.  They are often used databases to uniquely identify a record such as a table row, document, or object.  Real-life examples of unique identifiers include:

* \(US\) Social Security Number
* Driver's License Number
* Passport Number
* Network Interfaces \(MAC Address\)
* Bluetooth Chips
* DNS Numbers \(IP Address\)
* Cell/Mobile Phones \(IMEI\)

To create a new guid, use the following.

    Guid g = Guid.NewGuid();

The following return a _new_ `Guid` empty instance, `00000000-0000-0000-0000-000000000000`.  It is a common mistake to use the default constructor version thinking that you are creating a new unique number.

    Guid g = new Guid();
    Guid.Empty;

To create an instance of a `Guid` from an existing string, the `string` constructor usually will suffice.  If the string form of the guid is malformed, you will get an exception.  In that case, you should prefer to receive an exception.  The `string` constructor handles string guids with or without dashes and upper and lowercase guids.

    Guid g = new Guid("425aafee-c7c0-459d-a82c-a62ebdf368db");

To get a string version of the guid, simply use the `ToString()` method.  `ToString()` also takes a string to specify the format you wish to output.  The string consists of a single character.  The following are the most common forms of guid string representations.

* `n` - no dashes, lowercase
* `N` - no dashes, uppercase
* `d` - dashes, lowercase \(default for `.ToString()` without parameters\)
* `D` - dashes, uppercase

### `DateTime`, `DateTimeOffset`, and `TimeSpan`



### Conclusion
