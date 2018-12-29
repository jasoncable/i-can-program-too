int? i = 123;
int? j = 321;
int? k = null;
int x = 12;
int y = 21;

// nullable + nullable
i + j // 444

// nullable + non-nullable
i + x // 135

// non-nullable + nullable
x + i // 135

// null + nullable
k + i // null

// nullable + null
i + k // null

// null + non-null
k + y // null

// non-null + null
y + k // null