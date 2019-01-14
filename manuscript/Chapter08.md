# Objects and Classes \(Constructors through Nested Types\)

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
8. 

## Static Constructors

## Events \(Instance\)

## Operators \(Instance\)

## Indexers \(Instance\)

## Finalizers \(Instance\)

## Nested Types \(Static and Instance\)
