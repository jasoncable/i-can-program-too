using System;

namespace Extensions
{
    public class Company
    {
        private string _secretData = ".NET";
        public string Name = "Microsoft Corp.";
        public string Address1 = "One Microsoft Way";
        public string Address2 = null;
        public string City = "Redmond";
        public string State = "WA";
        public string Country = "US";
        public string ZipCode = "98052-8300";
        public string PhoneNumber = "8006427676";
        public int EmployeeCount = 134944;
        public DateTime DateOfIncorporation = new DateTime(1975, 4, 4);
    }

    public static class ExtensionMethods
    {
        public static void RunMe()
        {
            string s = "4125551212";
            var prettyPhoneNo = s.ToFormattedPhoneNumber();

            var outDate = DateTime.Now.ToFormattedDate();
        }

        public static string ToFormattedPhoneNumber(this string phoneNo)
        {
            if (String.IsNullOrWhiteSpace(phoneNo) || phoneNo.Length != 10)
            {
                return phoneNo;
            }
            return $"1-({phoneNo.Substring(0,3)})" +
                $" {phoneNo.Substring(3,3)}-{phoneNo.Substring(6,4)}";
        }

        public static string ToFormattedDate(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static string FormatLabel(this Company company)
        {
            return company.Name + "\n" +
                company.Address1 + "\n" +
                company.Address2 ?? String.Empty + "\n" +
                company.City + ", " + company.State + " " +
                company.ZipCode;
        }

    }
}
