# My Personal Coding Style

> TIMTOWTDIBSCINABTE \(Tim Toady Bicarbonate\) - There’s more than one way to do it, but sometimes consistency is not a bad thing either.
>
> -the perl5 community

You may prefer other things, but I generally follow these practices. 

### Spaces vs. Tabs

I use indentation of 4 spaces.

### Namespaces

For personal projects, I start namespaces with `JasonCable.`

### Classes, Interfaces, Public Fields, Enums, Methods, Properties

Pascal case.

### Brace Style

Braces are always on a new line by themselves.

    if (x == x)
    {
        DoThis();
    }
    else
    {
        DoThat();
    }

Single-line continuation statements... usually.  It depends on readability

    if(true)
        DoThis();

### Private Fields

Start with underscore.

    private string _myString = "";

### Constants

I prefer `private static readonly`, but if I use constants, I do it csh/bash style.

    private const int HTTP_PORT = 80;

### C# Built-in Types

For type declaration, I prefer C#'s keywords over the framework type.

    int i = 0; // yes
    Int32 i = 0; // no

For static methods on C# built-ins, I prefer the framework version.

    String.IsNullOrWhitespace(s)
    Int32.TryParse(...)

### Default Access Modifiers

Never.  I always specify the access modifier, even if it is defaulted.

    public class MyClass() 
    {
        private string MyString { get; set; }
    }

### Local Variables

Camel case.

### Auto-setters

I always use these.

    public int MyInt { get; set; }

For collection types, I always set them to empty.

    public List<string> Strings { get; set; } = new List<string>();
    public List<string> Strings { get; set; } = new(); // C# 8

### Collection Types

I always initialize collection types to empty, ie. an empty List<T>.  It is 99% of the time the same as `null`.

### In-class Method Calls

When calling a method in a class I prefer to be thorough for readability.

    this.DoStuff(); // instead of DoStuff();
    this.PublicGetter = "my new value";
    base.DoOtherStuff();

### Names

#### Enumerations

    *Type, as in public enum StatusType

#### Attributes

They must end in the word `Attribute`.  When using, I leave off the `Attribute` word.

#### Exceptions

    *Exception, as in OopsIMadeAnException

#### Interfaces

    I*, as in IMyCar

#### Abbreviations

The original guidance from Microsoft during the .NET Framework 1.0 days was to only lowercase abbreviations with three or more characters.  I lowercase any that are two or more characters.  This is done for readability.

    HtmlReader
    DiskIoReader

### Life Lesson

Don't assume that everyone is looking at your code in the same IDE that you use.  They can vary wildly, even between two versions of the same IDE.  Microsoft Visual Studio 2008 to 2010 was a huge upgrade that included a rewrite from C++ to WPF.

If you publish your code on a place like GitHub, people may be reading it on the web with vastly different syntax highlighting from Visual Studio to make a difference.

If contributing to open source, follow their formatting rules.  Remember, some people like tabs!
