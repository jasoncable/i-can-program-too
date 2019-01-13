public class Phone
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string OS { get; set; }
    public string OSVersion { get; set; }

    public static Phone iPhoneXs
    {
        get
        {
            return new Phone()
            {
                Brand = "Apple",
                Model = "iPhone",
                OS = "iOS",
                OSVersion = "12.1.2"
            };
        }
    }
}
// ----- //
// array initialization
Phone[] pa = new Phone[]
{
    new Phone
    {
        Brand = "Apple"
    },
    new Phone
    {
        Brand = "Google"
    }
};