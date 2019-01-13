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

    public class Phone
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string OS { get; private set; }
        public string OSVersion { get; private set; }

        public static Phone iPhoneXs
        {
            get
            {
                Phone p = new Phone();
                p.Brand = "Apple";
                p.Model = "iPhone";
                p.OS = "iOS";
                p.OSVersion = "12.1.2";
                return p;
            }
        }

        public static Phone SamsungGalaxy9
        {
            get
            {
                Phone p = new Phone();
                p.Brand = "Samsung";
                p.Model = "Galaxy S9";
                p.OS = "Android";
                p.OSVersion = "9.0.0";
                return p;
            }
        }

    }

    public static class PhoneModels
    {
        public static void Test()
        {
            Phone p = Phone.iPhoneXs;
            // p.Brand = "Apple Inc."; // compiler error
            // Phone.iPhoneXs = new Phone(); // another compiler error
            Console.WriteLine(p.Model);
            // prints "iPhone"

            Phone1[] pa = new Phone1[]
            {
                new Phone1
                {
                    Brand = "Apple"
                },
                new Phone1
                {
                    Brand = "Google"
                }
            };
        }
    }

    public class Phone1
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string OS { get; set; }
        public string OSVersion { get; set; }
            
        public static Phone1 iPhoneXs
        {
            get
            {
                return new Phone1()
                {
                    Brand = "Apple",
                    OSVersion = "12.1.2",
                };
            }
        }
    }
}
