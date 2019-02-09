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

Multiple values in lieu of `InstrumentType`.

#### String Library

`public static readonly string` class

### Conclusion
