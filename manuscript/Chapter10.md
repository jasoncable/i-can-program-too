# Objects and Classes, Part 3

Hopefully we will be wrapping up our conversation about class members with this chapter.  Most other object types are made up of various combinations of the members that we have seen in our three chapters discussing classes.  They all have their own rules, but the ideas behind how they work are the same.  Let's discover two easy, two difficult, and one member that isn't necessarily a member at all!

## Operators \(Instance\)

We have already seen that the `+` operator works differently on numeric data types and strings.  For numerics, it performs the corresponding mathematical operation.  For strings, it concatenates them.  C# allows us to _overload_ these operators.  Operators can be placed in three groups by the number of things they work on.  We already saw the _ternary_ operator `?:` that requires three expressions.  _Binary_ operators are operators that require two things: `a + b`.  _Unary_ operators, such as `++` just work on one thing.

C# lets us overload many of the available operators to allow us to do special things with them.  Unfortunately, it doesn't stop us from doing _stupid_ things with them.  In this day and age it is _rare_ that only _you_ will use _your_ code.  Just _because_ you do something doesn't mean you _should_ do it.  __Don't__ overload the `+` operator to multiple two members on two classes.  __Do__ use the `+` operator to add two classes that each represent a matrix.  Enough preaching, let's see some examples.  To see which operators can be overloaded, just Google up "C# overloadable operators."

A> I mentioned matrix math as one use case of overloading operators.  Another would be representing things that cannot be represented in decimal form.  The imperial system of measurements is one target.  You could create a `Distance` class that allows for storing and performing operations on miles, feet, inches, etc.  We will be using an example that looks at another non-decimal system, old English money, mostly because the author likes old movies and Dickens.  Before you do something like this on your own, search GitHub and NuGet to see if it has already been accomplished.  We will be implementing this from scratch and improving on it throughout this book.
A>
A> For reference, there are 12 pennies \(or pence\) in a shilling and 20 shillings in a pound.  For simplicity we're ignoring amounts less than a penny.  **This solution does not handle negative amounts.**

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

If you are casting from a `long` to an `int`, however, if the `long` value is too big, the number conversion will end up being negative due to the way the runtime converts between data types.  In the following code, you will also notice that we have had to place `(long)` in the expression that adds `8` to the value.  This is required to force C# to treat the addition operation on `long` versions of the specified values.

    int z1 = Int32.MaxValue;
    long z2 = (long)z1 + 8;
    Console.WriteLine(z2); // 2147483655
    int z3 = (int)z2;
    Console.WriteLine(z3); // -2147483641

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

A> There are literally a million and one ways to do this.  I'm showing a simple example to show the mechanics of it.  There is a chapter later on that will discuss threading, synchronous and asynchronous operations, and concurrency issues.

To create a publisher, we will be using the `EventHandler` class which is found in the `System` namespace.  The following line defines a member named `RaiseEvent` of type `EventHandler` using the `event` keyword.  To keep our example easy to use, we will not be passing any data between the two objects.

    public event EventHandler RaiseEvent;

We now have a new member of type `event`.  `event` is actually a wrapper around another framework type called a `delegate`.  It makes it a little easier for us to use.  

In our subscriber class, we will create a method that is to be run each time the publisher raises an event.

    public void HandleEvent(object sender, EventArgs e)
    {
        Console.WriteLine("Handled!");
    }

This requires a very specific method signature that comes from the `EventHandler` delegate.  The first is a reference to the class from where the event is raised \(the publisher\).  Next comes an instance of the `EventArgs` class which gives us a way to pass data from one method to another.  If you are sending data, `EventArgs` acts as the class from which you will derive a custom created class.

The subscriber now has to actually subscribe to the publisher's `event`.  We use the `+=` operator for this.  `-=` is used to stop the subscriber from listening to the publisher.

Before we see the finished product, we need to raise an event in the publisher by invoking the instance of the `EventHandler` class.  The following line uses the `?.` operator to say, if `RaiseEvent` is not `null` which means that there is at least one subscriber to the `EventHandler`.  Next, if it is not `null`, run the `Invoke()` method by passing in `this` which is a reference to the publisher object.  Finally we send an empty `EventArgs` class instance.

    RaiseEvent?.Invoke(this, EventArgs.Empty);

<<[Simple Event Handling - Complete Example](cs/ch10-03.cs)

We've seen the pieces of the `Subscriber` and `Publisher` classes.  The real work in this example starts in the `Events.RunMe()` method.

First, we create an instance of each of the `Publisher` and `Subscriber` classes.  Next, using the `+=` operator, we hook up the event handler.  This line tells the runtime to call the subscriber's `HandleEvent` method when the event handler called, `RaiseEvent` is invoked.  At this point, since we have at least one subscriber to `RaiseEvent` it is not null.

Next, we call the `FireOffEvent()` method on the `Publisher` class.  This invokes the event handler \(raises an event\) to all subscribers that will be handled by the method that was referred to when we hooked up the event handler.  We invoke it with the arguments that match the method that will be handling the event.  Finally, this code unhooks the event handler with the `-=` operator and makes the `EventHandler` instance, `RaiseEvent` on the publisher null.  If we were to call `FireOffEvent()` again, nothing would happen.

Once the event handler is invoked, code execution continues __immediately__.  It does not wait for a return value.  For now, we'll call this _fire and forget_.  The as soon as the event is raised, the runtime invokes all of the methods that are listening for the event.  They may actually all be invoked at the exact same time.  That means, if there are a thousand subscribers, you don't have to wait for all of those methods to _start_ to be executed.  This often has unintended consequences that we will cover in depth.

This is just a very basic example of raising and handling events.  The whole process is quite complex and the subject of an entire book, but we'll introducing more detail in future chapters.

## Finalizers \(Instance\)

%% https://ericlippert.com/2015/05/18/when-everything-you-know-is-wrong-part-one/

A> Finally, we come to the last new type of member that can be on a class aside from objects that contain other objects.  Finalizers should generally be avoided, but it is good to understand what they are and how to use them. 

The purpose of a finalizer is to clean up any used resources that have not been cleaned up.  This means, closing open files, etc.  The tilde ~ signifies that this method is a finalizer.

    public class FinalizeThis
    {
        ~FinalizeThis()
        {
        }
    }

A few facts about finalizers:

* Finalizer methods take no arguments.
* Never throw an exception from a finalizer.
* Finalizers _may_ not always be called.
* Finalizers _may_ be called more than once.
* You cannot directly execute a finalizer method.
* The garbage collector decides when to call a finalizer method.
* You cannot predict when a finalizer will be called.
* They can be very difficult to debug.
* Don't create empty finalizer methods.

In short, don't rely on finalizers.  To properly clean up used resources, you should be implementing IDisposable which is covered in a later chapter.  If created properly, a finalizer won't hurt, but might not help.

## Nested Types \(Static and Instance\)

A class can contain other classes, not just as instance members, but as class definitions themselves.  There are times when you might want to only use a class from within another class.  You may also nest other types inside of classes such as enumerations and structs.  Here is an example.

    public class ClassA
    {
        public class ClassB
        {
        }
    }

By default, the inner class will be private, only accessible from within the containing class.  You can only use a limited amount of access modifiers on the inner class.  Let's look at class instances for a little bit.  Just because a class is inside of another class does _not_ mean that you can access the members of the parent class.  The following will not work.

    public class ClassA
    {
        private string _className = "Class A";

        public class ClassB
        {
            public static void PrintClassName()
            {
                // leanpub-start-delete
                Console.WriteLine(_className);
                //leanpub-end-delete
            }
        }
    }

You _can_ call `private` instance members on `ClassA` from `ClassB`.  The reason the previous example does not work is because .NET treats both class definitions as _separately_ instantiable.  When you create an instance of `ClassA`, it does not automatically create an instance of `ClassB` and vice-versa.  To create an instance of `ClassB` so that it has access to `ClassA`'s instance members, you can do the following.  You are providing `ClassB` with access to an instance of `ClassA`.

    public class ClassE
    {
        private string _className = "Class E";
        public ClassF MyClassF { get; set; }

        public ClassE()
        {
            MyClassF = new ClassF(this);
        }

        public class ClassF
        {
            private ClassE _parent;

            public ClassF(ClassE instance)
            {
                _parent = instance;
            }

            public void PrintClassName()
            {
                Console.WriteLine(_parent._className);
            }
        }
    }

To call the `PrintClassName` method from elsewhere:

    ClassE a = new ClassE();
    a.MyClassF.PrintClassName();

To create an instance of `ClassF` with a reference to the instance data on `ClassE`, you can pass an instance to `ClassE` to a constructor on `ClassF` and save the parameter so that it may be referred to in our instance of `ClassF`.  In the case of this example, we are passing the special keyword, `this`, to the `ClassF` constructor from the `ClassE` constructor.

A> If you think this is a little confusing, it is because it is.  It is absolutely an awkward way of using nested classes.  My recommendation for using nested types is to only use them as `private` to hold data that you only want to use within your enclosing class.  Namespaces are for grouping sets of similar objects, classes should not be.

### Conclusion

In our extended view of all of the members available within a class, we have seen the power of the C# language.  We have also seen how classes may be used in various circumstances.  To expand upon the usefulness of the C# type system, we will next endeavor to see how to compose objects by reusing other objects and crafting them to our needs. 
