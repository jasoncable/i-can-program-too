# Creating Generics

This chapter will look at all of the constituent parts in C# that help us understand what we can do with generics and how to construct them.  Lambdas, Func<T, TResult>, Action<T>, interfaces, and extension methods are heavily used in creating and using generics.  We will also be looking at the culmination of this, LINQ, in the next chapter.

## Lambdas and Delegates

We briefly saw how delegates are used in C# with events.  We have seen the lambda operator, `=>`, used in expression-bodied members.  Lambdas allow us to specify a method inline in our code.  You can effectively create an _anonymous method_ with lambdas.  We call these anonymous because they are not named and are _embedded_ in our code, not coded by using a named method.

A delegate is a reference to a standard method or a lambda-defined anonymous method.  They allow us to pass method definitions as parameters to other methods.  This allows us to create general purpose methods that can perform operations solely based on the behavior passed into a method by using a delegate.  This chapter will end in a full-featured example of creating a generic type real-world example.  First, let's look at a simple lambda definition and use of a delegate.

    public class Delegates
    {
        private delegate int myDelegate(int x, int y);
        public static void RunMe()
        {
            myDelegate addIt = (x, y) => x + y;
            int z = addIt(123, 321);
        }
    }

The first thing we do here is to define a private member of type `delegate`.  `int` is the return type.  Our delegate's type name is `myDelegate` and specifies that the function to be defined will take two `int`s as parameters, `x` and `y`.  `myDelegate` is used as a new type.  It does _not_ define a method body, however.  It simply exists to be a reference to a method body that we will define later.

In this example we see in the first line of the `RunMe()` method defines an instance of type type called `addIt`.  As defined by the type `myDelegate` it must take in two `int` parameters and return an `int`.

We set an instance of the `myDelegate` type called `addIt`.  Using the lambda syntax that allows us to pass in two variables, we use the syntax `(x, y)` followed by the lambda operator `=>`.  Finally, we define the operation to perform `x + y`;

We can now use our defined method, `addIt` which takes two `int` parameters and returns an `int` as its result.  We will be using two generic framework types to use as delegates, but it is important to understand how delegates work in general to be understand them.

### Lambda Syntax

We have seen lambda expressions in the following form for expression-bodied members.  The part after the lambda operator `=>` is called the _lambda expression_.

    x => x + x;

To pass in two parameters observe the following two examples.  We generally don't have to specify the types of input parameters as the compiler can usually infer them.

    (string x, string y) => x.Contains(y);
    // or
    (x, y) => x.Contains(y);

You don't have to pass in any parameters.

    () => DateTime.Now.ToString("d");

We can also use braces \(curly brackets\) to specify a _statement lambda_ which contains multiple lines of code.  Since we are using multiple statements we must use semicolons to separate the lines.

    x => { DateTime now = DateTime.Now; Console.WriteLine(now.ToString("d"); }

One final note, statement lambdas and lambda expressions should not use variables from their parent scope.  The can and there are many rules surrounding that usage.  You may discover them on your own.

## Action<T>

`Action<T>` is a generic delegate type that does not return a value.  We say that it has a _void_ return.  `Action<T>` is able to take up to 16 parameters as defined by the framework.  To declare an instance of one that takes three parameters we use `Action<T1, T2, T3>`.  Let's see a simple example.

    Action<List<string>> printer = x =>
    {
        foreach (var str in x) Console.WriteLine(str);
    };
    List<string> strings = new List<string> { "A", "B", "C" };
    printer(strings);

Here we create the delegate type which is an `Action<T>`.  In this case the type we are passing into it is a `List<string>`.  `printer` is a pointer to the anonymous method which will be invoked to execute the code within the statement lambda.  The method defined here simply loops through the `List<string>` passed into the `Action<T>` instance `printer` and prints them to the console.

## Func<T, TResult>

    // TODO

## Generic Methods

Let's quickly review how a lambda expression is used instead of a traditional method declaration with braces.  This method is defined as a class-level member.

    public static void Printer<T>(T input) => 
        Console.WriteLine(input.ToString());

This method takes an undefined type, `T`, and writes its value to the console.  We are explicitly calling the `ToString()` method from `object`, the base class from which everything in C# is derived.  We don't need to call `ToString()` as the `Console.WriteLine()` does have a method overload that takes an object.

To call this method:

    Printer(DateTime.Now);

The type is inferred from the compiler which in this case is a `DateTime` type.  We call it like a normal method with one parameter.  In this case, the method is defined as a delegate using the lambda syntax that points to an expression.

    // MORE TODO

## Generic Interfaces

    // TODO

## Generic Classes

    // TODO

### Conclusion

    // TODO
