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

Classes may be related to each other and share properties and ways of doing things through inheritance.  You can create an object called `Vehicle`.  It can contain data and operations that may be used by other objects that are related to it.  For instance, you can create classes called `Car`, `Truck`, and `Tractor` that inherit from `Vehicle`, which defines the basic definition of what a vehicle is and common things it can do.  This allows us to keep from repeating code to perform basic common operations on related objects.  For example, `Vehicle` might define the operation `Drive` or the string property `Manufacturer`.

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

overloading
overriding
void
extension methods


## Properties \(Static and Instance\)

## Events \(Instance\)

## Operators \(Instance\)

## Indexers \(Instance\)

## Constructors \(Static and Instance\)

## Finalizers \(Instance\)

## Nested Types \(Static and Instance\)



### static classes





## Enumerations




### separation of concerns

### Splitting Strings

### Joining Strings

### array.IndexOf

### yield return

### String Interpolation

### Convert.ToString()

### .ToString()

### Exceptions

### access modifiers

### extension methods

> _"An interface defines a contract."_
>
> -Standard ECMA-334: C# Language Specification, 1st Edition

### static

### abstract, interfaces

### multiple-inheritance

### ArrayList and Hashtable

### attributes

### nameof()

### Scoping of variables

### 3 types of using

### Operator Overloading

### is and as

### type checks

### Pattern Matching \(including advanced switch statements, incl. return statement\)

### return

## conditional access operator

### references on array objects

### variable scopes

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

