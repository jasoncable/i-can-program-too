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

## Static Constructors

Static constructors don't take any parameters and are not invoked by the use of the `new` operator.  They set values on static data and are run when an instance of the object is created or when a static member is used, returning the static value after the static constructor is finished running.  

Static constructors can be used for several things such as setting a `DateTime` for when the object was initially used or to read a configuration file and set, let's say, the path to a log file in your applications.  If an exception is thrown from a static constructor, it will not run again during the life of your program.

Static constructors can also be used to create and hold an instance of an object that you only want to instantiate once.  This is called the _singleton pattern_.  We will explore it more when talking about concurrent programming, because there are many issues to consider when implementing it.

<<[Simple Static Constructor Example](cs/ch08-01.cs)

## Expression-bodied Members

_Expression-bodied members_ are a relatively new introduction to C#.  The provide a terse, short-cut way to specify a _single_ expression that is used to define a constructor, method, property getter/setter, indexer, or finalizer.  We'll learn about indexers and finalizers in a couple of chapters.

The following shows an example of a normal method and its expression-bodied version.

    public string MakeUpperCase(string s)
    {
        return s.ToUpper();
    }
    // ----- //
    public string MakeUpperCase(string s) => s.ToUpper();

Non-void returns do not require the use of the keyword `return`.  You call the members the exactly same way.  The `=>` simply points to our expression.  The example below shows a constructor, a method, and getters/setters that use expression-bodied members.

    public class ExpressionBodiedMembers
    {
        private string _name;
        public ExpressionBodiedMembers(string s) => _name = s;
        public string ReturnUpperCase() => _name.ToUpper();
        public void SetToUpperCase() => _name = _name.ToUpper();
        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }

Use this class like any others.

    ExpressionBodiedMembers ebm = 
        new ExpressionBodiedMembers("Jason");
    Console.WriteLine(ebm.ReturnUpperCase());
    ebm.SetToUpperCase();
    Console.WriteLine(ebm.Name);
    ebm.Name = "Jason... again";

### Conclusion

This chapter has introduced the special type of method called a constructor.  We have also seen a little about access modifiers and expression-bodied members.  These are all important to help us understand more about the code of others and how to better construct our own code.  We have seen lots of options so far, and will see more in two chapters.  Next, we will take a timeout from class members to talk about how we handle errors in C#.
