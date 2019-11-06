# C# Version History

A> There may be times when you have to deal with legacy code and need to know when certain features were added to C# and the .NET Framework/corefx.  The following is a summary of the introductions of various language features and technologies.
A>
A> Reference: <https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history>

| **C# 1.0**               |                          |
|--------------------------|--------------------------|
| .NET Framework 1.0       | * Classes                |
| Visual Studio 2002       | * Structs                |
| *NOTES:*                 | * Interfaces             |
| * Initial Release        | * Events                 |
|                          | * Properties             |
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

| **C# 1.2**               |                          |
|--------------------------|--------------------------|
| .NET Framework 1.1       | * `foreach` calls `.Dispose\(\)` on enumerator |
| Visual Studio 2003       | * some breaking Regex changes |
| *NOTES*:                 |                          |
| * Bug fix release and runtime update |              |
|--------------------------|--------------------------|

| **C# 2.0**               |                          |
|--------------------------|--------------------------|
| .NET Framework 2.0       | * Generics               |
| Visual Studio 2005       | * Partial Types          |
| *NOTES*:                 | * Anonymous Methods      |
| * Huge release with runtime update | * Nullable Value Types |
|                          | * Iterators              |
|                          | * Covariance/contravariance |
|                          | * Static Classes         |
|                          | * `get/set` separate accessibility |
|                          | * Method Group Conversions \(delegates\) |
|                          | * Delegate Inference     |
|                          | * ClickOnce              |
|                          | * WCF                    |
|--------------------------|--------------------------|

| **C# 3.0/3.5**           |                          |
|--------------------------|--------------------------|
| .NET Framework 3.0/3.5   | * Auto Properties        |
| Visual Studio 2008       | * Anonymous Types        |
| *NOTES*:                 | * Query Expressions \(LINQ\) |
| * Another large release with major runtime changes | * Lambdas                |
|                          | * Expression Trees       |
|                          | * Extension Methods      |
|                          | * `var` keyword          |
|                          | * Partial Methods        |
|                          | * Object and Collection Initializers |
|                          | * LINQ to SQL            |
|                          | * EntityFramework 1.0    |
|                          | * WPF                    |
|--------------------------|--------------------------|

| **C# 4.0**               |                          |
|--------------------------|--------------------------|
| .NET Framework 4.0       | * Dynamic Binding \(DLR\) |
| Visual Studio 2010       | * Named/Optional Arguments |
| *NOTES*:                 | * Generic Co/Contra-variance |
| * Major runtime and CLR changes hereafter frozen until .NET Core | * Embedded Interop Types |
|                          | * ASP.NET MVC 1.0        |
|                          | * EntityFramework 4.0    |
|--------------------------|--------------------------|

| **C# 5.0**               |                          |
|--------------------------|--------------------------|
| .NET Framework 4.5       | * Asynchronous Members   |
| Visual Studio 2012       | * `async/await` operators |
| *NOTES*:                 | * Threading `Task` APIs  |
| * .NET Standard 1.0 - 1.1 | * MEF                    |
|                          | * UWP                   |
|                          | * ASP.NET MVC 4          |
|--------------------------|--------------------------|

| **C# 6.0**               |                          |
|--------------------------|--------------------------|
| .NET Framework 4.5.1     | * Static Imports         |
| Visual Studio 2013       | * Exception Filters      |
| *NOTES*:                 | * Auto Property Initializers |
| * Roslyn compiler        | * Expression Bodied Members |
| * .NET Standard 1.2      | * Null Conditional Operator `?.` |
|                          | * Null Coalescing Operator `??` |
|                          | * String Interpolation   |
|                          | * `nameof` operator      |
|                          | * Index Initializers     |
|                          | * `await` in `catch/finally` Blocks |
|                          | * Default Values for Get-Only Properties |
|                          | * EntityFramework 6.0    |
|--------------------------|--------------------------|

| **C# 7.0**               |                          |
|--------------------------|--------------------------|
| .NET Framework 4.6 - 4.6.2 | * Out Variables          |
| Visual Studio 2015       | * Tuples \(as a language feature\) |
| *NOTES*:                 | * `System.ValueTuple`    |
| * .NET Standard 1.3 \(4.6\) | * Deconstruction         |
| * .NET Standard 1.4 – 2.0 \(4.6.1\) | * Pattern Matching    |
| * .NET Standard 1.0 – 1.6 \(Core 1.0\) | * Local Functions |
| * .NET Standard 2.0 \(Core 2.0\) | * Expanded Expression-bodied Members |
|                          | * `ref` locals and returns |
|                          | * Discards               |
|                          | * Binary Literals and Digit Separators |
|                          | * Throw Expressions      |
|                          | * WPF/WinForms HiDPI Support |
|                          | * .NET Core 1.0 - 2.1    |
|--------------------------|--------------------------|

| **C# 7.1**               |                          |
|--------------------------|--------------------------|
| * .NET Framework 4.7     | * `async` `Main()` Method |
| * .NET Core 2.0          | * Default Literal Expressions |
| Visual Studio 2017 v15.3+ | * Inferred Tuple Element Names    |
|                          | * Pattern Matching on Generic Type Parameters |
|--------------------------|--------------------------|

| **C# 7.2**               |                          |
|--------------------------|--------------------------|
| * .NET Framework 4.7     | * `in` Parameters        |
| * .NET Core 2.0          | * `ref` `readonly`       |
| Visual Studio 2017 v15.5+ | * `readonly` Structs     |
|                          | * `ref` Structs         |
|                          | * Non-trailing Named Arguments |
|                          | * Leading Underscores in Numeric Literals |
|                          | * `private protected` Access Modifier |
|                          | * Ternary Operator Can Use `ref` |
|--------------------------|--------------------------|

| **C# 7.3**               |                          |
|--------------------------|--------------------------|
| * .NET Framework 4.7.2   | * Improvements to `ref` Locals, `stackalloc`, Arrays, Fixed Statements, etc. |
| * .NET Core 2.1          | * Multiple Generic Constraints |
| Visual Studio 2017 v15.7+ | * `==` and `!=` with Tuples |
|                          | * Expanded Use of Expression Variables |
|                          | * Attributes on Auto-Properties |
|                          | * Additional Uses of the `in` operator |
|--------------------------|--------------------------|

| **C# 8.0**               |                          |
|--------------------------|--------------------------|
| * .NET Framework 4.8\* \(final release\) | * `readonly` Members |
| * .NET Core 3.0     | * Default Interface Methods |
| Visual Studio 2019          | * Pattern Matching in Switch, Properties, and Tuples |
| * *Certain features of C# 8.0 not implemented in Framework 4.8* | * Positional Patterns |
| * .NET Standard 2.0 \(4.6.1+\) \[last for Framework\] | * `using` Declarations |
| * .NET Standard 2.1 \(Core 3.0\) | * Static Local Functions |
|                          | * Disposable `ref` Structs |
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
