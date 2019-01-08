public class Name
{
    public string FullName = "Jason L. Cable";
}

Name myName = new Name();
myName.FullName.Should().Be("Jason L. Cable");
myName.FullName = "Full Name #3";
ReassignName(myName);
myName.FullName.Should().Be("Full Name #4");

public static void ReassignName(Name name)
{
    name.Should().Be("Full Name #3");
    name.FullName = "Full Name #4";
    name = new Name();
    name.FullName.Should().Be("Jason L. Cable");
}