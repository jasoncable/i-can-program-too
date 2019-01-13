using System;
namespace SampleConsoleApp.Chapter07
{
    public class OldTimePropery
    {
        private string _myString;

        public string MyString
        {
            get
            {
                return _myString;
            }

            set
            {
                _myString = value;
            }
        }
    }

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

    public class Properties
    {
        public static void TestOldTimeProperty()
        {
            var prop = new OldTimePropery();
            // set the private _myString to "C#"
            prop.MyString = "C#";
            // return the value stored in _myString
            var theString = prop.MyString;
            // theString is now "C#"
        }
    }
}
