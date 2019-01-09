# Milestones

> _"It is possible to invent a single machine which can be used to compute any computable sequence."_
> 
> -Alan Turing \(1936\)

The history of computing starts a little over 80 years ago.  Mathematicians and theorists were speculating about the possibility to using electrical devices to solve problems in the mid 1930s.  By the end of that decade, computers were starting to be built.  These machines cost millions of dollars to construct (in today's money) and took up the space of several large rooms.  These machines could not do much more than solve basic mathematical problems.

The early computers were mostly used to perform mathematical calculations for governments by calculating bomb trajectories and decrypting enemy communications.  In the 1950s, computers slowly moved into the mainstream with their adoption by businesses for storing and processing data.  The 1960s brought about the rise of the operating system and the use of high-level computer languages.  Multi-user systems also started to become prevalent.  The 1970s laid the foundation for networking computers together and allowing many users to work on the same computer systems.  The 1980s brought computers into the home, while the 1990s brought us together with the Internet.  Let's see what major advancements brought us here today.

## Early Systems

The first computers were single purpose machines.  They were each used for one purpose at a time.  For example, these computers could only calculate simple mathematical problems.  In order to change the type of calculation each performed, one would have to physically rewire the machine to enable it to perform another function.  These machines could perform tens of operations per second.  Today's smartphones are able to perform billions of operations per second.

The next major breakthrough was to create a general purpose computer that could be used to solve more than one problem.  The idea was to create a machine that could be programmed by means other than physically changing the circuitry.  The first computer programs were written in machine language, that is, the language that a computer can understand.  This is represented by ones and zeroes.  Each computer had its own flavor of machine language and method of creating the input.

## The Next Generation

The next generation of computers could be programmed by using switches on their consoles.  Computers at the time did not have monitors or even keyboards.  The only way to interact with the earliest computers was to flip switches on a big board.  Arrays of light bulbs were used to indicate the output from a program.  

It wasn't long until assembly languages overtook raw machine languages.  This happened somewhere in the early 1950s.  Instead of using ones and zeroes, the programmer would use a more human-friendly way creating a program.  These programs, like ones in machine language, gave instructions to the computer about how to perform a computation.  Each line of code instructs the computer's processor on how to perform a calculation, for instance.  Even modern processors are not able to perform advanced tasks on their own.  It is up to the software to instruct the processor how to operate on data.

To alleviate the problem of not being able to save programs, punch cards were used as a type of computer input.  A punch card is a stiff piece of paper divided into rows and columns.  Computer instructions were created by using combinations of holes created on the cards.  Computer operators would create punch cards on key punch machines, which were large keyboards that punched holes into these cards.  Thousands of cards would be created to make a simple program.

The next evolution was the use of Teletype machines to create input for computer systems.  The early machines were large typewriters that output paper tape.  This paper was about one inch wide.  The Teletype machine would make holes in the paper that could be read into a computer.  Later, Teletype machines would be directly hooked up to computers to allow direct input into a computer system.  This was only able after the ability of computer systems to be used interactively.

Assembly languages are used to this day to perform low-level operations to interact with hardware.  They are mainly seen in operating system kernels and hardware drivers (more on this later).

Assembly by itself cannot be run by the computer.  There is a program called an assembler that converts the assembly language to machine language.  In the end, all software is somehow converted down to machine language (ones and zeroes) in order to be run.  Assembly is a language that is unique to each computer platform.  Assembly that was written for the earliest computers will not run on a modern computer.  Programmers of the day were specialists in the particular computer system they were programming.  Even different computer models from the same company generally had different dialects of assembly language until the 1960s.

As computers became more powerful and had more memory available to them, higher level languages were developed.  These languages did not specify each instruction that the computer had to perform.  Instead of requiring 10 or more commands to add two numbers together, they only required one or two.  Of these early compiled languages, COBOL and FORTRAN, which have their origins in the late 1950s, are still in use today.

The United States Internal Revenue Service \(IRS\) still operates their Individual Master File system on early 1960s era assembly.  20 million lines of assembly are required for this system to maintain tax data on individual tax payers in the United States.  If written in a modern object-oriented language, that code could be as little as 1 to 2 million lines.

To run this antiquated code, it must be run in an emulation mode.  This means that the modern computer is unable to directly understand the type of instructions that are sent by the program.  When running the program, it must take the original machine instructions and translate them to ones that a modern computer processor can understand.

Assembly's use today is on the decline.  With few exceptions, it is not prevalent programs written for business.  If anything, small pieces of assembly are used in larger programs to take advantage of certain features of the target processor platforms.  Assembly remains in the programming of operating systems and hardware device drivers.

{lang="asm"}
<<[Hello, Word in IBM s/370 Assembly](cs/ch01-helloWorld-370.asm)

{lang="nasm"}
<<[Hello, World in Intel's i386 assembly](cs/ch01-helloWorld-i386.asm)

## Higher Level Languages

A computer cannot understand a programming language as it is written.  It must first be sent through a program called a compiler.  The compiler translates the code to machine language, which allows it to be run by the computer.  These languages were easier to write than assembly.  They were also less error prone and helped to increase development times.  The first compiled \(not assembled\) language was IBM's FORTRAN, which was first developed between 1954-1957.

The languages COBOL and FORTRAN were adopted by many different companies for the use on many different machine architectures.  This may seem to be a good thing to have languages that can run on multiple types of machines.  Unfortunately, the wide variety of operating and hardware systems had their own dialects of these languages.  One example this author saw of a COBOL implementation was tightly coupled with the data types used by a specific system.  No other systems would be able to interact with code created by this implementation.

While COBOL and FORTRAN can still be found in use today, several other programming languages are now considered to be "historical."  They are important for their contributions to computer science and advancing the art and science of programming.  Other notable early languages whose influences are seen today include LISP, ALGOL, and BCPL.

Today's compilers generally output one of two things.  First, they can create machine executable code.  Secondly, they an also something called byte code.  Byte code is not machine language.  It is an intermediate language that must later be converted to machine language to actually run.  Byte code is meant to be run by a just-in-time compiler such as the Java Virtual Machine \(JVM\) or one of .NET's runtime. 

## What's in an Operating System?

Prior to 1955, operating systems did not exist.  All programming was targeted at manipulating the physical hardware directly.  The first couple of operating systems were written by customers of computer companies such as GM.  It wasn't until 1962 that IBM and Burroughs released their first operating systems to customers.

Today's operating system such as Linux, UNIX, macOS, and Windows run a special program called a kernel.  Kernels provide services that are used to interact with a computer's hardware, including the processor and memory.  A kernel defines how information input/output \(I/O\) works in a system.  It is also tasked with running programs and allowing multiple programs to run at the same time while sharing a system's resources.  A kernel also contains a basic set of drivers that allow users to interact with the various components of a computer such as the hard drive or SSD.  Custom device drivers to control things like graphics cards may be included in the kernel or loaded separately through software that is custom created by the hardware manufacturers.

A kernel is started when a computer is booted and remains running until it is shut down.  Most modern computer systems follow this boot sequence.  This is a simplification of the process.  It is shown to give a general idea of how it works.

1. Turn on the computer
2. Code called firmware is started.  It provides basic access to I/O devices and provides a way to start the operating system.  It often points to a special location on a disk.
3. The special location on the disk starts a boot loader.  This is used to tell the system where to find the kernel that is to be loaded.  The boot loader usually allows you to choose which kernel to load or how to load the kernel.  Most kernels may be loaded in special modes, such as single user mode or a diagnostics mode.
4. The kernel is started.  It is in charge of loading device drivers, network interfaces, services, and the user interface, if one is used.

Operating systems also include file systems.  A file system is a method of arranging and storing files on a storage device such as a hard disk or SSD drive.  An operating system also provides utilities for managing files, users, and programs.

Finally, operating systems optionally provide a graphical user interface \(GUI\).  GUIs allow users to interact with a system in a visual way.  Common examples of GUIs include Microsoft's Windows interface and macOS's Quartz interface.  Without a GUI, systems are only accessible by a text-based terminal.

The late 1960s brought about operating systems that could run more than one program at a time.  To that point, is was impossible due to slow hardware and limited amounts of memory.  Most modern operating systems run dozens of programs at a time in order to provide basic services.

A> ### What is a server?
A>
A> The term server will be used throughout this book.  Simply put, a server is a bigger, faster version of a personal computer.  They typically have the following:
A>
A> * Faster, more advanced processors \(such as Intel Xeon processors\)
A> * More processors and cores \(anywhere from 1 to 10 million\)
A> * More memory \(several gigabytes up to petabytes\)
A> * Faster and larger permanent storage \(disk, SSD, NVMe\)
A> * Specialized chips \(such as NVIDIA's Tesla V100 Tensor Core\)
A> * Faster networking capabilities \(such as 40 gigabits per second\)

## C Follows B and So Goes the World

The UNIX operating system was developed starting in 1969.  It was implemented in assembly and the B programming language which was created for it.  By 1973, UNIX had been rewritten in the newly developed C language and announced to the public.  It was at first used by academic institutions.  UNIX's main selling-point was that it provided an environment that could be run on minimal hardware and could have multiple logged into it and executing multiple programs at one time.

C is a portable, high level, general purpose language.  C code can be run on any system that has a C compiler.  C has a minimal runtime, which means that it is capable of being run on systems with very limited resources.  Its code compiles into relatively executable files when compared to that of other languages.  C also provides a comprehensive set of data types.  C environments include a standard library which provides pre-written code for basic I/O operations, memory management, mathematical operations, text \(string\) handling, and operating system interaction.

C is a compiled language.  Code must be recompiled to work on different operating systems and different hardware architectures.  For example, C compiler output files \(binaries\) that are compiled on a Windows computer cannot run on macOS or Linux without being recompiled.

While all this sounds wonderful, C does come with some inherent disadvantages.  First, C's standard library is generally not considered to be portable.  There are C separate standard libraries for nearly every operating system family.  The C standard library is a globally defined standard.  This means that most implementations of it adhere to the standard, which makes C code written to the standard run on most systems.

C does not provide automatic memory management.  This means that when you use a piece of memory, you must clear that piece of memory when your program is done using it.  As automatic memory management adds a large amount of overhead to a runtime, it was not feasible for early computers running UNIX.  This has had the unfortunate side-effect of C programs being easily open to hacking due to issues such as buffer overflows and under-runs.

### Why is C So Important?

Those reading this book electronically are doing so on an operating system with a kernel that was primarily written in C.  Every version of the Microsoft Windows kernel has been primarily written in C, although the kernels do contain a fair amount of assembly and probably some C++.  The macOS kernel, Darwin, is about 77% C, 9.6% C++, 5.5% Objective-C, and 1.4% assembly.  Linux is 96.4% C, 1.4% C++, and 1.3% assembly.  For those with an Amazon Kindle e-reader, you are running a Linux kernel, as are those on an Android tablet or phone.  iOS devices such as the iPhone and iPad are running a derivative of the Darwin kernel.

There are exceptions to every rule.  Many embedded systems do not run the mainstream operating systems listed above.  These systems include networking routers \(a few run Linux\), automobile computers, and toasters.  In business applications, four of the five IBM mainframe operating systems are probably not implemented in C.  As these are proprietary operating systems, it is really not publicly known.  These operating systems include z/VM, z/OS, Z/TPF, and z/VSE.  IBM's Linux for Z is of course primarily a product of C.

All of the operating systems listed that are primarily written in C support running programs that were written in other languages.  They all support languages such as C++, perl5, python, JavaScript, Java, etc.  Most also support Rust, Go, and C#.  Objective-C can be compiled on all of these systems, but its core libraries are proprietary to Apple's macOS, iOS, watchOS, and tvOS.

### Why Isn't This a Book about C?

C has its place in computing.  It is an extremely useful language to learn.  It does not, however have the same uses as C#.  C# for example is excellent at web development and database access.  C# is also very good at creating user interfaces for Windows.  Most Windows UIs are written in C++ or C#.  C# also has wide adoption in business applications and may also be used for cross-platform development on Linux, iOS, and Android.

### Introducing C#

> _"C# is intended to be a simple, modern, general-purpose, object-oriented programming language."_
>
> -Standard ECMA-334: C# Language Specification

Many languages and UNIX/Linux tools display C-like qualities.  Many of them use the same syntax as C including control structures, variable assignment, and built-in mathematical operators.  These languages include two early object-oriented languages, Objective-C and C++.  C++ is typically used to create large scale server programs including relational databases and web servers, user interfaces, and just about anything else.  The choice of C versus C++ is largely a personal choice of object-oriented vs. non-object-oriented.  On modern systems, their performance and memory footprints are similar, with C++ having more overhead due to its advanced object-oriented features.  Objective-C is primarily used development for applications on Apple's various platforms.

Other notable C-like languages include Perl, JavaScript, Java, Python, Go, and Rust.  C# was created as Microsoft's response to the popularity of Sun Microsystem's Java.  It was also created to be a modern "object-oriented first" language to replace Microsoft's aging, yet popular Visual Basic 6.

For our purposes there are three types of languages.  There are those that compile to machine code.  Those that are partially compiled and run in engines called virtual machines.  The third type are the interpreted languages.  These languages are not compiled until they are run.  Advantages to virtual machine type languages include portability of compiled programs, security concerns, and automatic memory management.

## Conclusion

In a little over 80 years, we have gone from hard-wired electromechanical devices that could only perform basic mathematical calculations to computers that will soon be able to program themselves.  Compared to a computer of relative performance, the phone in my pocket would have cost $125,000 and would have weighted 150 pounds in the year 2000.  This rate progress is unparalleled in any other field.  It continues to be a fascinating time in the evolution of programming.
