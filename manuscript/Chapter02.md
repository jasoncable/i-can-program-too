# Chapter 2 - First Things First

C# \(pronounced "see sharp"\) is a modern programming lanuage that was developed by Microsoft.  It was released to the public in 2002 in response to the rapid adoption of the Java programming language in the business environment.  It is a general purpose language that is supported by a vibrant community.  C# is used from everything from system adminitration to web applications to game development.  It is also a portable language that is able to be run on Windows, Linux, and macOS.

C# is a compiled language.  It must be run through a special program called a compiler to translate the text that you typed into something that the computer can understand.  In the case of C#, the langage that is output from the compiler is called the Common Itermediate Language \(CIL\).  This output is not directly executable by the computer.  The Common Language Runtime \(CLR\) is responsible for executing CIL.  CIL is portable, meaning that it does not have to be recompiled to run on other operating systems.  The CLR provides the environment to run the programs that we create.

Languages such as C#, VB.NET, and F# \(among others\) compile to CIL.  This system was created for several reasons.  The first is to enable different languages to be able to call each others code.  Interoperability is also provided by providing the same basic data types to each of these languages.  The CLR is also responsible for memory management and provides access to operating systemn resources in a way that allows your C# code to run on multiple operating systems without the need to be changed.

I am somewhat simplifying this, but generatlly, you first write code in your desired language using a text editor of some sort.  Next you compile the program.  The compiler creates a file that is CIL.  To execute the program, you need to invoke a program that starts up the CLR, which in turn executes the CIL.

## Runtimes

C# was released as an open standard.  This meant that the syntax and features of the lanugage were freely available for others to use.  Microsoft also made the CIL \(then called MSIL\) a standard also.  These two standards allowed other companies to create compilers and runtime environments as they wished.

.NET \(pronounced dot net\) is the term for the ecosystem that Microsoft created surrounding C# and VB.NET.  It encompases several languages, compilers, runtimes, and libraries.  .NET is a generic term for anything that compiles to CIL and runs via the CLR.

* Microsoft runtime - Microsoft's implementation was initially released to the public in 2002.  It only ran on Microsoft's own Windows operating systems on 32-bit Intel processors.  It later allowed running applications on 64-bit versions of Windows.
* mono - mono was first released in 2004 for the purposes of allowing C# code to run on other operating systems, especially Linux.  It was developed as an open source project, meaning that the source code was available for all to use and contribute to.  mono is still actively developed, having been purchased by Microsoft in 2016.  It is used in Xamarin, an environment that allows C# programs to run on iOS and Android devices.
* Unity - Unity is primarily a gaming engine.  It allows people to write games that run on mulitple different operating systems.  Unity is based off of mono and updates from mono regularly.
* Silverlight \(defunct\) - Silverlight was a runtime environment that allowed C# programs to be executed within a web browser.  This was Microsoft's attempt to compete with Adobe's Flash.  Both Flash and Silverlight have been replaced by HTML5.
* .NET Core - This is the next generation of .NET.  Microsoft spearheaded an effort to create a new C# compiler, runtime, and framework that would be portable.  It is meant to be light-weight and to provide a stable base to bring an updated .NET ecosystem.  The compiler and various framework libraries are allow open source.  This means that anyone can see the source code and contribute to its development.

## Frameworks

C# by itself can be used to create programs.  Unfortunately, it would be very difficult to do anything meaningful without a framework.  The various frameworks provide libraries that allow you to code by using reusing standard components.  Microsoft defined a core set of functionality in the Framework Class Library standard.  These were implemented separately in each of the runtimes.  All of the frameworks provide a way of reading and writing to files, interacting with resources over a network, and much more.

* .NET Framework - Microsoft's proprietary implementation only runs on the various Windows operating systems.  First released in 2002, it provides the basis for a feature-right programming environment.  It allows programmers to write console applications, web applications, and Windows applications.  No new major features are being added to .NET Framework.  Microsoft will be only adding minor feature updates, bug fixes, and security fixes.
* mono - A framework created to mirror and add features to the .NET Framework with the specific goal of being able to run on multiple operating systems, not just Windows.  It is primarily used to power Xamarin.
* Unity - A framework created for game development.
* .NET Core SDK - A new set of libraries meant to eventually replace the .NET Framework.  Like mono and Unity, it is freely available to be used by anyone, anywhere for free.

## Starting Out

To best learn C# and .NET we will be using Visual Studio (Windows) or Visual Studio for Mac.  Both are available for no cost to individuals for use in educational settings.  Both have similar features, but are two different programs.  Visual Studio for Mac, previously known as Xamarin Studio and before that monodevelop was created by the mono project to be a competitve, free IDE to be used on multiple platforms.  We will be focusing on .NET Core and will be programming using C# version 7.3.  You can use the latest version of .NET Core and of either IDE.

<<[Your First Program](cs/ch02-01.cs)

This is the simplest program you can write.  It will be described in a little bit.  First, we need to understand a few basics of programming.

## Variables

In computing, a variable is a way for you to easily to refer to something that is stored in the computer's memory.  Instead of referring to the physical address in memory, you give your piece of information a name.  In the following line of code, `int` tells the computer that this is a whole number.  `x` is our variable name.  `=` tells the computer that we want `0` to be placed in the computer's memory.  To summarize, we are telling the computer that we want the value 0 to be placed in the computer's memory and accessed in the future by the name `x`.

    int x = 0;

Variable names in C# can start with a letter or an underscore \(`_`\).  They can contain upper- and lower-case letters, numbers, and underscores.  Variable names are case-sensitive.  This means that `myVariableName` and `MyVariableName` are seen by the compiler as two different things.  There are no real guidelines as to what what case to use in your variable names or if you should use an underscore or not.  The following chart shows the various styles.  For our purposes, we will be using different styles to mean different things.  Variable names may be several hundred characters long, but in practice, it is unusual to see one over 25 characters or so.

| Camel Case | first letter is lowercase, no underscores | thisIsACamelCaseVariable |
| Pascal Case | first letter is capitalized, no underscores | ThisIsAPascalCaseVariable |
| Snake Case | lowercase with underscores separating words | example_of_snake_case |

In a variable name, it is customary to start each new word with a capital letter.  For example: `myNewCar` or `MyNewCar`.  If you are using an abbreviation longer than 2 characters, change it to use only an initial capital letter.  HTML is an abbreviation and would be treated as such: `HtmlToOutput`.

## Scalars
