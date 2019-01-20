# More Logic and Control Structures

In the previous chapter, we saw how to evaluate expressions and conditionally execute code based on those evaluations.  Here we will see some additional ways to do truth checks and introduce other ways to control which of your code is executed and in what order.

## Conditional Access Operators

Finally, there are two more equality-related operators that we will discuss.  Both check to see if something is null before trying to access a value to prevent errors.

The first is the conditional array indexer operator.  This checks to see if an array is null before trying to access an index on the array.  This operator does __not__ check to see if the index exists on the array.  It only checks to see if the array itself is null.

    string[] sa;
    string s;
    string s = sa?[0];

This code sets `s` to the value of `sa[0]` but only if `sa` is not `null`.  If `sa` is `null`, `s` will be set to `null`.  Use one of the following patterns instead of the conditional array indexer operator.

    string[] sa;
    string s = null;

    if( sa != null && sa.Length > 0)
    {
        s = sa[0];
    }

    //-----//

    s = sa == null && sa.Length > 0 ? sa[0] : null;

The conditional access operator is similar.  In its basic form, it checks to see if something is null before retrieving data from the object.  In the case of nullable value types:

    int? i = 1;
    int? j;

    j = i?.Value;
    // i equals 1

If `i` is `null`, set `j` to `null`, else set `j` to `i`'s value.  This, of course, is the same as `j = i`.  We will see in subsequent chapters the power of the conditional access operator.

## Null Coalescing Operator

This operator is often useful when dealing with nulls.  In the following example, it says, `x` if `x` is not null, else `y`.

    int? x = null;
    int? y = 5;

    int? z = x ?? y;
    // z is 5

`z` becomes the value `5` because `x` is null.  This operator does not implicitly make the result not null.

    int? x = null;
    int? y = null;
    int? z = x ?? y;
    // z is null because y is null

## Basic Switch Statement Usage

C# gives us another way to check that a piece of data is set to a particular value and to perform operations based on that evaluation.  The switch statement can sometimes provide a more readable representation of conditional logic.

Basic usage of the `switch` statement.

    int i = 5;
    string s;

    switch( i )
    {
        case 1:
            s = "one";
            break;
        case 2:
            s = "two";
            break;
        default:
            s = "a big number";
            break;
    }

 This is functionally equivalent to:

    if( i == 1 )
        s = "one";
    else if ( i == 2 )
        s = "two";
    else 
        s = "a big number;

When doing logic that only relies on one variable, the `switch` statement may be a better solution, but that is up to you.

Let's break down that we see.  First is the `switch` keyword followed by the variable that you are checking.  The `switch` statement operates on literal values such as the value types and strings.

    switch( i )

Next we place our conditions in a code block with braces `{}`.

Each check is specified the the `case` keyword followed by a literal value, such as `1` or `"my string"`.  This line is terminated by a colon `:`.

    case 1:

Next, we optionally add statements that can include variable assignment and executing code.

    s = "one";

Our optional statements are followed by the keyword `break`.  This tells the computer that it should stop executing code in the `switch` statement and exit.  There are other ways to do this which we will discuss in subsequent chapters.  If you forget to include a break, you will get a compiler error telling you that your code execution will "fall through".

    break;

Finally, for now, we specify what to do if the code matches none of the conditions.  This is often empty, but may contain statements.

    default:
        break;

### Combining `case` Statements

If you wish to call the same statements for more than one `case`, you can combine them by stacking them up.  The following two examples are functionally equivalent.

    int i = 5;
    string s;

    switch( i )
    {
        case 1:
        case 2:
            s = "one or two";
            break;
        case 2:
            s = "three";
            break;
        default:
            s = "a big number";
            break;
    }

    //-----//

    if( i == 1 || i == 2 )
        s = "one or two";
    else if ( i == 3 )
        s = "three";
    else 
        s = "a big number;

## The Dreaded `goto` Statement

> _"The __go to__ statement should be abolished from all "higher level" programming languages."_
>
> -Edsger Dijkstra \(1968\)

C# allows programmers to name a block of code with something called a _label_.  We can use the `goto` statement to change the flow of the code to jump over code that follows or to jump back and execute code again.  You do this by saying, `goto label_name;`.   There are always better ways of controlling the flow of your code.  Dijkstra, a prominent Dutch computer scientist, was correct more than 50 years ago in stating that this ends in poor programming practices.  This author has only ever used the C# `goto` statement once since 2002 and then its usage was probably incorrect. 

## Iteration and Loops

Iteration is the processing of reading each item in a data structure, such as an array and acting on that data.  In later chapters, we will see how this applies to other types of data structures.  We call the data structures that contain multiple pieces of data, collections.  An array is one such of collection.  C# has built-in ways of handling this data.

We will also be looking at a different C# feature that allows us to run the same code, in a loop, until a condition is satisfied.

### `do-while`, `while-do`

The two forms of the while statement run a block of code until a condition that is evaluated on each loop is false.

    int currentLoopCount = 0;
    while( currentLoopCount < 5 )
    {
        currentLoopCount++;
    }
    // the value of currentLoopCount is 5

In pseudo-code:

    currentLoopCount equals 1.
    while currentLoopCount is less than 5
    increment currentLoopCount by 1.

This runs the code in side the block, `currentLoopCount++` until `currentLoopCount` equals 5.

The `do`-`while` construct does just about the same thing.  The difference is that the block of code associated with it runs _before_ the evaluation.

    int currentLoopCount = 0;
    do
    {
        currentLoopCount++;
    }
    while (currentLoopCount < 5);
    // the value of currentLoopCount is 5

In our simple example, the result is the same, but there are time when you might prefer to execute the code block before performing your truth evaluation.

Your evaluation expression can be as complex as any of those used in the examples used with `if`.

## `break` and `continue`

There are five ways to end a loop early.  Two of them will be shown here and the other three later.  You can use the `break` keyword in your code.  This will immediately exit the loop by skipping any remaining code and continue code execution at the first line after the block.  The `continue` keyword can be used to stop execution in your code and continue on to the next evaluation, then conditionally, re-enter the block.

    while( true )
    {
        A();
        B();
        if( x == y )
            break;
        C();
    }
    E();

In this example, if `x` is not equal to `y`, the code executes `A()`, `B()`, `C()`, until our evaluation condition changes \(in this case it doesn't\) or until `x` equals `y`.

If `x` equals `y`, we break out of the loop and continue on to the next statement.  In this example, `A()`, `B()`, and `E()` are executed.  `C()` is skipped because of the `break` statement.

    int i = 1;
    while( ++i <= 1000 )
    {
        if( i % 2 == 0 )
            continue;
        Say("I is odd");
    }

This example brings together many of the concepts we have learned thus far.  Let's break it down.

1. Create an integer, `i`, and assign it the value `1`.
2. While...
3. --- the result of `i = i + 1`
4. --- is less than or equal to 1000
5. ------ if `i` is even, continue code execution at step #3...
6. ------ else execute the arbitrary piece of code, `Say("I is odd");`

We learned about the auto pre-increment operator.  It adds one to the variable associated with it _then_ returns its value to be evaluated.  In our example, the first time through the loop, the evaluation expression is:

    while( 2 <= 1000 )

Now, `i % 2 == 0` does the following.  First, evaluate the modulo operator against `i` and `2`.  This means, find the remainder of the division operation of `i` divided by `2`.  This result will be `0` if `i` is evenly divisible by `2`.  This is a very common pattern to check to see if a number is even.  To check if the number is odd, just negate the check:

    i % 2 != 0

When the result of our evaluation is `0`, meaning that `i` is even, `continue` on to the next evaluation loop evaluation, skipping the `Say("I is odd");` line.

Two things.  First, if loops are nested, `continue` moves execution to the loop that is closest to our code.  `break` breaks out of the closest loop and returns control to the enclosing loop.  Please note the comments

    while( true ) // #1
    {
        while( true ) // #2
        {
            SomeCode();
            if( x == y )
                continue; // go back to #2 and re-evaluate
            SomeMoreCode(); // if x == y, this line skipped
        }
    }

Break works in a similar way with nested loops.

    while( true ) // #1
    {
        while( true ) // #2
        {
            SomeCode();
            if( x == y )
                break; // exit this loop and continue at #3
            SomeMoreCode(); // if x == y, this line skipped
        }
        SomeOtherCode(); // #3
    }

Second, there are three more ways to exit a loop.  We already talked about the `goto` statement.  We will cover the  `return` statement when we talk about methods and the `throw` statement when we talk about exceptions.

#### Tips

Here are some tips while using `do`/`while`.

* Only use it for short-lived operations.
* Evaluation expressions do use the processor to perform their operations.  Running a _tight_ loop, one that is continually evaluated many times in succession can bog down system performance.
* Long running expressions should be performed on a separate thread \(more on that later\).
* While it can be used to run operations on a timer, say, execute something every 5 seconds, there are better ways of doing so which we will discuss later.

## `for`

The `for` statement is used for many things such as running an operation on each item in an array or anything else that needs to run a specific number of times.  There are three parts to a `for` statement.  The initializer, the evaluation expression, and the numeric operation.

`for` is one of the basic flow control structures for iterating through an array.  In its most basic form, we can take an array and do something with each element of that array.  The following example prints each array element to the command line.  This involves checking the array length and pulling out its values by index which we learned about earlier.

    string[] sa = { "a", "b", "c", "d" };
    for( int i = 0; i < sa.Length; i++ )
        Console.WriteLine( sa[i] );

First we create an array of length `4` and assign values to those 4 array elements.  Note that the `for` statement, like the `if` statement does not require explicit braces `{}` since we are only executing one statement within the loop.  Let's break down the parts of the `for` statement.

\#1. Initializer.  This creates an `int` and sets it to `0` when we first enter the loop.  Generally, people use `int` here.

    int i = 0

\#2. Evaluation expression.  While the return value of this condition is `true`, keep looping.  This may be any type of evaluation, as long as it returns `bool`.

    i < sa.Length

\#3. Numeric operation.  This increments `i` by `1` and the _end_ of each loop, after the statements in your block are executed.  In a `for` loop, the pre- and post-increment operators are interchangeable.  Most of the time, you will find some type of numeric operation happens here.

    i++;
    // or
    ++i;

The code in the block, or in this case the single statement, is run if the evaluation expression is `true`.  Note that we are retrieving the value of our array element by index by using the variable, `i` as the index.

While your variable name can have any legal name, it is customary to use `i` as your looping variable.  For nested `for` loops, `j` is often used, followed by `k`, etc.

C# also allows us to create multiple variables to use while looping.  The following shows how you may use two or more variables in a `for` statement.

    for (int i = 0, j = 0; i < sa.Length; i++, j++)
    {
        Console.WriteLine(sa[i]);
    }

You may also create an infinite running `for` loop which is akin to `while(true)`.

    for( ; ; ) { DoSomething() };

You can control a `for` loop the same ways that you can control a `while` loop by using `continue`, `break`, etc.  One thing to note about the `for` loop, when you call `continue`, your numeric expression will be called, generally an auto-increment operator. 

    for( int i = 0; i < sa.Length; i++ )
    {
        if( i % 2 == 0)
            continue;
        Console.WriteLine( sa[i] );
    }

We can also move backwards through an array.

    for( int i = sa.Length - 1; i >= 0; i-- )
    {
        Console.WriteLine(sa[i]);
    }

## Variable Scoping: The Basics

Remember how we learned that loops can be nested?  Well, there is something special about that variable that you declare inside the `for` statement: it can only be used in the `for` statement and its accompanying code block.

    for( int i = 0; i < sa.Length; i++ )
    {
        if( i % 2 == 0)
            continue;
    }
    i++; // ERROR, i is no longer accessible

Variables in C# are scoped to their current block or any enclosing code blocks.  In this example, we declare our array and boolean variables outside of the `for` block and use them within the `for` loop.  You will also see that we can set the value of `foundAMatch` within the `for` loop.  Its new value is available outside of the `for` loop because it was declared outside of the loop.

    string[] sa = { "a", "b", "c", "d" };
    bool foundAMatch = false;
    for( int i = 0; i < sa.Length; i++ )
    {
        if( sa[i] == "c" )
        {
            foundAMatch = true;
            break;
        }
    }
    if( foundAMatch )
    {
        Console.WriteLine("Match found!");
    }

Working off of this example, if we try to redeclare a variable that we have used, we will get a compiler error.

    if( foundAMatch )
    {
        bool foundAMatch = false; // ERROR
        Console.WriteLine("Match found!");
    }

If you want to change the value of the variable, just set it without the data type.

    if( foundAMatch )
    {
        foundAMatch = false; // GOOD
        Console.WriteLine("Match found!");
    }

## foreach

Another way to loop through an array or most collections of data is to use the `foreach` loop as such:

    string[] sa = { "a", "b", "c", "d" };
    foreach( string s in sa )
    {
        Console.WriteLine( s );
    }

The variable `s` is assigned the value in the current array index, which loops from index `0` to the end.  The `foreach` statement takes out the possible errors of tracking looping variables such as in the `for` statement.  There is no array index to track.  `foreach` automatically pulls out each value in the array, in this case.

`foreach` statements, like `for` statements are associated with a block of code or single statement listed after the `foreach` statement.  This is exactly as we have seen before.

## The `var` Keyword

Oftentimes we want the compiler to do some of the work for us.  Why can't it figure out that each array element of a `string[]` is a string?  Well, it can.  C# gives us the `var` keyword for this very purpose.  It is used in places where there the compiler can implicitly figure out what the data type should be.

    string[] sa = { "a", "b", "c", "d" };
    foreach( var s in sa )
    {
        Console.WriteLine( s );
    }

This example works exactly as it did when using the explicitly stated `string` variable.  Here are a few other examples of the `var` keyword.  The first one fails because the compiler does not know that we intend to declare the variable as a `string[]`.  The next line fixes that.

    var sa2 = { "a", "b", "c", "d" }; // ERROR
    var sa2 = new string[] { "a", "b", "c", "d" }; // GOOD

In these two following examples, C# infers the first as being of type `int`, while the second is `string`.

    var myInt = 123;
    var myString = "my string";

### Conclusion

Loops provide a powerful way of processing both small and large amounts of data.  We also learned some basics of variable scoping and the use of the `var` keyword.  In the next chapter, we will shift gears to object-oriented programming concepts.  It is there that we will see C#'s true power.
