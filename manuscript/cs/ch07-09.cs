public class OldTimePropertyWithLogic
{
    private static string _myString = String.Empty;

    public string MyString
    {
        get
        {
            if (_myString == null)
                return String.Empty;
            else
                return _myString;
        }

        set
        {
            if (value.Length > 10)
                _myString = value.Substring(0, 10);
            else
                _myString = value;
        }
    }
}