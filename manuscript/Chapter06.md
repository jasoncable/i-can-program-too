# Objects

> "I invented the term 'Object-Oriented', and I can tell you I did not have C++ in mind."
>
> -Alan Kay



### Splitting Strings

### Joining Strings

### array.IndexOf

### String Interpolation

### Convert.ToString()

### .ToString()

### Exceptions

### access modifiers

### extension methods



### static

### abstract, interfaces

### multiple-inheritance

### ArrayList and Hashtable

### attributes

### nameof()

### Scoping of variables

### 3 types of using

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

