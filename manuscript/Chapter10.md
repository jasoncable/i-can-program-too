# Objects and Classes, Part 3

Hopefully we will be wrapping up our conversation about class members with this chapter.  Most other object types are made up of various combinations of the members that we have seen in our three chapters discussing classes.  They all have their own rules, but the ideas behind how they work are the same.  Let's discover two easy, two difficult, and one member that isn't necessarily a member at all!

## Operators \(Instance\)

We have already seen that the `+` operator works differently on numeric data types and strings.  For numerics, it performs the corresponding mathematical operation.  For strings, it concatenates them.  C# allows us to _overload_ these operators.  Operators can be placed in three groups by the number of things they work on.  We already saw the _ternary_ operator `?:` that requires three expressions.  _Binary_ operators are operators that require two things: `a + b`.  _Unary_ operators, such as `++` just work on one thing.

C# lets us overload many of the available operators to allow us to do special things with them.  Unfortunately, it doesn't stop us from doing _stupid_ things with them.  In this day and age it is _rare_ that only _you_ will use _your_ code.  Just _because_ you do something doesn't mean you _should_ do it.  __Don't__ overload the `+` operator to multiple two members on two classes.  __Do__ use the `+` operator to add two classes that each represent a matrix.  Enough preaching, let's see some examples.  To see which operators can be overloaded, just Google up "C# overloadable operators."

A> I mentioned matrix math as one use case of overloading operators.  Another would be representing things that cannot be represented in decimal form.  The imperial system of measurements is one target.  You could create a `Distance` class that allows for storing and performing operations on miles, feet, inches, etc.  We will be using an example that looks at another non-decimal system, old English money, mostly because the author likes old movies and Dickens.  Before you do something like this on your own, search GitHub and NuGet to see if it has already been accomplished.  We will be implementing this from scratch and improving on it throughout this book.
A>
A> For reference, there are 12 pennies \(or pence\) in a shilling and 20 shillings in a pound.  For simplicity we're ignoring amounts less than a penny.

    public static PreDecimalAmount operator +(PreDecimalAmount a, 
        PreDecimalAmount b)
    {
        return new PreDecimalAmount(a.ToPence() + b.ToPence());
    }

You will see the full class in a bit.  For now, let's look at the technical aspects of this new type of method.

Our class is called `PreDecimalAmount`.  This introduces yet another C# keyword, `operator`.  We place the operator that we are overloading last, next to the left parenthesis.  We are overloading the binary `+` operator which takes two parameters, in this case, two instances of our `PreDecimalAmount` class.  We then return a new instance of that class.  You should always return a new class instance when overloading operators.  It is not only expected, but if you don't, why not just add a method or such to your class.

To use the overload, simply add two instances of our `PreDecimalAmount` class as:

    var newAmount = a + b;

<<[PreDecimalAmount Class](cs/ch10-01.cs)

<<[Calling the Overloaded Operator](cs/ch10-02.cs)

You can only overload operators on instance of a class or a struct.  Don't forget to do the proper checking of values that will throw an exception or return certain special values when one is not set.  We looked at this when adding nullable ints.  When one of the `int`s is `null`, `null` is returned.  We might choose do that if one of the parameters is null, throw an exception, or treat the null instance as `0`.

You may also overload the `==` and `!=` operators.  _Both_ must be overloaded or your code won't build.  They return the type `bool`.  We will look at equality issues with complex objects when we get past inheritance.  There are specific rules that must be followed when dealing with the equality of complex objects.

We should also overload the `-` operator along with a few others to create a useful API.

## Type Casting and Boxing/Unboxing

To simplify our discussion of numeric types, we have skipped over type casting.  Another topic close to operator overloading is the ability to _implicitly_ or _explicitly_ convert between two different types.  We also need to briefly talk about boxing and unboxing.

A> Before _generics_ were introduced into the C# language and .NET ecosystem, we used to have to treat objects like `System.Object` in order to use classes which were written to provide functionality that worked on any type of object.  The `System.Collections.ArrayList` object, for example, was created to provide an object that acts like an array that can be automatically expanded.  It only _appears_ to auto-expand, but that is a separate story.  It takes things of type `object`, stores them, and allows you to perform operations on them.
A>
A> The process of making an object _appear_ to be of type `object` is called _boxing_.  In its simplest form, it would look like: `object o = (object)"My String";`  _Unboxing_ is the process of taking the object we created and turning it back into our original type: `string s = (string)o`.  This process is very error-prone and a cause of many problems.  The solution is _generics_, which will be discussed in a few chapters.

There are two types of type casting, explicit and implicit.  The following is an example of implicit type casting.

    int a = 1234;
    decimal b = a;

C# considers this a _safe_ type conversion.  We are creating a bigger, more precise data type, `decimal`, from a less precise \(no decimals\), smaller \(32-bit vs. 128-bit\) data type, `int`.  This means that `decimal` can hold the entire value of _any_ `int`.  That is why .NET does not force us to explicitly specify the type we are converting to.

    decimal c = 12.34m;
    int d = (int)c;

This is an example of an explicit type cast.  We have to add `(int)` to tell the compiler that we wish to accept the potential side effects of such a conversion.  This type of cast could result in an overflow exception if the decimal is too large and any data past the decimal point will be truncated, not rounded.

What was just described is the method to the madness.  These are the rules that the C# designers created to enforce certain coding patterns.  With our classes, we can make everything easy and simply perform all operations as implicit conversions.  It is important to use explicit conversions in places that make sense, especially when considering the rules that have been outlined.

There are times when you will use type casting for other purposes such as performing mathematical operations with binary operators of differing data types.  Division is one such case.  Consider the following:

    decimal d = 4 / 3;

What is the answer?  Why `1` of course!  C# treats bare numbers that look like integers as integers.  The division result has its decimal places truncated.  There are two ways around this:

    decimal f = (decimal)4 / (decimal)3;
    decimal g = 4m / 3m;

Both results are `1.33...`.  The `m` tells C# to treat the raw number as a decimal type.  If you are using variables for the numerator and/ denominator, you will have to use the `(decimal)` form.

    int h = 4;
    int i = 3;
    decimal j = (decimal)h / (decimal)i;

This gives us the correct result.

## Implementing Type Conversions

We saw in our earlier example of old English money that there are 3 classes, `OldPennyAmount`, `OldShillngAmount`, and `OldPoundAmount`.  They each do not support fractional values, only `int`s of the number of each type.  This is because fractional amounts specified in decimal form don't make much sense.  So, `OldPennyAmount` holds an `int` that specifies the number of pence that the object refers to.

We are going to create an implicit conversion from `OldPoundAmount` to `OldShillingAmount`.  To do that, add the following to the `OldPoundAmount` class.  One note, the `OldShillingAmount` has a constructor that takes, as an `int`, the number of shillings.

    public static implicit operator OldShillingAmount(OldPoundAmount pounds)
    {
        return new OldShillingAmount(pounds.Count * 20);
    }

To use the new implicit conversion:

    OldPoundAmount pounds = new OldPoundAmount(6);
    OldShillingAmount amt = pounds;

We will implement an explicit conversion from `OldShillingAmount` to `OldPoundAmount` due to the fact that you are possibly losing data in the conversion.  We add the following to the `OldShillingAmount` class.

    public static explicit operator OldPoundAmount(OldShillingAmount amt)
    {
        return new OldPoundAmount(amt.Count / 20);
    }

To use the new explicit conversion:

    OldShillingAmount shillings = new OldShillingAmount(132);
    OldPoundAmount oldPounds = (OldPoundAmount)shillings;

As you can see, we have the explicit conversion using integer division which truncates the excess decimal points.  These types of conversions should probably be avoided, as they result in a loss of data.

Either type of conversion can be specified in _either_ the source class or the target class.  This means that the implicit conversion _from_ `OldPoundAmount` _to_ `OldShillingAmount` can be in either one of those classes.  That means that you can create converts one of the framework types to a class that you created.

    public static implicit operator OldPoundAmount(int pounds)
    {
        return new OldPoundAmount(pounds);
    }

To use it:

    OldPoundAmount oldPoundAmount = 123;

 One final word: type casting needs not to exclusively be used for numeric values, as we have seen here.  They also apply to classes that hold multiple different types of data.

## Indexers \(Instance\)

You can implement indexers on a class just like we saw when using arrays.  This can be helpful if you want extra logic around getting and setting array elements.

    string[] sa = { "a", "b", "c", "d" };
    Console.WriteLine( sa[0] );
    // prints "a"

As you can see, the implementation looks a lot like properties, but there are subtle differences.  Note: you do not have to actually have to have an array to store the data you are accessing, but in this case, we will.

    public class Letter
    {
        private char[] _sa = { 'a', 'b', 'c', 'd' };
        public Letter(char c) => Current = c;
        public char Current { get; set; }

        public char this[int i]
        {
            get
            {
                return _sa[i];
            }
            set
            {
                _sa[i] = value;
            }
        }
    }

This class stores its data in a `char[]`.  The indexer is declared with the return data type, which can be anything including a new instance of the current class.  It uses the `this` keyword followed by brackets in which you specify the data type that the person using the code will pass in to retrieve or set the data.  Here's how to call the indexer we just created.  A get and a set are shown.

    Letter letter = new Letter();
    char c = letter[2]; // get
    letter[0] = 'a'; // set

If you are only implementing a set, you can use an expression-bodied declaration.

    public char this[int i] => _sa[i];

For implementing both a get and set with expression-bodied members:

    public char this[int i]
    {
        get => _sa[i];
        set => _sa[i] = value;
    }

A final note, you can have multiple indexers on a class as long as they take different data types \(in the area between the brackets `[]`\).

## Events \(Instance\)

There are times when you will want one class to tell another class that something happened.  An example is that if you have a class that represents a button on a screen, another class may want to know if that button was clicked and perform an operation when it was clicked.

First, you will need to create a class that has _events_ that others will want to listen to.  This class is called the _publisher_, as it publishes events that may be important.  It _raises_ events to notify others that an event took place.

The second class is called the _subscriber_.  It listens for events to be raised on the first class and _handles_ them, meaning it does something with them.  Multiple classes can subscribe to one event on a publisher. 



## Finalizers \(Instance\)

## Nested Types \(Static and Instance\)

### Conclusion
