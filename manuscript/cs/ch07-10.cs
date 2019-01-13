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