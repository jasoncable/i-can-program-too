# Objects and Classes \(Events through Nested Types\)

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

## Events \(Instance\)



## Operators \(Instance\)

## Indexers \(Instance\)

## Constructors \(Static and Instance\)

## Finalizers \(Instance\)

## Nested Types \(Static and Instance\)

%% ---------------------------

### static classes

> _"An interface defines a contract."_
>
> -Standard ECMA-334: C# Language Specification, 1st Edition

### abstract, interfaces

### multiple-inheritance

### Operator Overloading

### overriding members

%% ---------------------------

### sealed

