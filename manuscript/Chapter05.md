# Logic and Control Structures

In this chapter we will be looking at code elements called flow control structures.  Code is generally executed from top to bottom.  Control structures disrupt the flow of execution in order to perform different operations.  We will also be learning about basic boolean logic.

    If my bank account balance less than one dollar
    then I must transfer money from savings.

This is an example of pseudocode.  It is a way to describe what a program or piece of code needs to do in plain English.  Pseudocode has no formal syntax or grammar.  It simply a way of getting across a concept without writing code.  It is extremely useful in the case of solving logic problems.  To express the above problem in C#, we use logic.

    decimal checkingBalance = 0.05m;
    decimal savingsBalance = 15.32m;

    if ( checkingBalance < 1m )
    {
        checkingBalance += savingsBalance;
        savingsBalance = 0;
    }

## Boolean Logic _or_ Black & White

In life, not everything is black and white.  There are often many shades of grey in between something being totally true and totally false.  We use non-specific words to describe things in life all of the time.

* The sky is beautiful.
* The sky is blue.
* I might be ready to try skydiving.
* Sometimes it is good to smile.
* I broke the law to save someone's life.

We should leave this kind of logic to philosophers.  The concept of fuzzy logic in computer science is interesting.  It states that instead of something being true or false \(1 or 0\), the truth often lies between 0 and 1.  Machine learning is the next generation of trying to get computers to think in boolean terms.

Most of the time we will be checking to see if something is true or false and only true or false.  If you run into a situation where the question you are trying to answer is unclear, you have to break down the problem and define what true/false really mean.  For example, you are programming a personal voice assistant that answers the question, is it cold outside.  Using pseudo code, we can define the word cold.

    if the outside temperature is between 10 degrees F and 42 degrees F
    then it is cold
    else if it the outside temperature is less than 10 degrees F
    then it is frigid
    else if the outside temperature is greater than 42 degrees F
    then it is warm
    else it is hot

In C#, we have several ways to checking to see if something is true.  We primarily do this by using the following operators.

| operator | description    |
|----------|----------------|
| == | is equal to |
| != | is not equal to |
| < | is less than | 
| > | is greater than |
| <= | is less than or equal to |
| >= | is greater than or equal to |

## `if` Statements

We use the `if`, `else if`, and `else` keywords to check for truth.  Often we want to perform more than one operation after checking to see if something is true.  To do this, we enclose the statements in braces `{}`.  Braces define a _block_ of code.  In our `if` statement, we surround the truth check \(evaluation expression\) with parentheses.  The result of the operation in the parentheses but evaluate to a boolean value, that is, true or false.  We store `true` and `false` values in the C# type `bool` or CLR type `System.Boolean`.  C# has built-in keywords, aptly named, `true` and `false`.

    if ( true )
    {
        DoSomething();
    }

We can add to this by doing something if the evaluation expression is false.  You can optionally combine this with another evaluation expression.

    int i = 2;
    if( i > 3 )
    {
        Do1();
    }
    else if ( i < 2 )
    {
        Do2();
    }
    else if ( i > 10 )
    {
        Do4();
    }
    else
    {
        Do3();
    }

In pseudo code:

    if i is greater than 3 then
    run Do1()
    else if i is less than 2 then
    run Do2()
    else if i is greater than 10
    run Do4()
    else run Do3()

You can compose these statements in the following order.

1. `if` always comes first;
2. It can optionally be followed by an `else if` or an `else.
3. Multiple `else if` statements may be chained together.
4. `else` is optional and always comes at the end.

Braces are optional after an `if`.  Only the first statement after the `if` is considered to be the "then" part of the if.  This is called a bare statement.  The following two examples are equivalent.

    if( i > 10 )
        Do1();
    Do2();

    //-----//

    if( i > 10)
    {
        Do1();
    }
    Do2();

`Do1()` is only called if `i` is greater than `10`.  If using the version without the braces, you should always indent the following line to show that it belongs to, in this case, the `if` statement.  If you have a complex statement to run after the `if`, you should use a code block \(braces\) for better readability of your code.
   
Blocks of code, statements between braces `{}`, may be nested.

    if( i > 1 )
    {
        if( i != 2 )
        {
            Say("I is NOT 2");
        }
        else
        {
            Say("I is 2);
        }
    }

The `if( i != 2 )` expression is only evaluated if `i > 1` is true.

One way of stating this in pseudo code is:

    if i is greater then 1 and i is not 2
    then Say("I is NOT 2").
    if i is greater than 1 and i is 2
    then Say("I is 2") 

One final note, a code block is not required to contain any statements.

## Short-circuit Operators

What if you need to check two or more things in one `if` statement?  C# provides two short-circuit operators.  These operators are evaluated from left to right.  When a false value is returned, the remaining expressions are not evaluated.

| operator | description |
|----------|-------------|
| \|\| | logical or operator |
| && | logical and operator |

    if( a == b && b == c && d == e )
    {
        DoSomething();
    }

In order for `DoSomething()` to be executed, all three expressions must evaluate to true.  It executes in the following order.

1. If `a` equals `b`, then continue on to the next evaluation.  If `a == b` evaluates to `false`, code execution continues to the first statement after the `if` block.
2. If `b` equals `c`, then continue on to the next evaluation.  If `b == c` evaluates to `false`, code execution continues to the first statement after the `if` block.
3. If `d` equals `e`, then execute the following code block.  If `d == e` evaluates to `false`, code execution continues to the first statement after the `if` block.

There are two main reasons that we don't evaluate all operators all of the time.  First, it is a performance optimization.  Why perform all of those evaluations if the first results in `false`.  Second, we often need to check a value in the first expression that could result in an error in the next one.  Let's take the following example.  We will cover this in-depth in a minute.

    int?[] myArray = int? [1, 2, 3, null];

    if( myArray != null && myArray.Length > 1 && myArray[0].HasValue )
    {
        DoSomething(myArray[0].Value);
    }

These types of checks are extremely common.  First we check to see if `myArray` has had a value assigned to it.  Second we need to see if there is an array element `0`.  Next, we check the nullable `int` to see if it is null or not.  If `myArray` was `null`, the second expression would fail with a `NullReferenceException`.

With the `||` operator, the first expression that is separated by `||` to return `true` satisfies the condition and the rest are not evaluated.

    if( a == b || b == c || c == d ) { }

In this example, if `a` is equal to `b`, it evaluates to `true`, the rest of the statement will not be evaluated.  Evaluation in the example proceeds from left to right until at least one of the statements evaluates to true.  If a `false` is found, evaluation continues onto the next expression, continuing until the first `true` is found.

### Array Lengths

The length of an array is the count of items in the array.  It is not equal to the index of the last element in the array.

    int[] ia = new int[] {1,2,3,4,5};

Remember, the first element in the array has in index of `0` and the last index is `4`.  The length of the array is `5`, since it has 5 elements.

To check the length of the array, we use the following syntax.

    if(ia.Length == 5)
    {
        DoSomething(ia[4]);
    }

This code pulls the 5th value, index `4`, from the array and does something with it. We make sure that index `4` exists before trying to retrieve the value.  If we try to pull an index that does not exist, we get an error about our index being "outside the bounds of the array."

### Nullable Value Types

There are two ways to check to see if a nullable value type has a value.  We can check the `HasValue` property on the object or we can compare it against `null`.  They are both used by frequently used by developers.  No one way is better than the other.  The following two examples are equivalent.

    int? i = 4;
    if( i != null )
    {
        DoSomething(i);
    }

    //-----//

    int? i = 4;
    if( i.HasValue )
    {
        DoSomething(i);
    }

Now, to get the value out of a nullable value type, we have to use the following.

    int? i = 4;
    int j = i.Value;

You do not have to use the `Value` property to compare two value types.  The following is valid. 

    int? i = 1;
    int j = 4;
    if( j > 4 ) { }

A> ### Magic Numbers
A>
A> While it appears that nullable value types are a bit more work to use due to need to constantly check to see if they are null, they are a vast improvement over what programers used to have to do.  We would use things called magic numbers.  To know if a number was not set, programmers would often set an `int` to things like `0`, `-1`, `Int32.MaxValue`, or `Int32.MinValue`.  These were always bad practices, but they continue to permeate code.  Unfortunately, there was no better way to signify that an number was not set or invalid.  Nullable value types fix that by allowing numbers and such to be able to set to null.

### Negatives and Positives

There are two common patterns that are seen when chaining multiple evaluation expressions.  The first involves checking to see if everything is true; the other involves checking to see if everything is false.  When checking negative conditions, you separate them with `&&`.  When checking positive conditions, you separate them with `||`.  These are not hard and fast rules, but they are common patterns that you will see.

    if x is not 1 and x is not 2
    and x is not 3 and y is not 4

    if( x != 1 && x != 2 && x != 3 && y != 4 ) { }

The second case.

    if x is 1 or x is 2 or x is 3

    if( x == 1 || x == 2 || x == 3 ) { }

### Parentheses

Multiple conditional expressions may be combined with parentheses.  These help us to perform multiple checks at a time.  The values within the inner-most parentheses are evaluated first.  It is a very similar evaluation scheme that is used in mathematics, except that the operator short-circuiting operators are still in effect.

    if( x == 1 && ( y == 1 || z == 3 ) ) { }

For this to evaluate to true:

1. `x` must be equal to `1` _and_
2. `y` must equal 1 _or_ `z` must equal `3`

Due to short-circuiting, if `x` is not `1`, the remainder of the statement will not be evaluated.  Also, if `y` is `1`, the code will not check to see if `z` is `3`.

## Other Operators

| operator | name        |
|----------|-------------|
| ? : | ternary operator |
| ?? | null coalescing operator |
| ?. | conditional member access |
| a?[x] | conditional array index access |
| ! | unary not operator |

### Unary Not Operator

If you have a `bool` variable, you can simply place it within the parentheses in the `if` statement.

    bool isTrue = true;
    if( isTrue ) { DoSomething(); }

C# includes an operator to check the opposite of `true`, `false`.  We have seen the `!=`, or not equals, operator.  A `!` by itself negates the boolean.  Double negatives result in a `true` value.

    !true == false
    !false == true

The following five examples are all equivalent, evaluating to `true`.

    bool isTrue = true;

    if( isTrue ) { }
    if( isTrue == true ) { }
    if( isTrue != false ) { }
    if( isTrue != !false ) { }
    if( !isTrue == false ) { }

### Ternary Operator

The ternary operator provides a shorthand way of checking for truth and executing something based on its evaluation.

    int a = 5;
    bool aIsFive = a == 5 ? true : false;

In English, if `a` equals `5` then return `true` and set `aIsFive` to true... else, set `aIsFive` to `false`.  You can also execute code.

    int a = 5;
    int result = a == 5 ? DoSomething(a) : DoSomethingElse(b);

In this case, both pieces of code, `DoSomething` and `DoSomethingElse`, must both return an `int`.

You can also nest ternary operators, but doing so tends to be messy.  Please avoid at all costs.

    int a = 5; int b = 6;
    int result = a == 5 ? b == 6 ? 4 : 3 : 1;
    // result is set to 4

This is functionally equivalent to:

    int a = 5; int b = 6;
    int result;

    if( a == 5 )
    {
        if( b == 6 )
        {
            result = 4;
        }
        else
        {
            result = 3;
        }
    }
    else
    {
        result = 1;
    }

### Conditional Access Operators

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

### Null Coalescing Operator

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

### Combining `case`s

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

* do while while do
* foreach
* for

### yield return
