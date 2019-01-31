# Some Definitions

There are many terms that the computing world uses.  These may be classified as jargon/argot. They are important in the expression of ideas that pertain to computing and programming.  Many will be described within this text, but first let us define some basic terms.

* __modern computer__ - usually, a device that consists of memory, a processor\(s\), and storage that uses an operating system to provide services for the purpose of executing computer programs.
* __software__ - the stuff that makes a computer useful.
* __CPU/processor__ - a device that is responsible for performing computations and operations as directed by software.
* __processor platform__ - a processor design that defines specific instruction sets.  Software that runs on one platform does not generally run on another platform without making changes to it \(see also: scripting language and JIT\).  Current examples include 32-bit Intel \(x86\), 64-bit AMD/Intel \(x86-64\), MIPS, POWER, SPARC, etc. 
* __RAM__ - a type of fast memory that stores data and computer programs that are being run.  It is _volatile_, meaning that it is not a place to permanently store data.  It is cleared when a computer is restarted.
* __hard disk__ - a non-volatile _magnetic storage_ for permanently storing data.
* __SSD__ - **s**olid **s**tate **d**isk.  A form of non-volatile memory that doesn't have moving parts as in a hard disk.
* __NVMe__ - a type of SSD that has a faster interface to the computer.
* __programming language__ - a syntax and grammar that provides a way for a computer programmer to create software.  A programming language gives programmers a way to write software that does not require an intimate knowledge of the underlying hardware architecture.
* __compiler__ - a special program that translates a programming language into something that can be executed by the computer or a runtime.
* __runtime__ - usually refers to a way to run code without having to recompile it.
* __scripting language__ - a programming language that is not compiled until it is executed.  Notable examples include python, perl5, etc.
* __byte code/intermediate language__ - notably Java and .NET code are compiled into code that is executed by a runtime environment.
* __GUI__ - a **g**raphical **u**ser **i**nterface.  Software that allows the use of a computer screen and a pointing device \(mouse, finger, etc.\) to interact with software.
* __IDE__ - an **i**ntegrated **d**evelopment **e**nvironment.  GUI software that allows the programmer to more easily create software programs.  Notable examples include Visual Studio and Eclipse.
* __API__ - an **a**pplication **p**rogramming **i**nterface.  Software that is created for other programmers to use.  APIs often provide code that performs commonly used tasks.  It provides ways to reuse code in order to not have to implement basic concepts for each program written.  Examples include the C Standard Library and the .NET Framework.
* __framework__ - in this book, a general term to describe the set of Base Class Libraries and .NET Standard APIs implemented in the .NET Framework, .Net Core, Mono, Xamarin, and Unity environments, among others.
* __.NET__ - \(pronounced in the US as "dot net"\).  An ecosystem that compromises multiple languages \(C#, VB.NET, F#, etc.\), multiple compilers \(such as Roslyn for C#\), an intermediate language specification \(CIL\), a common type system, a runtime \(such as RyuJIT\), base class libraries, and a comprehensive API to create computer programs.
* __C#__ - \(pronounced in the US as "see sharp"\).  A general purpose programming language for .NET.
* __cross-platform__ - software that has the ability to run on multiple processor platforms and/or operating system platforms.  Software must be recompiled if it is to run on another platform, except in the case of certain types of byte code that are run by a runtime environment such as .NET Core and Java.
* __whitespace__ - The following characters all all considered to be whitespace: spaces, tabs, and newlines \(what you get when you press the _ENTER_ key\).

### Symbols Used in This Book

| **\_** | underscore |
| **\*** | asterisk _or_ star |
| **\!** | exclamation mark _or_ bang |
| **$** | dollar sign |
| **^** | caret |
| **\[\]** | left/right bracket |
| **\<\>** | left/right angle bracket _or_ greater than/less than |
| **{}** | left/right brace _or_ curly brackets |
| **\(\)** | left/right parenthesis.  Plural form is parentheses |
| **-** | dash |
| **\|** | pipe |
| **"** | double-quote |
| **'** | single-quote |
| **#** | pound _or_ hash |
| **;** | semicolon |
| **.** | dot |
| **\\** | backslash |
| **/** | slash _or_ forward slash |

### System Requirements

An IDE is not required, but greatly helps and cuts down on development time substantially.  This author recommends Microsoft Visual Studio 2019 or Visual Studio for Mac 2019.  You should have at least 8GB of RAM and about 10GB of available disk space.
