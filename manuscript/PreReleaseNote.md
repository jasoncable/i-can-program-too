# Pre-release Notes

{width=25%}
![](images/caution.png)

This book is being published in stages.  The writing is not exactly linear.  I am trying to go through the key functionality that I want to cover, then backfill with expanded examples and exercises.  The following is a partial todo list.

A> ### Big Warning \(2019-01-10\)
A>
A> The code in this book is being developed using .NET Core 3.0 __PREVIEW__ and C# 8.0 __PREVIEW__.  The last time I checked, Visual Studio for Mac 2019 does not support C# 8.0 syntax.  Code is being verified in Visual Studio 2019 Preview 1 \(on Windows 10, 64-bit\).

### High Level Todo List

* Test every line of code in C# 8.0 and .NET Core 3.0 once they are released.
* Restructure existing tests to align with new chapter numbers.
* Split up large chapters.
* Decide whether the difference between the words "parameter" and "argument" are significant.
* Revisit nullable reference types and their usage.
* More use of the `var` keyword.
* Exceptions \(don't know where to discuss them\).
* Backfill with more quotes from important computer scientists.
* A full edit and review.
* Type casting discussion with numeric value types.
* Description of `System.Object` methods.
* Optionally, illustrations and diagrams, as time and finances permit.
* Basic Visual Studio usage and screenshots.
* Test the epub, mobi, and web versions of the book.
* __SEE ALSO__ `TODO.md` in the repo as it is more frequently updated.

### Excluded on Purpose

* `unsafe` code.
* How to mutate strings.
* Boxing and unboxing, except in passing.
* `ArrayList` and `Hashtable` objects, prefer generic types.
* Floating point numbers
* Old school threading, prefer async/await, etc.
* `Tuple` object
* Anything listed in the "Reusable Components" appendix
* `in` parameters, unless required
* XML, JSON
