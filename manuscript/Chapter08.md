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

Constructors and methods follow many of the same rules including overload resolution.  One main difference is that we don't call constructors _directly_, only through the use of the `new` operator.

## Events \(Instance\)

## Operators \(Instance\)

## Indexers \(Instance\)

## Finalizers \(Instance\)

## Nested Types \(Static and Instance\)
