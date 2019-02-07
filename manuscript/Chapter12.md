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

Next, we create an instance of the `PianoType` enum with three values.  You may explicitly set the values.  The default behavior is that the first value is `1` and is incremented from there.  In our sample, `Upright` is set to the value `1` and `FullConcertGrand` is set to `3`.

We continue with checking the value of `pt` against the enum's value.  Enumerations have instances, yet their values may be checked against what appears to be a static representation of the named value.


## pascal case
## should have a 0 or unset

## explicit cast with bad value

## nullable
## flags



#### String Library

`public static readonly string` class


### Conclusion
