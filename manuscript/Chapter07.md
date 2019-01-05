# Objects and Classes

> _"I invented the term 'Object-Oriented', and I can tell you I did not have C++ in mind."_
>
> -Alan Kay

A> ## Author's Note
A>
A> This chapter describes things in a way that is suitable for learning C#.  For example, I know that the storage of `struct` vs. `object` is a matter of implementation, but is that important for even journeymen to know?  Also, is there a purpose for spending 30 or more pages on trivial things that most programmers will never run into?  This book is about programming, which in my mind is the valley between coding and engineering.  It's a place that most of us live.  Let's leave compiler optimizations and such to the engineers.

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

"Define polymorphism."  This is an commonly asked question in job interviews.  This author usually responds, "Polymorphism is the way of treating an object like another object."  The word polymorphism comes to us from the Greek word πολυμορφος, "of many forms."  Its concepts include the use of interfaces to enable us to define objects that are able to perform the same operation, generally in different ways.  It can also refer to using the same symbol, jargon for "name", to perform different operations based on context and/or input.

### Abstraction

Abstraction is the idea of only presenting the relevant information required to perform an operation.  In the statement, "birds fly", we only need to know that a `Bird` is capable to `Fly`.  For most purposes, we don't care about wingspan, weight, feather density, or tail length.  We abstract these properties away, keeping them hidden from normal view.  They are needed to provide the computations in modeling flight, but only to the person concerned with the physical process of flight.  Other properties may be made available to the public such as whether it is an African or European swallow.

### separation of concerns

### member vs. class vs. field

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

This is the most controversial part of the book.  It regards access modifiers.  In general practice, you will use `public` and `private` about 99% of the time.  I am only including the full list here because they comes up in job interviews.  The idea behind access modifiers make sense, but in practice, they are nothing but annoying.  The reason to have access modifiers:

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

