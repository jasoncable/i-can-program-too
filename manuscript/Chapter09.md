# Exceptions

Before we continue on to more class member types, we need to talk about error handling in .NET.  First let's talk a little about object, specifically, class inheritance.  This is just an basic introduction of inheritance.  It will be covered in detail in the chapter on interfaces and class design structures.

## A Brief Introduction to Inheritance

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

## Handling Exceptions

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

## An Example and Three Questions

This brings up a few questions.  First, what exactly happens when the exception is thrown?  Second, what if we don't know the type of exception could possibly be thrown?  Third, what is this `.ToString()` stuff?  We need to see a more in-depth example to see how all of this works.

This code will be implemented in a console app.  It reads from the console line-by-line.  That means the `line` variable is set to "123" if you type: `123` followed pressing the `enter` or `return` key.  The newline is not part of the data in the variable.  To exit the loop, press enter with no value.

{line-numbers=on}
<<[Exception Catch and Print](cs/ch09-01.cs)
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

<<[Code Output](cs/ch09-02.txt)

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

## Another Example

Here is an example of bubbling an exception up through to the top calling method, in this case, `Runner.Execute()`.

<<[Successive Exceptions](cs/ch09-03.txt)

<<[Code Output](cs/ch09-04.txt)

You can see that we left out the `(Exception exc)` from the inner-most exceptions because we are re-throwing the original exception.  Also note that `Console.WriteLine()` has an overload that accepts an `Exception` object.  Finally note that `ExceptionsA.DoSomething()` has a null return at the end.  Because we are logging the exception and _not_ re-throwing it, all paths must return a value.  If our `try` block throws an exception it next goes into the `catch` block and from there code execution continues within the `DoSomething()` method which _must_ return a value.

C# also allows us to conditionally catch an exception of a certain type if a truth expression matches something on the exception.  The following checks a special property on `Exception` called `HResult`.  It can be used as a a standard error code that can be used to help document the origin of your exception.  You may set the `HResult` in a custom exception's constructor, which we will see in a little while \(hint: it has a `protected set`\).

    try
    {
        throw new ApplicationException("Yippee!");
    }
    catch(Exception exc) when (exc.HResult == 123)
    {
        Console.WriteLine(exc);
    }

## Conclusion

There are many times when you will want to catch and handle an exception.  This will be based on your own experience with the level of granularity that you require in the programs that you write.  One note though, do __not__ use exceptions to control the flow of your code.  It is as bad as using `goto` statements, if not worse.  Throw an exception when something occurs that prevents your method from continuing to run in a proper way.  Let's say that you have a method that performs an operation on a string and returns a new string.  Do you: return `String.Empty`, return `null`, or `throw` a new exception as a form of determining if an error occurred?  It is up to you, but you should be consistent.  It will save you time in the long run and will help others that might use your code.