# First Things First

C# \(pronounced "see sharp"\) is a modern programming language that was developed by Microsoft.  It was released to the public in 2002 in response to the rapid adoption of the Java programming language in the business environment.  It is a general purpose language that is supported by a vibrant community.  C# is used from everything from system administration to web applications to game development.  It is also a portable language that is able to be run on Windows, Linux, and macOS.

C# is a compiled language.  It must be run through a special program called a compiler to translate the text that you typed into something that the computer can understand.  In the case of C#, the language that is output from the compiler is called the Common Intermediate Language \(CIL\).  This output is not directly executable by the computer.  The Common Language Runtime \(CLR\) is responsible for executing CIL.  CIL is portable, meaning that it does not have to be recompiled to run on other operating systems.  The CLR provides the environment to run the programs that we create.

Languages such as C#, VB.NET, and F# \(among others\) compile to CIL.  This system was created for several reasons.  The first is to enable different languages to be able to call each others code.  Interoperability is also provided by providing the same basic data types to each of these languages.  The CLR is also responsible for memory management and provides access to operating systems resources in a way that allows your C# code to run on multiple operating systems without the need to be changed.

This is a somewhat simplified of saying this, but generally, you first write code in your desired language using a text editor of some sort.  Next you compile the program.  The compiler creates a file that is CIL.  To execute the program, you need to invoke a program that starts up the CLR, which in turn executes the CIL.

## Runtimes

C# was released as an open standard.  This meant that the syntax and features of the language were freely available for others to use.  Microsoft also made the CIL \(then called MSIL\) a standard also.  These two standards allowed other companies to create compilers and runtime environments as they wished.

.NET \(pronounced dot net\) is the term for the ecosystem that Microsoft created surrounding C# and VB.NET.  It encompasses several languages, compilers, runtimes, and libraries.  .NET is a generic term for anything that compiles to CIL and runs via the CLR.

* **Microsoft runtime** - Microsoft's implementation was initially released to the public in 2002.  It only ran on Microsoft's own Windows operating systems on 32-bit Intel processors.  It later allowed running applications on 64-bit versions of Windows.
* **mono** - mono was first released in 2004 for the purposes of allowing C# code to run on other operating systems, especially Linux.  It was developed as an open source project, meaning that the source code was available for all to use and contribute to.  mono is still actively developed, having been purchased by Microsoft in 2016.  It is used in Xamarin, an environment that allows C# programs to run on iOS and Android devices.
* **Unity** - Unity is primarily a gaming engine.  It allows people to write games that run on multiple different operating systems.  Unity is based off of mono and updates from mono regularly.
* **Silverlight** \(defunct\) - Silverlight was a runtime environment that allowed C# programs to be executed within a web browser.  This was Microsoft's attempt to compete with Adobe's Flash.  Both Flash and Silverlight have been replaced by HTML5.
* **.NET Core** - This is the next generation of .NET.  Microsoft spearheaded an effort to create a new C# compiler, runtime, and framework that would be portable.  It is meant to be light-weight and to provide a stable base to bring an updated .NET ecosystem.  The compiler and various framework libraries are allow open source.  This means that anyone can see the source code and contribute to its development.

## Frameworks

C# by itself can be used to create programs.  Unfortunately, it would be very difficult to do anything meaningful without a framework.  The various frameworks provide libraries that allow you to code by using reusing standard components.  Microsoft defined a core set of functionality in the Framework Class Library standard.  These were implemented separately in each of the runtimes.  All of the frameworks provide a way of reading and writing to files, interacting with resources over a network, and much more.

* **.NET Framework** - Microsoft's proprietary implementation only runs on the various Windows operating systems.  First released in 2002, it provides the basis for a feature-right programming environment.  It allows programmers to write console applications, web applications, and Windows applications.  No new major features are being added to .NET Framework.  Microsoft will be only adding minor feature updates, bug fixes, and security fixes.
* **mono** - A framework created to mirror and add features to the .NET Framework with the specific goal of being able to run on multiple operating systems, not just Windows.  It is primarily used to power Xamarin.
* **Unity** - A framework created for game development.
* **.NET Core \(CoreFX\)** - A new set of libraries meant to eventually replace the .NET Framework.  Like mono and Unity, it is freely available to be used by anyone, anywhere for free.

## Starting Out

To best learn C# and .NET we will be using Visual Studio (Windows) or Visual Studio for Mac.  Both are available for no cost to individuals for use in educational settings.  Both have similar features, but are two different programs.  Visual Studio for Mac, previously known as Xamarin Studio and before that monodevelop was created by the mono project to be a competitive, free IDE to be used on multiple platforms.  We will be focusing on .NET Core and will be programming using C# version 7.3.  You can use the latest version of .NET Core and of either IDE, although you may have to specifically set the language version on the project settings.

<<[Your First Program](cs/ch02-01.cs)

This is the simplest program you can write.  It will be described in the next chapter.  First, we need to understand a few basics of programming.

## Variables

In computing, a variable is a way for you to easily to refer to something that is stored in the computer's memory.  Instead of referring to the physical address in memory, you give your piece of information a name.  In the following line of code, `int` tells the computer that this is a whole number.  `x` is our variable name.  `=` tells the computer that we want `0` to be placed in the computer's memory.  To summarize, we are telling the computer that we want the value 0 to be placed in the computer's memory and accessed in the future by the name `x`.

    int x = 0;

Variable names in C# can start with a letter or an underscore \(`_`\).  They can contain upper- and lower-case letters, numbers, and underscores.  Variable names are case-sensitive.  This means that `myVariableName` and `MyVariableName` are seen by the compiler as two different things.  There are no real guidelines as to what what case to use in your variable names or if you should use an underscore or not.  The following chart shows the various styles.  For our purposes, we will be using different styles to mean different things.  Variable names may be several hundred characters long, but in practice, it is unusual to see one over 25 characters or so.  Make your variable names describe the use of the variable.

| Camel Case | first letter is lowercase, no underscores | thisIsACamelCaseVariable |
| Pascal Case | first letter is capitalized, no underscores | ThisIsAPascalCaseVariable |
| Snake Case | lowercase with underscores separating words | example_of_snake_case |

In a variable name, it is customary to start each new word with a capital letter.  For example: `myNewCar` or `MyNewCar`.  If you are using an abbreviation longer than 2 characters, change it to use only an initial capital letter.  HTML is an abbreviation and would be treated as such: `HtmlToOutput`.

## Scalars

There are several types of variables.  Let's first look at the most basic type, the scalar.  For our purposes, a scalar is a variable that either holds or points to one piece of data.  C# is a *strongly typed* language.  This means that variables represent a certain type of information.  For now we will focus on numeric data types and strings.  A number in C# is generally represented as `123`, `12.3`, or `-1.23`.  A string is text.  Strings in C# are surrounded by double quotes, as in `"My name is Jason."`.  The following is a list of C#'s built-in data types.

| C# Type | CLR Type | Valid Values |
| --------|----------|--------------|
| bool | System.Boolean | true or false |
| byte | System.Byte | 0 to 255 |
| sbyte | System.SByte | -128 to 127 |
| ushort | System.UInt16 | 0 - 65,535 |
| short | System.Int16 | -32,768 to 32,767 |
| uint | System.UInt32 | 0 to 4,294,967,295 |
| int | System.Int32 | -2,147,483,648 to 2,147,483,647 |
| ulong | System.UInt64 | 0 to 18,446,744,073,709,551,615 |
| long | System.Int64 | -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 |
| float | System.Single | 1.5 * 10^-45^ to 3.4 * 10^38^, 7-digit precision |
| double | System.Double | 5.0 * 10^-324^ to 1.7 * 10^308^, 15-digit precision |
| decimal | System.Decimal | at least -7.9 * 10^-28^ to 7.9 * 10^28^, at least 28-digit precision |
| char | System.Char | One Unicode character |
| string | System.String | null, empty, or a sequence of characters |

### Numeric Literals

Numbers in C# are specified as literals.  This means that they are human-readable.  As we have seen, you can specify numbers as `123`, `1.23`, etc.  At times you may need to add a letter after the literal to help the compiler understand exactly what type of number it is.

| Type | Post-fix | Example |
|------|----------|---------|
| decimal | m or M | 12345.87m |
| double | d or D | 12345.87d |
| float | f or F | 12345.87f |
| long | l or L | -12345l |
| uint | u or U | 12345u |
| ulong | UL, Ul, uL, ul, LU, Lu, lU, or lu | 12345ul |

You can also add thousands separators in C#.  To represent `1,234,567`, you would normally write it as `1234567`.  You may add underscores for readability: `1_234_567`;

Other types of numbers may also be expressed in C# code.  This book focuses on base-10 numbers, but C# allows literals specified in hexadecimal \(hex\) or binary.  The following numbers represent the base-10 number `123`.  Hex numbers begin with `0x` whereas binary numbers begin with `0b`.

    0x7b
    0b1111011

Negative numbers work as you would think.  Just place a negative sign before the number in question.  While `5 - -5` will give the correct results, C# does not require spaces between operators.  Something like `5--5` should be equivalent, but it will give you an error.  Both `5-5` \(no spaces\) and `5-(-5)` are perfectly valid.

### Why So Many Types?

Many of these types have their origin in the C programming language.  They were used to save space on systems that had very little memory.  Some of these data types are rarely seen in C# code.  Modern computers are more capable than their 1970s counterparts.  They have memory measured in gigabytes, not kilobytes.  Today's processors also measure performance in \(or billions\), not thousands of operations per second.

In general, follow these rules:

* For whole numbers, use `int`, unless you need a bigger number, then use `long`.
* For fractional numbers, use `decimal`.  Floating point numbers \(`float` and `double`\) are mostly used in gaming and scientific applications.
* `byte` used in file and network operations.
* `char` is used to represent one character.
* `string` is used to represent text, although there are other ways.
* `bool` is used for logical operations.

### Default Values

The default value of most numeric types is `0`, except `char` which is `\0`.  This value is used in C to determine the end of a string.  If a value is not assigned to any of these types, except `char`, it is `0`.  Technically, the `bool` type can be seen as a numeric type representing a bit.  In computing, a bit is the smallest unit of data.  It represents the values `0` or `1`.  `0` being false and `1` being true.  The `bool`'s default value is `false`.

### Strings and Null

A string in C# is simply a sequence of characters.  Its default value is a special "value" called `null`.  Null is the absence of any value.  A null variable does not point to any data.  We can check to see if a string is null in order to determine if its value is set or not.  Strings can also be empty or `""`.  If you need to set something to `""`, use the constant `String.Empty`.  This is more efficient.

Strings are immutable.  This means that the value of a string cannot be changed in the area of memory in which it is stored.  You can change which string a variable is assigned to, but you can't change the physical spot in memory where the string is stored.   A string can hold at least one billion characters.  You will probably run out of memory before you are able to create a string of that length.  There are alternate methods of dealing with large amounts of data.

### The Heap vs. The Stack

The types listed in the table above, except for `string` are what is know as integral or value types.  They are stored in a special place in memory called the stack.  One more type is also stored on the stack called a `struct`.  Structs will be discussed later.

Just about everything else is stored on the heap.  This includes types such as `object`s \(sort of\) and strings.  These are known as reference types.  Their variables are special things called references because they point to a location in memory where the data is stored.  Things on the heap remain there until a special process called garbage collection happens.  

For now, just remember that value types are stored on the stack and reference types are stored on the heap.  This will become an important subject that we will discuss further in a later chapter.  Reference types point to the data they represent, while value types actually hold the value they represent.

A> Now, one thing in C# is quite bizarre.  Everything in C# is an `object`... even value types.  Normally, we say that all objects are stored on the heap.  The fact is that everything in C# can *look* like an object.  This allows us to programatically find out a variable's type amongst other things.  In the end, value types are stored on the stack and reference types the heap.

### Scalar Variable Assignment

We saw how to declare and set a variable in this chapter.  To recap:

    int x = 0;

Let's break this down into its different parts.  First is the declaration:

    int x

This tells C# that we are creating a variable called `x` that is of type `int` (a 32-bit integer).  This is a whole number that can be either negative or positive.  See the table earlier in this chapter for the list of valid values.

Next, we see the variable assignment:

    x = 0

This sets our variable, `x`, to the value `0`.

The entire line of code is called a statement.  All statements end in a semicolon \(;\).

You can declare a variable without setting its default value \(`bool` false, `char` `\0`, numerics `0`, `string`s and `object`s `null`\).

    int x;

We can explicitly set the default value to prevent us from receiving compiler errors such as "use of unassigned local variable."  This sets `x` to its default, `0`.

    int x = default;

This means that you are telling the compiler that you are going to use the variable `x` but are not going to set the value yet.  

A statement can span multiple lines.  The C# compilers ignore whitespace \(spaces, new lines, tabs\).

    int x =
    5
    ;

For more complex statements, this can increase the readability of the code.  Statements can also perform more than one operation at a time, as we will see in a bit.

A variable declaration always starts with the variable type or alternatively the `var` keyword when using type inference.  The type is followed by the variable name.  When assigning a value to a variable, we use the `=` sign.  In a statement, variable names always go to the left of the equals sign.

    x = 4;

not

    4 = x;

#### Special Cases

You can declare multiple variables of the same type at one type.  The following declares three variables.  Their value is the default value for `int`, `0`;

    int a, b, c;

You can set the value of multiple variables at the same time.  The following sets all variables to 5.  It does this from right to left.  It is evaluated as `c = 5`, then `b = c`, then `a = b`.

    a = b = c = 5;

## Math Operators

C# provides operators for adding, subtracting, multiplication, and division.  Other mathematical operations such as calculating exponents and rounding are available as static methods on the `System.Math` object.  Parentheses are used to group operations together and as in general math, they can influence the order of operations.

| + | addition |
| - | subtraction |
| * | multiplication |
| / | division |
| % | mod or modulo - gives the remainder of a division operation |

Some examples of operations.

    4 + 5
    4 + 5 * 3
    (4 + 5) * 3

In the first example, the result is `9`.  The second example `19` because, due to the standard mathematical order of operations, multiplication and division are performed first, before addition and subtraction.  The third example shows us that parentheses are evaluated first.  `4` and `5` are first added, then multiplied by `3`, giving us `36`.

In ordinary arithmetic, dividing by zero results in something that can't be defined.  In C# this will gives us error.

When performing numerical operations in C#, your answer cannot be greater or less than the valid range of values of the data types being used.  For `int`s, your result cannot be less than `-2,147,483,648` and cannot be greater than `2,147,483,647`.

A> ### Comments
A> In C#, as with most other languages, we have ways of adding notes, or comments, to our programs.  This text is simply ignored by the compiler.  Comments come in two flavors in C#.  They have their origins in the C and C++ languages.  Single line \(also called inline\) comments begin with two forward slashes, `//`.  The double slashes and everything that comes after them on a line are ignored by the compiler.  Multi-line comments start with a `/*` and end with a `*/`.
A>
A>    `int x = 5; // this is a comment and it is ignored by the compiler`
A>
A>    `/* x = 6;`
A>
A>    `x = 8;  */`
A>
A> Above, the single line comment allows us to write a note in the code.  Multi-line comments also allow us to do that.  In this instance, we are telling the compiler to ignore some code that we don't want to run anymore.  There are times when you want to keep old code around to refer to later.

### Adding in Variables

In the following example, we will see inline comments that explain how we put the operations we just learned about into practice.  This includes the use of multiple variables to create some basic calculations.  You can set the value of a variable any number of times.  You can also do things like adding a number to your variable and setting the result back to that original variable.

    int x = 1; // create an int and assign it the value 1
    int y = 2; // create an int and assign it the value 2
    y = x + 5; // set y equal to the value in x plus 5
    // y is now 6
    y = y + 1; // set y equal to the value of y \(6\) plus 1
    // y is now 7
    int z = x + y; // add x and y and assign them to the new variable z, an int
    // z is 8
    int a = z * 5; // multiple z by 5 and assign it to a
    // a is 40
    int b = z * 4 - 32 / 8;  // remember you order of operations from math!
    // b is 28
    int c = b * (2 - 3) * (16 / 8);
    // c is -56

In math, there is the concept of the remainder.  You probably saw it first when you learned long division.  In C#, we use the mod or modulo operator, `%`.  For whole numbers that divide evenly into each other, the remainder will be `0` in the example of `4` being divided by `2`, the answer is `2`.  It's remainder is `0`.  If you divide `4` by `3`, you have a remainder of `1`.

    int x = 4 / 2; // the answer is 2
    int y = 4 % 3; // the answer is 1

Above, we use the modulo operator to say the following: `4` is evenly divided by `3` one time with `1` being left over.

What happens when you divide two integers by each other?  Is the result a data type that has decimal places?  The answer is no.  C# will perform the division and give you a whole number result that is not rounded.  We call this truncation.  It simply means that any number that would be after the decimal point would be cut off.  For this, we need to us data types that support decimals \(`float`, `double`, `decimal`, etc.\).

    int x = 4 / 3; // the answer is 1
    decimal y = 4 / 3; // the answer is 1

You were probably surprised by that last answer.  The C# compiler is treating the literal numbers `4` and `3` like they are of of the whole number types.  To solve this problem, we need to use one of the special numeric literal post-fix specifiers that we learned about earlier.

    decimal y = 4m / 3m; // the answer is 1.3333333333333333333333333333

The computer is unable to tell us that the value `3` is a repeating number.  Exactly how many times will it show?  More often than not you will be rounding the result before presenting it to a user in any application.  You could write a program do manually perform long division, but this is not terribly helpful.  It is best to assume that the computer will give you an arbitrary number of repeating decimals, rounding the last decimal.

    decimal y = 2m / 3m; // the answer is 0.6666666666666666666666666667

### Assignment and Pre and Post Operators

There are shortcuts to common numerical operations.  These are the combined assignment and mathematical operators.

    int i = 1;
    i += 1;

This creates an int and assigns the value `1` to it.  The second line says, set `i` equal to `i + 1`.  It is the equivalent of `i = i + 1`.  There are other operators such as this.  They also work with variables.  

    int i = 1; // create a variable i and assign it the value 1
    int j = 2; // create a variable j and assign it the value 2
    i += j; // set i equal to i + j

| += | addition |
| -= | subtraction |
| *= | multiplication | 
| /= | division |
| %= | modulo |

C# also gives us the post- and pre- increment and decrement operators.  `i++` and `++i` increment the variable `i` by `1`.  When used in an expression, the post-increment operators such as `i++` first returns its value, then increases the number by `1`.  The pre-increment operators such as `++i` first increments the value and returns the new value.

    int i = 1;
    int j = i++; // j is 1

This creates the variable `i` and assigns the value `1` to it.  We then create an int, `j`.  Since we are using the post-increment operator, the value of `i` is returned first, then it is incremented.  The value of `j` is `1` in this example.

    int i = 1;
    int j = ++i; // j is 2

This example sets the value of `j` to `2`.  With the pre-increment/decrement operators, the variable they are applied to is first increased or decreased, then its value is returned.

## Conclusion

We have discovered that there are several different implementations of the C# compiler and accompanying framework.  These constitute the .NET ecosystem.  .NET is a cross-platform, widely used programming environment that allows us to create all types of applications from those that run on the desktop, server, cloud, and web.

We also discovered simple variables and have begin to explore C#'s type system.  Mathematical operators round out the chapter with careful attention to the wide variety of features in the language.  In the next chapter we will continue with scalars in the form of strings and introduce the concept of arrays.
