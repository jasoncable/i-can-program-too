# Objects and Classes

> _"I invented the term 'Object-Oriented', and I can tell you I did not have C++ in mind."_
>
> -Alan Kay

A> ## Author's Note
A>
A> This chapter describes things in a way that is suitable for learning C#.  For example, I know that the storage of `struct` vs. `object` is a matter of implementation, but is that important for even journeymen to know?  Also, is there a purpose for spending 30 or more pages on trivial things that most programmers will never run into?  This book is about programming, which in my mind is the valley between coding and engineering.  It's a place that most of us live.  Let's leave compiler optimizations and DLR design to the engineers.

Object-oriented programming languages come in all shapes and sizes.  Several languages evolved over time to include objects, including BASIC to Visual BASIC and Perl 4 to Perl 5.  If I had to describe what an object is to my mother or father, I would have to say, "An object is something we use in computer programming to represent a 'thing' or concept.  Objects can contain data and code that performs operations."

Objects are much more than that, but let's start out with that definition.  In C#, as you will remember, everything is an object.  Everything in C# inherits from a special class called `Object`.  We have two types of objects: reference types and value types.  Value types inherit `Object` through `ValueType`.  Nullable value types in turn inherit `ValueType` through `Nullable<T>`.  We'll talk about inheritance in a bit.  These three classes are set implicitly, meaning that the compiler handlers their inheritance.

In C#, we can create two types of objects: classes and structs.  Structs are often created to represent a discrete piece of data, such as the framework type `DateTime`.  Structs are value types and as such are stored on the stack and may be used like nullable value types.  Classes are stored on the heap and are reference types.

## The Four Principles of OOP

Let's switch over to a little computer science for a bit.  It will help us understand the reason for creating and using objects.  The concepts in this section will be discussed further as we learn how to create objects.

### Encapsulation

An object represents one "thing", one "idea", or one "concern".  We create objects to provide a place to model both real-world and abstract concepts.  Encapsulation also gives us the ability to hide and show data and operations related to the object.  In essence, encapsulation is the process of creating a piece of code that defines the behavior and attributes of a concept.

### Inheritance

Classes may be related to each other and share properties and ways of doing things through inheritance.  You can create an object called `Vehicle`.  It can contain data and operations that may be used by other objects that are related to it.  For instance, you can create classes called `Car`, `Truck`, and `Tractor` that inherit from `Vehicle`, which defines the basic definition of what a vehicle is and common things it can do.  This allows us to keep from repeating code to perform basic common operations on related objects.  For example, `Vehicle` might define the operation `Drive` or the string field `Manufacturer`.

### Polymorphism

"Define polymorphism."  This is an commonly asked question in job interviews.  This author usually responds, "Polymorphism is the way of treating an object like another object."  The word polymorphism comes to us from the Greek word "polymorphos", "of many forms."  Its concepts include the use of interfaces to enable us to define objects that are able to perform the same operation, generally in different ways.  It can also refer to using the same symbol, jargon for "name", to perform different operations based on context and/or input.

### Abstraction

Abstraction is the idea of only presenting the relevant information required to perform an operation.  In the statement, "birds fly", we only need to know that a `Bird` is capable to `Fly`.  For most purposes, we don't care about wingspan, weight, feather density, or tail length.  We abstract these properties away, keeping them hidden from normal view.  They are needed to provide the computations in modeling flight, but only to the person concerned with the physical process of flight.  Other properties may be made available to the public such as whether it is an African or European swallow.

## What's in a `namespace`?

A namespace in C# provides a code-based way of organizing groups of related objects, enumerations, etc.  Namespaces also enable use to reuse class names across different projects.  For example, no one person can keep you from created a class called `Program`.  

You specify the namespace in each code file with the keyword `namespace`.  C# namespaces are almost always pascal case and nested through the use of dots.  Historically, Microsoft has reserved namespaces beginning with `Microsoft` and `System`.  You can use these, but it is not recommended.

In .NET, our code is compiled into a file called an assembly or an executable.  Namespaces may span several assemblies and multiple namespaces may be in one assembly.  If you are redistributing your software, it is often wise to make sure that your assembly names and namespaces line up for easier use.  For example, `JasonCable.DataAccess.dll` might contain namespaces `JasonCable.DataAccess`, `JasonCable.DataAccess.SqlSerer`, etc.

A C# code file should begin with a list of `using` _directives_ followed by the `namespace` declaration.  `using` directives are most commonly used so that we don't have to type the full name of a class, etc. each time we use it.

    using System;
    using System.Text.RegularExpressions;

    namespace JasonCable.Book
    {
        ...
    }

`using` directives at this context have two other purposes.  For more information, search the web for "C# using alias directive" and "C# static using directive".  `using` _statements_ are a different concept that we will cover later.

## Classes and Their Members

A class is a basic unit of code that defines a reference types.  Classes are all contained within a namespace.

    namespace JasonCable.Book
    {
        public class Chapter
        {
            ...
        }
    }

The full name of this class is `JasonCable.Book.Chapter`.  As we have seen, in our code that lives in other files, we use the `using` declaration so we only have to type `Chapter` every time we use the class instead of `JasonCable.Book.Chapter`.

Right now, our class doesn't do anything.  To solve this problem, we need to declare some _members_.  A member is simply something that helps define what the class is and what it does.

## Static vs. Instance Members

There are two types of members.  You can look at these as being two types of scopes.  _Instance_ members can only be accessed when we create an instance of a class.  _Static_ members may be used without creating an instance of a class.  Instance members are able to access static members, but not the other way around.

When we create a variable pointing to a string, the compiler does something in the background that actually creates an instance of the `System.String` class.  To explicitly create an instance of a string, we can do this.

    string s = new String("my string");

`String` has both instance and static members.  We create a new instance of the string to actually contain the data.  This provides the members of the instance access to the data.  The static members of the `String` class provide utility functions to help us create and manipulate strings.

To create a new instance of an object, we use the `new` keyword followed by the `class` name followed by parentheses.

    Int32 myInt = new Int32(123);

Instances of classes contain data and operate on the data that they contain.  Static members of classes are used to perform operations on user-provided data that is __not__ stored in the class.  Static members may also work on data contained within the class that is not meant to be manipulated.  Instances of classes generally contain what we call _state_ data.  State is the representation of an object as a specific point in time.  Instance members are good for storing and manipulating state data whereas static members are good at storing and manipulating data that does not change or that is externally provided and not meant to change.

A> You are probably confused at this point.  This is complicated stuff, steeped in abstract concepts.  It will make more sense once we see some examples.  Some of the information provided here is a simplification of truth in order to not confuse you more with trivialities that only confuse the situation more.
A>
A> For the upcoming discussion, you will only see two types of _access modifiers_, private and public.  The others will be discussed later.  `public` means that a member of accessible within the class and from outside of the class.  `private` members are only available internally to the class.
A>
A> In general, think of static vs. instance as this: static members live on the type and are used from the type itself.  Instance members live with the instance of type type and are only available from instance.

## Fields \(Static and Instance\)

A field is a variable that is stored at the class level.  The following shows two variables.  The static variable is denoted by the `static` keyword.  It is marked `public`, meaning that it can be accessed from outside of the class.  The `_subTitle` field is a `private` instance-level variable that is only accessible from within the instance scope and only within the class.

    public class Chapter
    {
        public static string Name = "I Can Program Too";
        private string _subTitle = "A Beginner's Guide to C#";
    }

Both of these variables have been initialized with a value, but they do not have to be.  The following are both valid.  You can set the value at a latter time.

    public class Chapter
    {
        public static string Name;
        private string _subTitle;
    }

There are three types of special fields, `readonly`, `static readonly` and `const` fields.  Once set, none of these types of fields can be changed.  _Constants_ are defined using the `const` keyword.  Their value is determined at the time the code is compiled.  Their value can not be changed.  The following is an example of a constant.

    public class Chapter
    {
        public const int MaxNumberOfPages = 21;
    }

Constants may only be built-in C# such as `int`, `decimal`, `string`, etc.  For non build-in types, use `static readonly`.

`readonly` instance fields must be set by the time the class instance is ready to be used.  We do this through a special piece of code called a constructor \(below\).  They may also be pre-assigned as below.

    public readonly int PageCount = 19;

`static readonly` instance fields must be set at runtime by the time a static constructor is finished.  They may also be pre-assigned.

## Methods \(Static and Instance\)

A> This section introduces the basic features of methods.  Features such as generics and lambdas will be covered in subsequent chapters.  This section only focuses on deterministic methods.  
A>
A> One final note, the terms "method", "function", "subroutine", and "procedure" are often used interchangeably.  We will leave the non-stop arguments over the distinctions between these up to computer scientists.  This book uses the term "method", exclusively.

If classes are _nouns_, then methods are _verbs_.  In language, a noun is a word that describes "an entity, quality, state, action, or concept."  A verb is a word that "expresses an act, occurrence, or mode of being."  In simpler words, objects are things and methods are actions performed on those things.  In its most basic form, a method executes code that performs some sort of action. 

While methods are not the only way to execute code, they are perhaps the most frequently used.  Let's look at some framework methods.  In this case, we are looking at static methods on objects, not just classes.  They generally work the same way.

    String.IsNullOrEmpty( s );
    Console.WriteLine( "my line" );
    Int32.TryParse( s, out i );
    DateTime.IsLeapYear( 2019 );
    Convert.ToString( 2019 );
    DateTime.Now.ToString();
    Convert.ToInt32( "2019" );

There are tens of thousands of additional methods in each of the framework editions.  Let us now look at the anatomy of a basic method.  In this case, an static method.

    public static bool IsOdd( int integer )
    {
        return integer % 2 == 0;
    }

* `public` - The access type declaration.  This allows the method to be called from anywhere.
* `static` - Specifies that the method is called from the type, not the instance of the object.
* `bool` - Specifies that this method returns a value of the type `bool`. 
* `int integer` - The area between the parentheses declares the _parameters_ of the method.  Parameters are data passed to the method.  Each parameter must specify a data type and a name.  In this example, the data type is `int` and the parameter name is `integer`.  Multiple parameters may be specified, separated by commas.
* `return` - The return statement immediately ends code execution and returns the value associated with it, if any.

### The `return` Statement

If a method returns data, the `return` statement must be used to return the data.  If the method does not return data, the `return` statement immediately ends code execution and exits the method.  The `return` statement may also be used within `if`, `for`, `foreach`, `case`, `while`, and `do` blocks.  In each and every case, if the `return` statement is encountered in a line of code that is being executed, it immediately exits the method, optionally returning data.

### Back to Our Example

    using System;
    namespace JasonCable.Book 
    {
        public class NumberUtilities
        {
            public static bool IsOdd( int integer )
            {
                return integer % 2 == 0;
            }
        }
    }

To call our method, we can call it with the fully-qualified version.  Executing a method is usually done by providing the method name followed by parentheses.  The input arguments are placed inside of the parentheses.  For arguments, you only specify the data type when declaring the method, not when executing it.

    int i = 3;
    bool isOdd = JasonCable.Book.NumberUtilities.IsOdd(i);

If we added `using JasonCable.Book` to the top of our code file:

    int i = 3;
    bool isOdd = NumberUtilities.IsOdd(i);

In this case, we assign the results of the method to a variable called `isOdd`.  If a method returns a value, you do not have to use it.  In the following, the result of the method is discarded.

    NumberUtilities.IsOdd(i);

Methods do not have to return values.  These types of methods are called void methods.  Void methods often perform operations on the data contained within the instance of an object.  The following example omits the namespace declaration, but remember that it is always required.  This method also does not have any parameters.

    public class Name
    {
        private string _lastName = "Cable";
        private string _firstName = "Jason";
        private string _fullName;

        public void CreateFullName()
        {
            _fullName = _lastName + ", " + _firstName;
        }
    }

`return` is not required in a void method, as it does not return data.  `return` may be used in a void method to immediately stop execution of the method and return the code execution to the next line of the code that executed the method.  

To use the method above, you must first create an instance to the object with the `new` keyword.

    Name myNameInstance = new Name();
    myNameInstance.CreateFullName();

In this case, `myNameInstance` is the variable of type `Name` \(our newly created object\).  `new` does a couple of things as we will see in the Constructor section below.  For now, it is enough to know that it creates a new instance of the object, allowing us access to perform operations on instance-level members.  

### Not All Paths...

We have seen various examples of flow-control statements and logic in C#.  In order for a non-void method to return data, it is required that every _path_ through the code returns a result.  A path is the flow code execution through a method.  Each path ends in a `return` statement.

    public bool IsTrue( bool myValue )
    {
        if( myValue )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

There are two possible paths through this simple code.  If `myValue` is `true` and if `myValue` is `false`.  This covers each conceivable way that __all__ of the code in the method is executed.  The following code won't compile because there are circumstances where the `return` statement does not get called.

    public string GetAValue( string[] sa )
    {
        foreach( string s in sa )
        {
            if( s == "A" )
            {
                return s;
            }
        }
    }

If this code _could_ compile, the following things can happen if this code is run:

* If `sa` is null, we will get an error.
* If `sa` is empty or does not contain an element containing the string `"A"`, `return` is never called.
* If `sa` in fact does have an element with the string `"A"`, the method returns `"A"`.

To make this better, we can do the following.  In this case, we are going to return `null` if we can't find the value `"A"`.

    public string GetAValue( string[] sa )
    {
        if( sa == null )
            return null;

        foreach( string s in sa )
        {
            if( s == "A" )
            {
                return s;
            }
        }
        return null;
    }

We have fixed our potential null problem by checking `sa` for `null`.  We have also placed a `return` statement at the end which says, "If we have not already returned a value, return `null`."

We have now satisfied the compiler condition that all possible paths through the code must return a value, if a value is to be returned.

## Pass by Value vs. Pass by Reference

When we provide a method with a parameter, we say that we are passing it to the method.  This is where variable scoping gets a little sticky.  Passing a variable _by reference_ allows us to make changes to the variable that are available to the calling scope.  That is, new assignments to the variable being passed into the method are kept once the method is done executing its code.  Otherwise, for variables passed _by value_ are not changed outside of the method.  These definitions only tell part of the story.

### Value Types

When you call a method with a parameter that is a reference, a copy of the reference type is made.  Any operations on that reference type are only seen within the method.

    public static void RunTest()
    {
        int i = 0;
        IncrementByPlusEquals(i);
        // i is 0
    }

    public static void IncrementByPlusEquals(int i)
    {
        i += 1;
        // i is 1
    }

Don't get confused by the reuse of the variable name, `i`.  The method creates a new scope that has nothing to do with the scope of the `RunTests` method.  If these were instance level methods and we had an instance level field named `i`, the method masks the variable name `i` and scopes the new version of it to the method itself.  The method then has access to all class level fields, except `i`.  This can get very confusing.  It is the reason I prefix private field names with an underscore.  Some people pascal case all fields.  In any case, the most common casing for method parameters is camel case.

To pass a value type type reference, we use the `ref` keyword in both the method definition and in the place where we call the method.

    public static void RunTest()
    {
        int i = 0;
        IncrementByPlusEquals(ref i);
        // i is 1
    }

    public static void IncrementByPlusEquals(ref int i)
    {
        i += 1;
        // i is 1
    }

### Reference Types

Reference types follow the same rules, but are a little more confusing as we will see.  For all of the following examples, we will be using the following simple class.  Each time we reassign a new instance of the class to a variable using the `new` keyword, our `FullName` field should reset to `Jason L. Cable`.

    public class Name
    {
        public string FullName = "Jason L. Cable";
    }

First, let's try passing in an instance of the class into a method.  The method could be an instance or static method.  It doesn't matter.  First by value.

<<[Setting Fields on Objects](cs/ch07-01.cs)

You should be scratching your head by now.  Why did both pass by value and pass by reference update the field?  Shouldn't one update it and one not.  In a word: no.

Pass by reference and value in objects types both refer to the way the code handles the _variable_.  In the samples above, we did not reassign the reference to the object _within_ the method.  Passing by reference actually passes a new reference to the _instance_ of the object, but the object itself is not re-created.  The reference from the calling code and the new reference created by the `ref` keyword both point to the same area in memory where the instance of the object was created.

## The Difference Between Reference and Value Types

Let's see what happens when we try the same thing without passing it to a method.  I will be using a class library called [FluentAssertions](https://fluentassertions.com/) to demonstrate what is happening.  It adds the methods `Should` and `Be` to test the current value of our fields.  FluentAssertions can be found on [NuGet](https://www.nuget.org/).  It throws an error when a check fails.  See the appendix called, ["Reusable .NET Components"](#ReusableComponents) for more information on NuGet.

{line-numbers=on}
<<[Object References](cs/ch07-02.cs)
{line-numbers=off}

Let's take this line-by-line.

1. Create a new variable `a` and assign it to a new instance of `Name`.
2. Create a new variable `b` and set it to point to the instance of the object that `a` points to.
3. Create a new variable `c` and set it to point to the instance of the object that `b` points to.
4. `a` points to the same instance of an object that `b` points to.
5. `b` points to the same instance of an object that `c` points to.  At this point, `a == b == c`, as they all point to the same memory location that contains the instance of our object.
6. Check to see that the `FullName` field was properly set.  It is the same on all three references, as they all are pointing to the same object instance.
7. Set the `FullName` field to a new value _on the instance of the object, a location in memory_.
8. Check to see that `b.FullName` still points to the one and only instance of the type `Name` that we created on line #1.
9. ...also check `a`.
10. ...also check `c`.
11. Set `b` to be a _new_ instance of the object `Name`.  This variable now points to a new location in memory.
12. Check to see that `b` is indeed a new instance of the object.
13. Ensure that `a` still points to the original instance.
14. Ensure that `b` still points to the original instance.
15. \(Switching over to value types.  Do they work the same way?\)
16. Create a new variable `x` and set it to `1`.  Remember that `x` is a value type and its value is stored _with_ the variable.
17. Create a new variable `y` and set it to the _value_ of `x`.  This does _not_ mean that `x` and `y` represent the same location in memory.  In fact, they are both their own distinct values.  They both just _happen_ to contain the same value.
18. Create a new variable `z` and set it to the value of `y`.
19. `x` is equal to `1`
20. `y` is equal to `1`
21. `z` is equal to `1`
22. Set `x` to `10`
23. Set `y` to `20`
24. Set `z` to `30`
25. Prove that `x`, `y`, and `z` point to different locations in memory.  On this line, `x` is `10`.
26. `y` is `20`
27. `z` is `30`

We have now seen one of the most important differences between reference and value types.  Let's continue with value types and methods.

## Passing Reference Types By Reference

As we have seen, the difference between reference and value types is how they are stored in different ways in memory.  Let's use the same method as above to check to see what C# does when we pass a reference type to a method first by value then by reference.

<<[Pass Reference Type by Value](cs/ch07-03.cs)

As we saw above with changing a _field_ when passed by value, that value is retained _outside_ of the method.  Since we did not pass the variable by reference, when we assign a new instance to the object, the new value is not maintained outside of the method.

<<[Pass Reference Type by Reference](cs/ch07-04.cs)

As we can see in this example, the new instance of the `Name` object is assigned to the variable and is available _outside_ of the method.  This is due to passing it by reference.

## Out Parameters

The `out` parameter keyword allow an additional way to return a value from a method that does not require the `return` statement.  Out parameters are variables that uninitialized prior to calling the method.  There are two different ways to do this.  For our first two examples, we will be using a framework method that converts a `string` into an `int`.  The order in which you pass the parameters must match the order in which they are specified in the method declaration.  This is called a method's _signature_.

    int convertedInt;
    bool itWorked = Int32.TryParse("123", out convertedInt);

    convertedInt.Should().Be(123);
    itWorked.Should().BeTrue();

Here we are again using the `Should` and `Be` methods from FluentAssertions to test our work.  In this case, we see that `Int32.TryParse()` returns a `bool` using the `return` statement.  Here it indicates that the string we passed in is an integer and it is between the two static fields that exist on the Int32 object, `Int32.MinValue` and `Int32.MaxValue`.  The tests worked, showing that we may use the out variable later on in our code.

This might be considered the "old" way of doing things.  C# now provides a short-cut way of initializing out variables.  Remember that our integer, `convertedInt` would be `0` if the string failed to convert.  One other note, methods such as `Int32.TryParse()` are often combined with an `if` statement such as in the following.  This also provides the newer way of declaring an `out` variable.

    if( Int32.TryParse("456", out int convertedInt1) )
    {
        convertedInt1.Should().Be(456);
    }
    convertedInt1.Should().Be(456);

We can see that `convertedInt1` is available both _within_ the `if` block and outside of it.  The C# designers seem to be playing a trick on us!  Remember the `for` loop?  Remember that the `int` that we declare within the parentheses is only available _within_ the code block that follows it?

    string[] sa = { "a", "b", "c", "d" };
    for( int i = 0; i < sa.Length; i++ )
        Console.WriteLine( sa[i] );
    // leanpub-start-insert
    // i is NOT available here!
    // leanpub-end-insert

Even though `convertedInt1` is declared _within_ the parentheses in the method invocation, it _is_ available after the method is run.  Here is an example of how create a method with `out` variable.  You may have several `out` variables in one method.  You will also notice that you can use the `var` keyword to declare your `out` variable.

    TimesFive(5, out var theAnswer);

    theAnswer.Should().BeOfType(typeof(int));
    theAnswer.Should().Be(25);

    public static void TimesFive(int howMany, out int theAnswer)
    {
        theAnswer = 5 * howMany;
    }

An `out` variable _must_ be set in the method before it ends.  You must set it before a return statement and like the return statement, the variable must be set in all _paths_ through the code.

There is an additional test here that is checking to see if our variable, `theAnswer` is set to the data type `int`.  It uses C#'s built-in operator `typeof` which we will learn about later.

When creating a method, the order in which you specify the parameters doesn't matter, unless using a `params` array which must be the last parameter.  The best practice for ordering your parameters:

* Place the most important parameters, especially those that won't generally be null, first, from left to right.
* Next, specify `out` and `ref` parameters.
* Finally, a `params` array must come last.

Note: C# also provides an `in` parameter modifier that passes an object by reference.  It is not used in any of the scenarios that we have so far covered.

## The `params` Array

C# provides a way to pass in a variable number of arguments \(of the same type\) to an array.  A _params_ array is a special type of method parameter.  It uses the `params` keyword and takes `0` or more arguments.  Because it is of a variable length, it must come as the last in the parameter on a method.

    public void DoThings( params string[] myArray )
    {
        foreach( string s in myArray )
            Console.WriteLine(s);
    }

This is our method definition which includes the keyword `params` followed by a `string[]` array variable declaration.  In this example, `myArray` is only available within the following code block.  Here we are writing the strings we passed in via the params array to the console.  You will generally send in 0 or more comma-separated values that will be _mapped_ to a new `Array` of the type you have chosen.  The following are all valid.

    DoThings();
    DoThings( "abc" );
    DoThings( "abc", "def", "ghi" );

The first invocation does not send in any values.  In the method, the `myArray` variable is _not_ null, but is an `Array` instance with a length of 0.  We do not need to check it for null before using a `foreach` on it.  `foreach` effectively does nothing with a `0` length array, but will throw an error if that array is `null`.

The second line shows us passing in one string; the third passes in three strings.  Let's see an example with more than one parameter.  For brevity, we are not showing code in the method, but due to the `out` parameter, there must be at least some code.

    DoStuff( 5, out var i );
    DoStuff( 10, out var j, 42);
    DoStuff( 25, out var k, 42, 24, 7, 11);

    public void DoStuff( int times, out int output, params int[] integers )
    {
        // ... ///
    }

## Optional Parameters

## Named Parameters

## Extension Methods

## Method Overloading


expression body definitions


## Properties \(Static and Instance\)

## Events \(Instance\)

## Operators \(Instance\)

## Indexers \(Instance\)

## Constructors \(Static and Instance\)

## Finalizers \(Instance\)

## Nested Types \(Static and Instance\)

%% ---------------------------

### static classes

### extension methods

> _"An interface defines a contract."_
>
> -Standard ECMA-334: C# Language Specification, 1st Edition

### abstract, interfaces

### multiple-inheritance

### Operator Overloading

### overriding members

%% ---------------------------

## Access Modifiers and Accessibility Types

### Here be dragons!

In general practice, you will use `public` and `private` about 99% of the time.  I am only including the full list here because they comes up in job interviews.  The idea behind access modifiers make sense, but in practice, they are nothing but annoying.  The reason to have access modifiers:

* Enforce consistent use of APIs
* Prevent use of undocumented APIs
* Prevent certain code from being executed outside of its original context

If someone wants, then can easily execute your code using one of several methods.  First, if your code is open source and is available on, say, GitHub, they can download your code, change it, and recompile.  Second, if your code is only available in binary form, it can be decompiled with tools such as Red Gate's .NET Reflector or Jet Brains' dotPeek.  Third, .NET's Reflection API provides methods for accessing data and executing code within your classes.  It can also create instances of your objects.  Fourth and finally, there is a little known API that can create an instance of an object that does not run private or default public constructors.  It is in the following object `System.Runtime.Serialization.FormatterServices`.  Specifically, the `GetUnitializedObject` method.

| access modifier | accessibility |
|-----------------|---------------|
| public | no restrictions |
| private | current class only |
| protected | current class and all derived classes |
| internal | current assembly |
| protected internal | current assembly and derived classes |
| private protected | current class and derived classes in the currently assembly |

`internal` is the default for classes, structs, and interfaces at the namespace level.  Class and struct members and nested classes and structs default to `private`.  Enumeration members are by default,  `public`, as are interface members.

### sealed

