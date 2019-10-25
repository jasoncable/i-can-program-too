# C# Version History

A> There may be times when you have to deal with legacy code and need to know when certain features were added to C# and the .NET Framework/corefx.  The following is a summary of the introductions of various language features and technologies.
A>
A> Reference: <https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history>

|--------------------------|--------------------------|
| **C# 1.0**               | * Classes                |
| .NET Framework 1.0       | * Structs                |
| Visual Studio 2002       | * Interfaces             |
| *NOTES:*                 | * Events                 |
| * Initial Release        | * Properties             |
|                          | * Delegates              |
|                          | * Expressions            |
|                          | * Statements             |
|                          | * Unsafe Code            |
|                          | * Attributes             |
|                          | * Enumerations           |
|                          | * WinForms               |
|                          | * ASP.NET \(Web Forms\)  |
|                          | * ADO.NET                |
|                          | * System.Xml APIs        |
|--------------------------|--------------------------|

|--------------------------|--------------------------|
| **C# 1.2**               | * `foreach` calls `.Dispose\(\)` on enumerator |
| .NET Framework 1.1       | * some breaking Regex changes |
| Visual Studio 2003       |                          |
| *NOTES*:                 |                          |
| * Bug fix release and runtime update |              |
|--------------------------|--------------------------|

|--------------------------|--------------------------|
| **C# 2.0**               | * Generics               |
| .NET Framework 2.0       | * Partial Types          |
| Visual Studio 2005       | * Anonymous Methods      |
| *NOTES*:                 | * Nullable Value Types |
| * Huge release with runtime update | * Iterators              |
|                          | * Covariance/contravariance |
|                          | * Static Classes         |
|                          | * `get/set` separate accessibility |
|                          | * Method Group Conversions \(delegates\) |
|                          | * Delegate Inference     |
|                          | * ClickOnce              |
|                          | * WCF                    |
|--------------------------|--------------------------|

|--------------------------|--------------------------|
| **C# 3.0/3.5**           | * Auto Properties        |
| .NET Framework 3.0/3.5   | * Anonymous Types        |
| Visual Studio 2008       | * Query Expressions \(LINQ\) |
| *NOTES*:                 | * Lambdas                |
| * Another large release with major runtime changes | * Expression Trees       |
|                          | * Extension Methods      |
|                          | * `var` keyword          |
|                          | * Partial Methods        |
|                          | * Object and Collection Initializers |
|                          | * LINQ to SQL            |
|                          | * EntityFramework 1.0    |
|                          | * WPF                    |
|--------------------------|--------------------------|

|--------------------------|--------------------------|
| **C# 4.0**               | * Dynamic Binding \(DLR\) |
| .NET Framework 4.0       | * Named/Optional Arguments |
| Visual Studio 2010       | * Generic Co/Contra-variance |
| *NOTES*:                 | * Embedded Interop Types |
| * Major runtime changes hereafter frozen until .NET Core | * ASP.NET MVC 1.0        |
|                          | * EntityFramework 4.0    |
|--------------------------|--------------------------|

|--------------------------|--------------------------|
| **C# 5.0**               | * Asynchronous Members   |
| .NET Framework 4.5       | * `async/await` operators |
| Visual Studio 2012       | * Threading `Task` APIs  |
| *NOTES*:                 | * MEF                    |
| * .NET Standard 1.0 - 1.1 | * UWP                   |
|                          | * ASP.NET MVC 4          |
|--------------------------|--------------------------|

|--------------------------|--------------------------|
| **C# 6.0**               | * Static Imports         |
| .NET Framework 4.5.1     | * Exception Filters      |
| Visual Studio 2013       | * Auto Property Initializers |
| *NOTES*:                 | * Expression Bodied Members |
| * Roslyn                 | * Null Conditional Operator `?.` |
| * .NET Standard 1.2      | * Null Coalescing Operator `??` |
|                          | * String Interpolation   |
|                          | * `nameof` operator      |
|                          | * Index Initializers     |
|                          | * `await` in `catch/finally` Blocks |
|                          | * Default Values for Get-Only Properties |
|                          | * EntityFramework 6.0    |
|--------------------------|--------------------------|

|--------------------------|--------------------------|
| **C# 7.0**               | * Out Variables          |
| .NET Framework 4.6 - 4.6.2 | * Tuples \(as a language feature\) |
| Visual Studio 2015       | * `System.ValueTuple`    |
| *NOTES*:                 | * Deconstruction         |
| * .NET Standard 1.3 \(4.6\) | * Pattern Matching    |
| * .NET Standard 1.4 – 2.0 \(4.6.1\) | * Local Functions |
| * .NET Standard 1.0 – 1.6 \(Core 1.0\)  | * Expanded Expression-bodied Members |
| * .NET Standard 2.0 (Core 2.0)  | * `ref` locals and returns        |
|                          | * Discards               |
|                          | * Binary Literals and Digit Separators |
|                          | * Throw Expressions      |
|                          | * WPF/WinForms HiDPI Support |
|                          | * .NET Core 1.0 - 2.1    |
|--------------------------|--------------------------|

|--------------------------|--------------------------|
| **C# 7.1**               | * `async` `Main()` Method |
| * .NET Framework 4.7     | * Default Literal Expressions |
| * .NET Core 2.0          | * Inferred Tuple Element Names    |
| Visual Studio 2017 v15.3+ | * Pattern Matching on Generic Type Parameters |
|--------------------------|--------------------------|

|--------------------------|--------------------------|
| **C# 7.2**               | * `in` Parameters        |
| * .NET Framework 4.7     | * `ref` `readonly`       |
| * .NET Core 2.0          | * `readonly` Structs     |
| Visual Studio 2017 v15.5+ | * `ref` Structs         |
|                          | * Non-trailing Named Arguments |
|                          | * Leading Underscores in Numeric Literals |
|                          | * `private protected` Access Modifier |
|                          | * Ternary Operator Can Use `ref` |
|                          | *                        |
|--------------------------|--------------------------|

|--------------------------|--------------------------|
| **C# 7.3**               | * Improvements to `ref` Locals, `stackalloc`, Arrays, Fixed Statements, etc. |
| * .NET Framework 4.7.2   | * Multiple Generic Constraints |
| * .NET Core 2.1          | * `==` and `!=` with Tuples |
| Visual Studio 2017 v15.7+ | * Expanded Use of Expression Variables |
|                          | * Attributes on Auto-Properties |
|                          | * Additional Uses of the `in` operator |
|                          | *                        |
|--------------------------|--------------------------|

|--------------------------|--------------------------|
| **C# 8.0**               | * `readonly` Members |
| * .NET Framework 4.8\* \(final release\)     | * Default Interface Methods |
| * .NET Core 3.0          | * Pattern Matching in Switch, Properties, and Tuples |
| Visual Studio 2019       | * Positional Patterns |
| * \*_Certain features of C# 8.0 not implemented in Framework 4.8 | * `using` Declarations |
| * .NET Standard 2.0 \(4.6.1+\) \[last for Framework\] | * Static Local Functions |
| * .NET Standard 2.1 \(Core 3.0\) | * Disposable `ref` Structs |
|                          | * Asynchronous I/O \(streams\) |
|                          | * Indices and Ranges |
|                          | * Null Coalescing Assignment |
|                          | * Unmanaged Constructed Types |
|                          | * `stackalloc` in Nested Expressions |
|                          | * Enhanced Interpolated Verbatim Strings |
|                          | * Nullable Reference Types |
|                          | * WinForms Port to Core \(Windows Only\) |
|                          | * WPF Port to Core \(Windows Only\) |
|                          | * EntityFramework 6.x Port to Core \(Windows Only\) |
|--------------------------|--------------------------|

## Prognostication

These are just my guesses at the future of the .NET ecosystem.

* No further releases for .NET Framework 4.x series aside from security and bug fixes.
* .NET Framework end-of-life to be delayed until at least 2030.
* .NET Core 3.1 will ship with C# 8.1 in early 2020.  These C# enhancements will not be added to .NET Framework 4.8.x.
* .NET 5 will ship in December 2020.  *Some* of the remaining features of .NET Framework 4.x \(WCF, WWF, MEF, etc.\) will be ported to .NET 5.
* Upgrades of ASP.NET MVC 5.x sites will be upgradeable via NuGet package updates and changes to configuration changes, as it is today.
* MVC 5 will *not* be ported to .NET 5.
* Visual Studio 2021 will ship in late 2020 with .NET 5 \(based on roslyn, corefx, coreclr, etc.\).
* All Xamarin products will be ported to .NET Core in time for the .NET 5 release.
* 64-bit Visual Studio will ship in 2023, as most of the team will be pulled for .NET 5.
* EntityFramework Core may or may not continue to be developed.
