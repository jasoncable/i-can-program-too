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

## Indexers \(Instance\)

## Events \(Instance\)

## Finalizers \(Instance\)

## Nested Types \(Static and Instance\)
