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

You may have noticed that we did not put a constructor on our class.  Constructors are not inherited but you may refer to a constructor on the base class using the `base` keyword.

    public MyObject() : base() { }

This tells our object to call the base class's constructor.  We can pass arguments along with this call.  

One last note before we see a real example of basic inheritance: a class cannot inherit from more than one class at a time.  This is called _multiple inheritance_ and is not allowed.  What you _can_ do is have a class inherit from a class that inherits from another class, etc.  We will see that in a little bit as well.

## A Real Example

Let's see how we can model some real life objects.  Here we are modeling a few musical instruments.  The base class is `Instrument`.  `StringInstrument` inherits from `Instrument` and `Violin` and `Piano` are both `StringInstrument`s.

<<[Inherited Instruments](cs/ch11-01.cs)

On `Instrument` we implement a property called `Name`.  It has a `protected set` which only allows us to set the value on a _derived_ object.  We set it on each object here.  It is set with the explicit `base.`, which is not required, but provides a bit of clarity as to the origin of the property.












> _"An interface defines a contract."_
>
> -Standard ECMA-334: C# Language Specification, 1st Edition

### abstract, interfaces

### multiple-inheritance

### overriding members

### sealed

