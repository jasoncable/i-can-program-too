Name myName = new Name();
myName.FullName.Should().Be("Jason L. Cable");
ReassignNameByRef(ref myName);
myName.FullName.Should().Be("Full Name #5");

public static void ReassignNameByRef(ref Name name)
{
    name = new Name();
    name.FullName.Should().Be("Jason L. Cable");
    name.FullName = "Full Name #5";
    name.FullName.Should().Be("Full Name #5");
}