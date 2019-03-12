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

There are a lot of caveats about using variables in lambda expressions and statements that you refer to within the lambda.  Ensure that you variable is initialized prior to defining the lambda.  It might be best to stick with simple data types when using lambdas.

## Action<T>

`Action<T>` is a generic delegate type that does not return a value.  We say that it has a _void_ return.  `Action<T>` is able to take up to 16 parameters as defined by the framework.  To declare an instance of one that takes three parameters we use `Action<T1, T2, T3>`.  Let's see a simple example.

    Action<List<string>> printer = x =>
    {
        foreach (var str in x) Console.WriteLine(str);
    };
    List<string> strings = new List<string> { "A", "B", "C" };
    printer(strings);

Here we create the delegate type which is an `Action<T>`.  In this case the type we are passing into it is a `List<string>`.  `printer` is a pointer to the anonymous method which will be invoked to execute the code within the statement lambda.  The method defined here simply loops through the `List<string>` passed into the `Action<T>` instance `printer` and prints them to the console.

As it currently stands we have not seen anything too interesting.  This is just basic lambda, delegate, and anonymous method usage.  Let us now turn to how powerful `Action<T>` becomes when used as a parameter to a method.

    public static class Extensions
    {
        public static void SortAndRunEach(
            this List<string> input,
            Action<string> actionToPerform)
        {
            if (input == null)
                throw new ArgumentException($"{nameof(input)}: argument null");

            if(actionToPerform == null)
                throw new ArgumentException(
                    $"{nameof(actionToPerform)}: argument null"
                );

            var sorted = new List<string>(input);
            sorted.Sort();

            foreach(var s in sorted)
            {
                actionToPerform(s);
            }
        }
    }

To use this extension method:

    List<string> myStrings = new List<string> { "C", "B", "A" };
    myStrings.SortAndRunEach(x => Console.WriteLine(x));

Here we create an extension method that performs an `Action<T>` on each list element.  The method takes as its second argument an `Action<string>`.  We first check to ensure that the arguments are not null.  We are using the `nameof` keyword to get the name of the arguments passed into the method.  This keyword is useful because we can change the argument name and know at compile time that we changed it.  If we just embedded the raw string name of the argument and changed its name, the exception's message would be fairly useless.

The extension method also creates a new list prior to sorting as we may not want the caller to be sorted.  This prevents the list called `myStrings` from being sorted when we call our extension method.  Finally, we loop through each string in the list and perform the action on it.

To use this extension method, we create a new `List<string>` and invoke `SortAndRunEach()` with an argument that is a `Func<T>`.  `x` is the parameter to be passed into the `Func<T>` and the lambda expression it calls `Console.WriteLine()` on the instance of the parameter, `x`.  In this example, the compiler automatically infers the type, `string`, to be the argument to the `Func<T>`.

The power of the `Func<T>` here is that _we_ decide which action to perform on the data passed into the extension method.  This is especially helpful if you are using an extension method created by someone else.  We can perform literally any type of method against the `string` in our `List<string>`.  We decide _what_ the implementation \(extension method\) does.

## Func<T, TResult>

`Func<T, TResult>` is very similar to `Action<T>` for the exception that it returns a value.  The frameworks contain 16 versions of the `Func` delegate that take up to 16 input parameters.  One example is `Func<T1, T2, T3, TResult>` which takes three arguments.  The return type is always the last in the list between the angle brackets.

    Func<int, int, int> kaPow = (x, y) => (int)Math.Pow(x, y);
    int result = kaPow(2, 18);

A> So far we have been looking at the building blocks of things that, I promise you, have something to do with generics.  We are leading up to the next chapter which is on LINQ \(pronounced "link"\).  LINQ is an acronym for **l**anguage **in**tegrated **q**uery.  LINQ augments generic types with a query language and family of extension methods that make working with generic collections much easier.  The topics in this chapter will help us with using LINQ and constructing LINQ-type features in C#.  We will also learn how to use and create fluent APIs.

## Generic Methods

We can define methods that take _any_ C# type.  We have seen methods that can take interfaces, classes, enumerations, and structs as type parameters.  With generic methods we can create a method that takes _all_ of these types.  This method definition uses the lambda syntax but could equally use the standard code block `{}` syntax that uses braces. 

    public static void Printer<T>(T input) => 
        Console.WriteLine(input.ToString());

This method takes an undefined type, `T`, and writes its value to the console.  We are explicitly calling the `ToString()` method from `object`, the base class from which everything in C# is derived.  We don't actually need to call `ToString()` as the `Console.WriteLine()` does have a method overload that takes an object.  `ToString()` is explicitly shown here to give a sample of how instance methods can be used on a generic type.

To call this method:

    Printer(DateTime.Now);

The type is inferred from the compiler which in this case is a `DateTime` type.  We call it like a normal method with one parameter.  In this case, the method body is defined by using the lambda syntax that points to an expression.  If the compiler for some reason has a problem with inferring the type you may specify it explicitly when calling the method.

    Printer<DateTime>(DateTime.Now);

You can also return the specified generic type from the result of the method.

    public T DoSomething<T>(T arg1, T arg2) 
    {
        // return something of type T
    }

You may also use more than one type in your generic method.

    public U DoSomethingElse<T, U>(T arg1, T arg2)
    {
        // return something of type U
    }

From what we have seen so far, there is not much you will be able to do with these last two examples.  They are provided here to show the syntax for a method that returns a generic type and another in which you specify more than one generic type.

Finally, there is one important thing to note here.  You cannot compare two generic types using the `==` operator.  You _may_ compare them to `null`, but be warned that comparing a type that ends up being a non-nullable value type, the result will be `false`.

The important takeaway from this section is that you may specify a type or multiple types using the angle brackets.  You do not have to call your generic type parameter `T`.  It is simply a common convention resulting from the .NET Framework and its documentation from the days when generics were introduced.  The type names specified within the angle brackets `<>` allow you to use them in the method signature \(in both the parameter type(s) and return type\).

Generic classes may also be specified using the same syntax with the angle brackets `<>`.  We will look at them more in depth shortly.

## Generic Type Constraints

Generic methods show how we can create a method that takes or returns any C# type.  What if we want to constrain the allowable type?  What if we only want to allow value types or classes to be passed to our method?  That is where generic type constraints come in to play.  So far we have only been using the methods on `object`.  We could be casting our generic types, but using constraints is much more efficient and safe.

    public static bool AreEqual<T>(T arg1, T arg2)
        where T : IEquatable<T>
    {
        return arg1.Equals(arg2);
    }

The `where T` after the method signature tells the compiler that we are requiring that `T` must conform to certain parameters.  In this case we use the colon `:` operator which is used on type declarations to indicate inheritance or required interface implementations.  It does the same sort of thing here.  This is followed by an interface, `IEquatable<T>`.  Effectively, we stated that type `T` must implement the interface `IEquatable<T>`.  This applies to any parameters or a return type specified as by the arbitrary name `T`.  `IEquatable<T>` requires us to implement a type safe `Equals()` method on our type.  You do not need a generic class to implement a generic interface.  Also, implementing this interface helps us to get around the inability to use the `==` operator between generic parameters.

    public class TestClass : IEquatable<TestClass>
    {
        public int Value { get; set; } = 42;

        public bool Equals(TestClass other)
        {
            if(other == null)
                return false;
            return this.Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            else
                return this.Equals((TestClass)obj);
        }
    }

This is a non-generic class that implements the `IEquatable<T>` interface.  To do this, we place the interface name after the colon and use as its type parameter the name of your class.  It may look a little weird, but it is how we specify a concrete implementation of a generic interface.  When using `IEquatable<T>` you should also override `object`'s `Equals()` method and `GetHashCode()`.  The latter is not shown here.

You will note that our `object` version of `Equals()` requires that both objects be of the same type, `TestClass`.  This is the correct implementation and it is the expectation that the `Equals()` method will work this way.  It is not proper to check for equality by checking to see if our `obj` parameter implements `IEquatable<TestClass>`.  If you went that route, you you probably be tempted to cast `obj` to `IEquatable<TestClass>`.  This ends in a stack overflow exception as the compiler will determine that the best overload is the `object` version of the `Equals()` method.  `Equals()` ends up calling itself endlessly.

Here is another way to implement this using the `is` operator.  It uses some newer C# syntax called _pattern matching_, which we will cover later in this book.  The `is` expression returns `false` if the object being tested is `null`, therefore we don't need to check `obj` for null.  The `is` pattern matching expression in this case also casts our object to the desired form and creates an instance variable from it, `tc`.

    public override bool Equals(object obj)
    {
        if (obj is TestClass tc)
            return Equals(tc);
        else
            return false;
    }

The following creates two instances of the `TestClass` object.  Next it uses the new generic `Equals()` method that we implemented.  The last line uses our generic method that contains the constraint that requires the object sent into it to implement `IEquatable<T>`.

    TestClass tc1 = new TestClass();
    TestClass tc2 = new TestClass();
    bool b1 = tc1.Equals(tc2);
    bool b2 = AreEqual(tc1, tc2);

A> We briefly talked about operator overload resolution previously.  It still remains a complex topic and as before I warned that "your mileage may vary."  In this instance, C# prefers our generic type version of `Equals()` probably due to the fact that it doesn't have to box \(cast to type `object`\) the objects in order to compare them.  For that reason, we call the generic version from the one overridden from `object`.

There are many other things that you can use to constrain your generic types.  They are not limited to interfaces and classes.

| Constraint Name | Description |
|-----------------|-------------|
| class | Generic type must be a class. |
| Enum | Generic type must be an enumeration. |
| struct | Generic type must be a struct.  This is also to be used to specify that the generic type must be a ValueType.  You cannot specify System.ValueType. |
| new() | Generic type must have a default constructor. |
| Delegate | Generic type must be a delegate. |
| MulticlassDelegate | Generic type must be a of type MulticastDelegate. |

You may also specify multiple constraints for one generic type parameter.  In this example, `Z` must be a class with a default constructor and must implement `IList<Z>`.  In this instance, `IList<>` must use the same type as `Z`.

    public bool IsTrue<Z>(Z someThing)
        where Z : class, IList<Z>, new()
    {
        return true;
    }

For multiple generic types you will use multiple where clauses.  We will see some examples of this in a bit.

        public bool IsFalse<T1, T2>(T1 something, T2 someOtherThing)
            where T1 : class
            where T2 : struct
        {
            return false;
        }

There are limits to what you can specify in a generic type constraint.  For example, you can't specify that you only want to allow numeric types or specific types of numeric types.  You will still have to perform type checking manually and use method overloads if creating an API that performs numeric calculations on a variety of types.

## A Real Example

Let's see a real example of a generic class.  We have seen enough of the theory behind generics to see how we construct one.  We'll be going through this one piece at a time and put it all together in the end.

A> One quick note about generic classes and generic interfaces...  Generics are very powerful and enable us to write code that would otherwise be ugly and much more bug prone due to constant boxing and unboxing.  We are building two things in this example.  The first is an _abstract_ piece of software that can be used with an unlimited number and type of objects as long as they adhere to our interfaces and generic type constraints.  We will also be creating a _concrete implementation_ of those abstract pieces.  We call this a concrete implementation because it take all of the constituent parts and that don't do anything on their own, mix them up, and make a solid product that actually does something.  The parts don't mean much without the implementation.  

For this example we will be creating a class that will allow us to model a classic tree structure.  Our tree will be fairly simple.  We will be modeling a category tree structure.  Our tree has one trunk and branches that can each have many branches.  We can think of it as something like the following.  We will call each piece of the tree a _node_.  Each node can have multiple notes.

* Root Category
  * Category 1
    * Category 1.1
    * Category 1.2
    * Category 1.3
      * Category 1.3.1
      * Category 1.3.2
        * Category 1.3.2.1
    * Category 1.4
      * Category 1.4.1
  * Category 2
    * Category 2.1
      * Category 2.1.1
        * Category 2.1.1.1
      * Category 2.1.2
    * Category 2.2

Each bullet point in the sample above is represented as an `ITreeNode<T>` in our example.  Type `T` will be required to implement `IIdentifiable`, which is a simple interface that has a `Name` and an `Id`.

<<[`IIdentifiable`](cs/ch14-01.cs)

Next we will create a concrete implementation of `IIdentifiable` that will be used to hold the data in each `TreeNode`.

<<[`Category`](cs/ch14-02.cs)

So far, so good.  This is pretty basic stuff.  The next part gets a little more interesting.

<<[`ITreeNode<T>`](cs/ch14-02.cs)

This _generic_ interface forms the basis of what we will be using to build each node in our tree structure.  Each node has a `Parent` object which points to the next level higher, its parent.  The root node's parent will be `null`.  Each node also contains a list of its child nodes in the `Children` property.  You will notice that we aren't currently using `IIdentifiable` yet.  That will come when we create a concrete implementation of `ITreeNode<T>`.  `ITreeNode<T>` is really an abstraction to enable us to reuse our code.  Let's look at each of the members of the interface.

First, using this interface requires us to implement `IEnumerable<T>`.  This will help us loop through the children in our generic collection.  Each item in the `foreach` will returns an `ITreeNode<T>`.  We also must implement the non-generic `IEnumerable`.  You should always implement both the generic and non-generic versions of `IEnumerable`.

For the members, we store the value from type `T` in the `Value` member so that we may refer to it later.  You will see why this is necessary in a bit.

Next, since each node is an `ITreeNode<T>` we use that as the `Parent` member.  We use a generic `ICollection<T>` to require and allow us to use one of many types of generic collections.  This provides flexibility to the implementer to use their own collection or one of many framework defined collections such as `List<T>` or even `SortedSet<T>`.

We also have a method to add a child node to each node.  The final member, `RecurseAndPerformAction` will help us loop through the current node, its child nodes, their child nodes, and so forth.

A> JLC TODO: Please note that at this point in our sample we don't have a good way to populate our tree structure.  We'll build that up as we go along.

Next, let's see how to implement the `ITreeNode<T>` interface on a concrete class to see how doing any of this makes sense.

    // MORE TODO

### Conclusion

    // TODO
