important value types (DateTime/DateTimeOffset/Timespan/Guid)

tuples
lambda expressions
Actions
Func
fluent

static classes deep dive?

stringcomparer

stringbuilder

# globalization/localization
    culture with numbers (, vs .) and dates

enumerations

fluent operations

## The One Year Problem

method "in" modifier: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/in

typeof

### attributes on classes and method parameters https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/

### is and as

### type checks

### Pattern Matching \(including advanced switch statements, incl. return statement\)

### async/await

### separation of concerns

### Splitting Strings

### Joining Strings

### array.IndexOf

### yield return

### String Interpolation

### .ToString()

## Enumerations

### ArrayList and Hashtable

### nameof()

### 3 types of using

### using to release resources, IDisposable

### structs
    and they don't have parameterless .ctors

### dynamic objects
    Expando Object

### task parallel library?

### Partial classes and methods

### anonymous types

# using static (from C#6): NO effing way!

### overload == and != WITH .Equals()
    https://docs.microsoft.com/en-us/visualstudio/code-quality/ca2224-override-equals-on-overloading-operator-equals?view=vs-2017

## executables need to be recompiled for each platform due to things like Windows PE Headers, etc.

Recursive methods (unbounded)
Managed vs. unmanaged code
File.openread
Regexes
Path.Combine
Write buffers
No file rename

Serialization?

deep/shallow (clones)

## NO...
covariance/contravariance, but found it on XmlNodeList iterator in .NET Core 2.1
