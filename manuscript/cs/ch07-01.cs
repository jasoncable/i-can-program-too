Name myName = new Name();
// myName.FullName is "Jason L. Cable"
ChangeFullName(myName);
// myName.FullName is "New Name #1"
myName = new Name();
// myName is now reset, therefore
// myName.Name is "Jason L. Cable"
ChangeFullNameByRef(ref Name myName);
// myName is "New Name #2"

public void ChangeFullName(Name name)
{
    name.FullName = "New Name #1";
}

public void ChangeFullNameByRef(ref Name name)
{
    name.FullName = "New Name #2";
}