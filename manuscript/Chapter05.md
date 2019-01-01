# Logic and Control Structures

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

    if the outside temperature is between 10°F and 42°F
    then it is cold
    else if it the outside temperature is less than 10°F
    then it is frigid
    else if the outside temperature is greater than 42°F
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
| || | logical or operator |
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

### Checking Array Lengths

### Checking Nullable Types for Values

### Nots

## ternary operator

## The One Year Problem


### .hasValue vs == null

### type checks

### array length checks

### Control structures
* if then else if else
* do while while do
* foreach
* switch
* goto
* for

> "The __go to__ statement should be abolished from all "higher level" programming languages."
>
> -Edsger Dijkstra \(1968\)

### references on array objects

NO GOTOs
