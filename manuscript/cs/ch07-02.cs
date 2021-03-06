Name a = new Name();
Name b = a;
Name c = b;
a.Should().BeSameAs(b);
b.Should().BeSameAs(c);
a.FullName.Should().Be("Jason L. Cable");
b.FullName = "Full Name #1";
b.FullName.Should().Be("Full Name #1");
a.FullName.Should().Be("Full Name #1");
c.FullName.Should().Be("Full Name #1");
b = new Name();
b.FullName.Should().Be("Jason L. Cable");
a.FullName.Should().Be("Full Name #1");
c.FullName.Should().Be("Full Name #1");
// now try on value types
int x = 1;
int y = x;
int z = y;
x.Should().Be(1);
y.Should().Be(1);
z.Should().Be(1);
x = 10;
y = 20;
z = 30;
x.Should().Be(10);
y.Should().Be(20);
z.Should().Be(30);