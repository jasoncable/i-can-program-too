# Object Inheritance and Interfaces

We have already seen that everything in C# is an object.  Let's take a look at exactly how that works, starting with reference types, specifically, classes.

`System.Object` or simply `object` is the object on which every other object in C# is derived.  That does not mean that all object definitions simply start with inheriting `object`.  It means that somewhere in the inheritance chain, an object ultimately inherits `object`.  Let's check out _some_ of the instance members on `System.Object`.  

    public Object() // default constructor
    public virtual string ToString()
    public virtual bool Equals(object obj)
    public virtual int GetHashCode()
    public Type GetType()
    protected virtual void Finalize()

Let's start with the `virtual` keyword.  This allows us to mark a member as being able to be overridden in a derived class.  If we create a class that is directly based off of `System.Object`, we are allowed to override the default behavior of the that member.  To inherit from `System.Object`, we use a colon after the class declaration as follows.

    using System;
    namespace SampleConsoleApp.Chapter11
    {
        public class MyObject : Object
        {
            public override string ToString()
            {
                return "This is my class.";
            }
        }
    }

We don't need to specify `: Object`, as it is implicitly inherited.  It is only shown here to show simple inheritance.

In this example we are overriding the `ToString()` method.  The default implementation on `System.Object` returns a string that represents the fully-qualified name of the class, in this case, `SampleConsoleApp.Chapter11.MyObject`.  There are many times that we want to override `ToString()`, usually to provide a human-readable version or summary of the data contained in our class.

If we create an instance of the `MyObject` class and class `.ToString()` on it, a `string` with the value of `"This is my class."` will be returned.  Can we still call `.GetHashCode()` on our new object?  Yes.  It is not overridden, but it doesn't _have_ to be.  A `public virtual` method still still exists on our new class because it inherits from `System.Object`.  

A> We saw _string interpolation_ in a previous chapter.  Let's see how important `.ToString()` is in .NET.  In the following example three things happen.  
A>
A> 1. The expression is evaluated.
A> 2. If the expression is null, replace the bracketed expression with `String.Empty`.
A> 3. If the expression is a string or its evaluation returns a string, replace the bracketed expression with that string.  Otherwise, call `.ToString()` on the resulting object.

You may have noticed that we did not put a constructor on our class.  Constructors are not inherited but you may refer to a constructor on the base class using the `base` keyword.

    public MyObject() : base() { }

This tells our object to call the base class's constructor.  We can pass arguments along with this call.  

One last note before we see a real example of basic inheritance: a class cannot inherit from more than one class at a time.  This is called _multiple inheritance_ and is not allowed.  What you _can_ do is have a class inherit from a class that inherits from another class, etc.  We will see that in a little bit as well.

## A Better Example

Let's see how we can model some real life objects.  Here we are modeling a few musical instruments.  The base class is `Instrument`.  `StringInstrument` inherits from `Instrument` and `Violin` and `Piano` are both `StringInstrument`s.

<<[Inherited Instruments](cs/ch11-01.cs)

On `Instrument` we implement a property called `Name`.  It has a `protected set` which only allows us to set the value on a _derived_ object.  We set it on each object here.  It is set with the explicit `base.`, which is not required, but provides a bit of clarity as to the origin of the property.  You will see that none of the other derived classes implement `ToString()`, yet if it is called on a instance of `Piano`, the method will return "Piano".  It _looks_ like the overridden `ToString()` on `Instrument` points to _its_ instance of `Name`.  What we are really saying telling the runtime to do is to return the `Name` property of the currently instantiated class.

Let's take a look at the `Violin` class.  Its constructor calls the constructor on the `base` object.  You might think that it would be setting the `Name` property to "Strings Section", but remember, when using the `:` on a method to refer to `this` or `base`, the method referred to by `this` or `base` is called _first_, __then__ the code within the brackets of the constructor is called.

## A Little Polymorphism

Continuing this example... in real life an orchestra is a collection of instruments and the strings section is a collection of string instruments.  Can we create a collection \(an array\) of all of our instruments?  Yes.  That is where polymorphism comes into play.

A> For absolute clarity and transparency...  a piano is in fact both a string instrument _and_ a percussion instrument.  It can also be plucked, but not usually.

    Instrument[] ia = new Instrument[3];
    ia[0] = new Violin();
    ia[1] = new Piano();

As the following test shows, we still have a `Violin` which is still derived from `StringInstrument`.  \(Those angle brackets, the `<` and `>`, denote a `Type` in C#.  They will be covered when we talk about _generics_.\)

    ia[0].Should().BeOfType<Violin>();
    ia[0].Should().BeAssignableTo<StringInstrument>();

What you have just seen is called _upcasting_.  When we move _up_ the inheritance chain toward `System.Object`, we are allowed to assign a more specific type to a less specific type.  C# always lets us _implicitly_ assign an instance of an object to a type that it is derived from.  We can implicitly upcast all the way up to `object`.

    object o = new Piano();

In our `Instrument[]` array, you can see how we can do things like group like objects together and perform operations on them.  We can do the same thing with a method.

    public static void PartyTime(Instrument instrument)
    {
        instrument.Play();
    }

We can pass any object that is derived from `Instrument` and invoke its `Play()` method because `Play()` is defined on the `Instrument` object.  Upcasting is remarkably powerful and shows how polymorphism is used in practice.  The next question is this: how do we retrieve our `Piano` object from the `Instrument[]` array and still call it a `Piano` again?

    Piano myPiano = (Piano)ia[1];

As you can see from this example, _downcasting_ requires us to explicitly state that we want to turn an `Instrument` back into a `Piano`.  If the downcast fails, a `System.InvalidCastException` will be thrown.

What if we want to find out if a downcast will work or fail.  We have several ways of doing this.  First, we have the `as` keyword.

    Violin myViolin = ia[1] as Violin;

In this case, the second element of our array is an instance of the `Piano` object.  By using the `as` keyword, no exception is thrown and the variable `myViolin` is set to `null`.  As long as you are not checking to see _if_ your `Instrument` is `null`, this may be a good choice for you.  Sometimes it may be better to let the exception be thrown, especially if the rest of your code will fail if it heavily relies on the result of the downcast.

.NET gives us at least three more ways to check to see if our array element, or any other instance, is of a certain type.  Each statement below returns `false` as the first element in the array is an instance of the `Violin` type.

    bool isPiano = ia[0] is Piano;
    bool isAnotherPiano = ia[0].GetType() == typeof(Piano);
    bool isAThirdPiano = typeof(Piano).IsInstanceOfType(ia[0]);

Let's see how each of these methods works with a null value.  `ia[2]` is null as we have not set it.  Each line has a comment that describes the result.

    Piano myPianoNull = (Piano)ia[2]; // null
    Violin myViolinNull = ia[2] as Violin; // null
    bool isPianoNull = ia[2] is Piano; // false
    bool isAnotherPianoNull = ia[2].GetType() == typeof(Piano); // exception
    bool isAThirdPianoNull = typeof(Piano).IsInstanceOfType(ia[2]); // false

### Extending It to Exceptions

We can now see how all of this inheritance stuff works to allow us to create our own exceptions.  You will remember that all exception classes must be derived from `System.Exception`.

    public class MyException : Exception
    {
        private string _message;

        public MyException(string message) => _message = message;

        public override string Message => _message;
    }

This creates a simple exception with one constructor that takes a string.  It does _not_ however set the message via the `Message` property.  That cannot be overridden.  We are only allowed to override the `get` of the `Message` property.  That requires us to save the string that we are passing in to a `private string` _field_.

For a full list of the overridable members go to <https://docs.microsoft.com/en-us/dotnet/api/> and select your desired framework version.  Next, search for `System.Exception`.  You will find in-depth information on .NET exceptions and how they should be used.  Visual Studio also provides auto-complete to help us find members that can be overridden.  Just start typing `override` in the proper location and it will show you the members that may be overridden.

## Sealed

In our example of an orchestra, we might not want to allow people to implement classes from our specific instrument classes.  For example, we might not want anyone to derive a class from the `Piano` class.  To do that we use the `sealed` keyword.

    public sealed class Piano : StringInstrument
    {
    }

Now no class can use `Piano` as its base class.  What if we want to just prevent one member from being overridden?  We can use the `sealed` keyword at the member level.  Let's say that we want to allow others to derive from the `Piano` class to specify types of brands of pianos?  They are all played the same way, but other properties and methods may be different. 

    public class Piano : StringInstrument
    {
        public sealed override void Play() { }
    }

The `sealed` modifier is an extremely easy way to prevent others from both deriving classes from your classes or providing alternate implementations of a method or property.  `sealed` may be used on `class` or on a method or property that overrides a `virtual` method or property from a base class.  To prevent others from implementing a method or property on a class that you created that is not from a class yours derives from, you simply don't mark it with `virtual`.

## Abstract Classes and Members

What if we want to _require_ someone to implement a class or property that we have defined?  For that, we use `abstract` classes and members.  `abstract` can be used on classes, methods, events, properties, and indexers.

Going back to our orchestral instruments example, we really only want to perform actions on things like `Piano` and `Violin`.  Alone, `Instrument` and `StringInstrument` don't really do much other than to define which members we should implement in `Piano` and `Violin`.  Marking the `Instrument` and `String Instrument` classes as `abstract` prevents those classes from being instantiated.  Upcasting and downcasting to and from these types are still allowed, but you can't directly create an instance of them.  You can only create an instance of `Piano` or `Violin`.

When marking members `abstract` you do not provide an _implementation_.  This means that the classes derived from the abstract class must implement those members.  Here is an example of what the unimplemented members look like.   Here we see a property and a method that don't provide an implementation.

    public abstract class AbstractTest
    {
        public abstract string StringProp { get; set; }
        public abstract void RunMe();
    }

To declare a member as abstract, you must declare the class as abstract.  Not every member in an abstract class must be marked as abstract.  When you inherit an abstract class you _must_ implement every abstract member, _unless_ your class is another abstract class.  For example, if we declare `Instrument` to be an abstract class and `StringInstrument` abstract, `StringInstrument` does not have to implement any of `Instrument`'s abstract members.  `Piano` though is required to implement all of the abstract members on `Instrument` and `StringInstrument` as it is _not_ an abstract class.  Let's see an example.

<<[Extending the Instrument Example](cs/ch11-02.cs)

We also added the `ConcertGrandPiano` object which, as you see, does not implement any of the `abstract` members that are higher up the inheritance chain.  That is because they have already been implemented by the classes that have been derived through to `ConvertGrandPiano`.

## Interfaces

> _"An interface defines a contract."_
>
> -Standard ECMA-334: C# Language Specification, 1st Edition



### Conclusion
