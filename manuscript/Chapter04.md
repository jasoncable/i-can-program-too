# Array Basics

## Definition

An array is a list of things.  You can think of a shopping list as an array of groceries.  Earlier in this chapter we talked about sorting strings.  The first step you take is to place the strings to sort into an array.

    string[] sa = new string[] { "life", "life-and-death", "life belt", 
    "lifeblood", "life-support", "life support", "LIFO" };

This is a _single-dimensional_ array.  It is a flat structure that is a simple list of things.  An array can be of any value or reference type.  This means that you can have arrays of numbers \(`int`, etc.\), characters \(`char`\), `byte`s, `string`s or just about anything else.

When you create an array, you specify the type of data it holds along with its size.  An array's size cannot be changed once created.  The size of an array is also called its _bounds_.  Also, the values are initialized to the default value of the data type unless you specify values in the variable assignment.

Brackets `[]` are used to tell us that something is an array.  They are also used to retrieve data from an array, which we will see in a bit.

## Single-dimensional Arrays

There are, of course, several ways to create a single-dimensional array.

    // create an array of strings that can hold 5 values
    string[] sa = new string[5];

    // ...with values...
    string[] sa = new string[] { "a", "b", "c" };
    string[] sa = { "a", "b", "c" };

    // ...or...
    string[] sa;
    sa = new string[] { "a", "b", "c" };

A> ### A preview of generics.
A>
A> In C# we have a special concept called generics.  They were introduced in C# 2.0 in 2005.  They provide came with updated data structures for C# to make everyday programming easier than manual array manipulation.  The basic arrays we are talking about here are still used everyday, although usually for lower-level operations.  Network operations such as web servers operate in the form of passing `byte[]`s back and forth.  Nearly all I/O operations use arrays.  In fact, C#'s generic `List<T>` and `Dictionary<TKey,TValue>` are implemented on top of basic .NET arrays.  More on these later.  It is important to know that a basic knowledge of arrays is required to understand more advanced concepts, even if we don't directly use them every day.

To get data out of an array we can pull it out by index.  Slots in an array are all numbered, beginning at `0`.  In the following example, the the indexes are as follows.  Each index refers to what we call an element of the array.

    string[] sa = { "a", "b", "c", "d" };
    // "a" is 0
    // "b" is 1
    // "c" is 2
    // "d" is 3

`sa[0]` will give us the value of the first element of the array.  In this case we end up with `"a"`.

We can use this bare or assign it to a variable.

    string a = sa[0];

The new variable `a` points to the _value_ stored in the first array element.  It does _not_ point to the array's element itself.  It points to the data held within the element of the array.  This is important for a couple of reasons.  First, if we assign a different value to the variable `s`, `sa[0]` is _not_ updated.

    string a = sa[0];
    // both a and sa[0] contain the value "a"
    a = "ab";
    // a is now "ab"; sa[0] is still "a"

We will learn in a little bit that changing data on an object that is contained within an array element may be changed via the reference to the object.  In our case, re-assigning the value of the variable does not change the value in the array.  The assignment rule applies to both value types and reference types.

To update the values in an array element, you simply use the index for assignment.

    string[] sa = { "a", "b", "c", "d" };
    // to change element 0, the first element
    sa[0] = "new a value";

The special combined math/assignment operators also work on array references.

    int[] intArray = { 0, 1, 2 };
    intArray[0] += 5;
    // the first array element is now 5

A> #### The Number Two C# Programming Error
A>
A> The second most common programming error in C# is not checking the bounds of the array \(its length\) before trying to retrieve its value.  Below we will discuss how to do this.  Please remember, always check the length of an array before trying to pull a value from it!

## Multidimensional Arrays

An array may have multiple dimensions.  We have only been looking at single-dimensional arrays.  If you wanted to represent the data in a spreadsheet in array form you could use a two-dimensional array.  It is created as such:

    int[,] intArray = { { 1, 2 }, { 3, 4 } };
    // or
    int[,] intArray = new int[100,10];
    // this creates a two dimensional array that has
    // 100 columns and 10 rows (in our example)

To create an array that holds data like the following, do something like this:

    int[,] intArray = new int[5,4];
    intArray[0,0] = 0;
    intArray[1,0] = 1;
    ...
    intArray[3,3] = 5;
    ...

| 0 | 1 | 2 | 3 |
| 1 | 2 | 3 | 4 |
| 2 | 3 | 4 | 5 |
| 3 | 4 | 5 | 6 |
| 4 | 5 | 6 | 7 |

In this example, I am treating the first dimension as rows and the second dimension as columns.  You could easily treat it the opposite way, such as considering the first dimension to be an `x` value and the second to be a `y` value.

Retrieving values is as easy as:

    int x = intArray[2,3];

You may also use the array initializer syntax as follows:

    int[,] array2D = new int[,] 
        { 
            { 1, 2 }, 
            { 3, 4 }, 
            { 5, 6 }, 
            { 7, 8 } }
        };

A three-dimensional array follows the same rules.  Going beyond three dimensions really should be avoided.  You will probably find other data structures that are easier to use.

## Jagged Arrays

C# also supports jagged arrays, also called an array of arrays.  These are named because the dimensions are not of a fixed length.  You can see it thusly: a jagged array defines a base array where each element contains an array.

To create a jagged array, you must specify the size of the base array, but not the arrays it contains.  The following code creates an a jagged integer array.

    int[][] intArray = new int[3][];

To finish creating our array, we need to add arrays that will hold the data.  Our base array only holds references to the other arrays.

    intArray[0] = new int[5];
    intArray[1] = new int[7];
    intArray[2] = new int[2];

We can also use the array initialization syntax.  In this case, you do not have to specify the size of the array, as it is inferred by the number of items between the braces `{}`.

    intArray[0] = new int[] {1,2,3,4,5};

To set data in a jagged array, in this case the third element of the first array.  As this is an array of arrays, we specify the data locations a little bit differently than in a multidimensional array.  Instead of `intArray[0,0]`, we use the following.

    intArray[0][2] = 55;

One last thing of note, the base array of a jagged array may contain multidimensional arrays.

    int[][,] jmArray = new int[3][,];
    jmArray[0] = new int[3,4];
    jmArray[0][0,0] = 42;

### Summary

Arrays in C# form the basis of more advanced data structures.  Today we often use easier to use objects to handle our data needs.  Arrays were much more important in C# 1.0, but are still incredibly useful today.
