# Objects and Classes, Part 2

## Access Modifiers and Accessibility Types

In general practice, you will use `public` and `private` about 99% of the time.  The full list here because the modifiers generally come up in job interviews.  The idea behind access modifiers make sense, but in practice, they are nothing but annoying.  The reason to have access modifiers:

* Enforce consistent use of APIs
* Prevent use of undocumented APIs
* Prevent certain code from being executed outside of its original context
* Coax the user into implementing your API within _your_ limits

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

## Constructors \(Static and Instance\)

A constructor is a special type of method that is executed when creating an instance of an object.  Constructors may optionally take arguments.

### Class Instance Constructors

All non-static classes require a _default constructor_.  The compiler saves us this step and provides the default if we won't specify one.  The default constructor, if explicitly specified, looks like this:

    public class MyClass
    {
        public MyClass() { }
    }

A default constructor has no parameters and can optionally contain code that is used to initialize your class.  Constructors have the same name as the class and do not specify the return type.  They implicitly return the type of the class.  The `new` operator executes the constructor.  You pass any arguments to the constructor via the `new` operator.  To instantiate the above class, we have seen that it is done in the following way.

    var classInstance = new MyClass();

To require an argument.

    public class MyClass
    {
        public MyClass(string s) { }
    }
    // ----- //
    var myClass = new MyClass("my string");

If you, as we did in the previous example, specify a constructor with an argument, its default constructor is no longer available.  The following will _not_ work.

    // leanpub-start-delete
    var myClass = new MyClass();
    //leanpub-end-delete

Constructors and methods follow many of the same rules including overload resolution.  One main difference is that we don't call constructors _directly_, only through the use of the `new` operator or through another constructor via `this`.  The call to the constructor also initializes any uninitialized fields and auto-properties to their default values \(for our purposes\).

If you have multiple constructors on a class, you can perform _constructor chaining_, that is, one constructor can call another constructor.

    public class GraphPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GraphPoint() : this(1, 1)
        {
        }

        public GraphPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

As you can see there, we have a class that has two properties, `X` and `Y` and two constructors.  On our default constructor, you see the additional code: `: this(0 ,0)`.  In this case, the `this` keyword refers to the instance of the class.  Based on our method overload rules, it is trying to call a constructor that takes two `int`s.  The code contained in _both_ constructors is called when we create the instance of the class.

    var pt = new GraphPoint();

By calling the default constructor, the following happens.

* The compiler finds that we have a parameterless constructor.  
* Next, it sees that we are chaining constructor calls.  
* Third, it finds a constructor that takes two integers.
* Fourth, it executes the code in the constructor with the two integers.
* Fifth, it executes the code within the default constructor itself.

Remember, the chained constructor, referred to by the `this` keyword, is called first and the constructor that matches our `new` statement is called second.

In the two `int` constructor, you see that we are setting the property values in the following way.  They are prefixed with `this.`.

    this.X = x;
    this.Y = y;

`this` is simply a way to explicitly refer to a member on the current class.  I sometimes include it to improve readability.  Consider the following two examples.  Both are perfectly valid, but you should either use `this.` or a variable name prefixed with an underscore.  The following is a common pattern that works, but is unnecessarily ugly.  The instance variables and method parameters are named the same.

    public Person(string firstName, string lastName)
    {
        firstName = firstName;
        lastName = lastName;
    }

Aside from setting default values on properties and auto-properties, constructors are used to perform the logic required to instantiate an object.

### Private Instance Constructors

There are times when you don't want to allow others to create an instance of your class.  For this you can set the access on a class to something like `private` or `protected`.  We talked about these access modifiers at the beginning of this chapter.

Why would you do this?  There is an expectation that when someone creates an instance of an object that it is fairly devoid of information.  Some objects are not meant to be instantiated with a constructor.  Also, if there is a possibility that a constructor could throw an error, called an exception, you should not be able to instantiate the class directly.  Constructors should also not rely on calling code that uses external resources such as network or file resources.

    public class PrivateConstructorClass
    {
        private PrivateConstructorClass() { }

        public PrivateConstructorClass CreateInstance()
        {
            // perform initialization here
            return new PrivateConstructorClass();
        }
    }

This call cannot be instantiated with the `new` operator.  To create an instance, you must call the `CreateInstance` method.

    var pvtCtorClass = PrivateConstructorClass.CreateInstance();

Normally, we would perform checks in each property and method to see if the instance data had been initialized.  We'll see examples of that in a little bit.

## Exceptions

Before we continue on to more class member types, we need to talk about error handling in .NET.  First let's talk a little about object, specifically, class inheritance.  This is just an basic introduction of inheritance.  It will be covered in detail in the chapter on interfaces and class design structures.

### A Brief Introduction to Inheritance

Inheritance is one of the four principles of object-oriented programming.  Everything in C# is a type of object.  Everything in C# inherits a parent class called `System.Object`.  Every class that you create is implicitly derived from `System.Object`, also `object` in C#.  When a class inherits from `object` it brings along some methods that provide a way to clean up unused resources, perform equality operations between instances of an object, to get the underlying type of the object, and a method that converts a representation of the object to a `string`.

The framework declares a type called `System.Exception`.  This inherits the methods from `System.Object`.  It also _overrides_ certain methods, such as `.ToString()`.  A class that inherits members from an object have the ability to override those members.  If they are not overridden, they use the _base_ class's implementation.

* `Exception` _inherits_ from `Object`, bring along certain members from `Object`.
* `Object` is the _base class_ of `Exception`.
* The `.ToString()` method is _overridden_ by `Exception`.
* `Exception` _defines_ several _constructors_ which are used to _throw_ new exceptions.

A class can inherit a class which can inherit another class.  Let's call this the inheritance chain.  Now, each successive inheritance can override methods that come from its parent class, grandparent class, etc.  A C# object, though, cannot inherit two classes at one time.  This is called multiple-inheritance and it is not allowed in .NET.  The only way to inherit members from more than one class has to be done one at a time.

* `ArgumentException` inherits `SystemException` which inherits `Exception` which inherits `Object`.
* `ArgumentException` cannot _by itself_ inherit both `SystemException` _and_ `Exception`.  It has to go through the inheritance chain.  
* We say that `ArgumentException` is _derived_ from `Exception`.  That just means that `Exception` is somewhere in its inheritance chain.

Let's see this all in action.  First, all exceptions at some point in their inheritance chain contain `Exception`.  The framework and runtime recognize this class as the class that creates errors and sends information about the error up through the application.

### Handling Exceptions

Let's look at four keywords that have have not yet seen.

* `try` - designates a block of code for which you wish to...
* `catch` an exception.  `catch` may optionally capture the type of error that is...
* `throw`n.  `throw` signals that an error has occurred and that we need to _handle_ it or our application will blow up \(go boom\).
* `finally` we execute any code that has to be run after a piece of code has run successfully or not.

This code will throw an `ArgumentOutOfRangeException`.

    public static string BadIndex()
    {
        string[] sa = { "a", "b", "c", "d" };
        return sa[5];
    }

The best way to prevent this exception is to check the array variable for `null` if we don't know where it came from.  Second, check the length of the array before trying to pull an index on it.  The next example shows another type of exception, the `FormatException`.

    string s = Convert.ToInt32("123abc");

In code, we don't always know what type of data is being passed in to our code.  To fix up this example we use a technique called _exception handling_.  We are _handling_ exceptions to prevent them from causing our code to crash.

    int i = StringFormat("123abc");

    public static int StringFormat(string input)
    {
        try
        {
            return Convert.ToInt32(input);
        }
        catch(FormatException exc)
        {
            Console.WriteLine(exc.ToString());
            return 0;
        }
    }

We wrap the code that we are calling in a `try` block.  Next, since we know that `Convert.ToInt32()` will throw an exception of the type `FormatException`, we look for it.  If our code throws _this_ exception, the code within the `catch` block is executed.  As you can see, we have made sure that every path through the code returns a value.

### An Example and Three Questions

This brings up a few questions.  First, what exactly happens when the exception is thrown?  Second, what if we don't know the type of exception could possibly be thrown?  Third, what is this `.ToString()` stuff?  We need to see a more in-depth example to see how all of this works.

This code will be implemented in a console app.  It reads from the console line-by-line.  That means the `line` variable is set to "123" if you type: `123` followed pressing the `enter` or `return` key.  The newline is not part of the data in the variable.  To exit the loop, press enter with no value.

{line-numbers=on}
<<[Exception Catch and Print](cs/ch08-01.cs)
{line-numbers=off}

Line-by-line:

1. The method declaration.
2. -
3. Declare the variable that will hold the data that we are reading from the console.
4. Keep reading from the console until we press enter without entering a new value.
5. -
6. Begin `try` block.
7. -
8. Write out input to the console.
9. Convert input to an int.  __If__ it fails due to a poorly formatted number, execution continues at _line 12_ continues into the `catch` block.
10. Write our converted `int` to the console.  We only reach this line if the conversion was successful.
11. -
12. If an exception is thrown that is the type `System.FormatException` _or_ is a class derived from `FormatException`, code execution continues into this block.
13. -
14. Write a `string` representation of our exception to the console.
15. -
16. If an exception is thrown that did not match previous `catch` `Exception` types, in this case any exceptions not derived from `FormatException`, continue execution into the following block.
17. -
18. Write a `string` representation of our exception to the console.
19. -
20. The `finally` block is executed after that last successful line of code is executed at the _end_ of the `try` block __or__ after the code in the `try` block transitions _out_ of the code block by using `break`, `continue`, `goto`, or `return` __or__ if an exception is thrown in the `try` block... but __only if__ you have a catch block.
21. -
22. Write some random words to the console to see that we got to this line and _when_.
23. -
24. -
25. Write some more random words to the console to assert that we are totally out of our `try`-`catch`-`finally` blocks.

That is a lot of information in such a small space.  Let's address the questions asked earlier.

1. _What exactly happens when the exception is thrown?_

    If an exception is thrown in a `try` block, the remaining code in that block will not be executed.  In the case when there is one or more `catch` blocks, the runtime checks the type of exception that was thrown and checks them against each type of exception from top to bottom.  It is important to order your catch blocks by most specific to least specific.  For example, if `No1Exception` derives from `No2Exception` which derives from `Exception`, and you are trying to catch each one, `No1Exception` goes first, followed by `No2Exception` and finally `Exception`.  `Exception` must be the last or only exception type that you catch.

2. _What if we don't know the type of exception that could possibly be thrown?_
   
    At a minimum, you should have `catch` with the `Exception` exception type.

3. _What is this `.ToString()` stuff?_
   
    `Exception` overrides the default `ToString` method that is on `Object`.  At a minimum, `ToString` on any type in C# will return a `string` representation of the name of the type due to everything inheriting `Object`.  Most important types override the default `Object.ToString()`.  This includes `Exception`.  The following is the output from our program and shows the `Exception.ToString()` that is printed from our code above.

<<[Code Output](cs/ch08-02.txt)

This output shows us the exact order in which our code ran.  It also shows us two important things from the exception.  First is the _call stack_.  The call stack shows us where the exception was generated, which in our case is three method calls below our sample application.  The call stack may appear to be written upside down, unless you see it as starting the the last code that was executed before the exception was thrown.  It continues up through the call stack, finally getting back to our code.  This might be easier to see.

Our `StrToNo()` method called `Convert.ToInt32()` which in turned called `Number.ParseInt32()` which finally called `Number.StringToNumber()` where our exception was _initially_ thrown.  Our exception _bubbles up_ through the call stack where it is finally _handled_ by our code.  That doesn't mean that no other code in between didn't handle the exception.  We'll see more on that in a bit.

Call stacks also indicate the _call site_, the place where code the was executed, by showing us the method signatures that were used and the line numbers of method where code execution seemingly stopped and sent the exception back up the stack to the next enclosing method call.

We can actually skip the `catch` block if we have a `finally` block.

    try
    {
        DoSomethingHere();
    }
    finally
    {
        CleanUpHere();
    }

In this case, if the exception emanating from our `try` block is _never_ caught, the `finally` block may or may not run depending on the platform that is running the code.  We generally use `finally` blocks to clean up external resources such as files or network connections that we were using.  If the exception that is thrown in the `try` block and is never caught it _may_ cause your entire application to come crashing down.  It will certainly do this with a console app.  This author can't think of a reason of using a `try` without a `catch`.  We usually want to do something with the exception.

The `finally` block is optional when using `try` with `catch`.  

### `throw`

Sometimes we want the code above ours to handle lower level exceptions.  A prime example of this is that we often implement exception handlers in our web applications at the top most level to provide a mechanism for catching _all_ exceptions in the exact same way and log them to a file, Windows Event Viewer, a database, or a 3rd party systems management platform.

If we want to use a `try`-`catch` block to perform some sort of operation before letting the exception bubble up the stack, we can re-throw the exception from the catch block with the `throw;` statement.  If you are not going to use the exception data within the `catch` block, omit the parentheses and type + variable declaration as follows.

    try
    {
        DoSomethingHere();
    }
    catch
    {
        throw;
    }

You may be tempted to do the following:

    try
    {
        DoSomethingHere();
    }
    catch (Exception exc)
    {
        throw new Exception(exc.Message);
    }

This is a very bad practice that is all too common.  If you use `throw;` alone, it will preserve the call stack all the way through and will help you to debug the program to figure out what happened.

There is another constructor overload that lets us package up the exception that we caught and send it up through as a _child_ or _inner_ exception to our new exception.

    try
    {
        DoSomethingHere();
    }
    catch (Exception exc)
    {
        throw new Exception("OOPS", exc);
    }

This would restart the call stack at the site at which we threw it, but helps preserve the original exception.  When trying to solve your code problems, always check the `InnerException` of the `Exception` object for further information.

## `throw` Your Own

Best practice _used_ to state that if your code was to throw an exception it should throw a custom-created exception type.  There is no problem with that, however, some framework exceptions have become so ubiquitous that it would be a shame _not_ to use them, as they convey very specific meanings.  However, you should not throw `Exception` directly, instead use `ApplicationException` as a "better" practice.  The following are just some of the framework exceptions that you _should_ use in your code.  All are found in the `System` namespace.

%% JLC: make sure these are all instantiable!

    ArgumentNullException
    ArgumentException
    ArgumentOutOfRangeException
    NullReferenceException
    DivideByZeroException
    IndexOutOfRangeException

A> You will learn how to create your own exceptions in the chapter on inheritance.

You can throw an exception from _nearly_ anywhere in your code.  Do not throw an exception in a constructor.  It will never be expected.  To throw an exception, as we have seen above:

    throw new ApplicationException("Put your message here.");

There is a special type of exception that allows us to do something like declaring a method without a return value.  This exception is used as a placeholder for code that has not yet been rewritten.  An example:

    public string MakeSomeString()
    {
        throw new NotImplementedException();
    }

Normally, this code would not compile, but this this specific exception, it does not.

There are an entire class of exceptions that either can't be caught, can't be handled, or automatically re-throw when handled.  These odd exceptions include: `OutOfMemoryException`, `ThreadAbortException`, and `StackOverflowException`.  It is enough to know that some exceptions are treated differently by the runtime.

### Another Example

Here is an example of bubbling an exception up through to the top calling method, in this case, `Runner.Execute()`.

<<[Successive Exceptions](cs/ch08-03.txt)

<<[Code Output](cs/ch08-04.txt)

You can see that we left out the `(Exception exc)` from the inner-most exceptions because we are re-throwing the original exception.  Also note that `Console.WriteLine()` has an overload that accepts an `Exception` object.  Finally note that `ExceptionsA.DoSomething()` has a null return at the end.  Because we are logging the exception and _not_ re-throwing it, all paths must return a value.  If our `try` block throws an exception it next goes into the `catch` block and from there code execution continues within the `DoSomething()` method which _must_ return a value.

## Exception Miscellany

* __TODO__
* where to exception catch/throw
* logging
* exception filtering: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6
* don't use exceptions as flow-control!!!


## Static Constructors


