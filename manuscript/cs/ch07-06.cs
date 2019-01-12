using System;
namespace Extensions
{
    public static class ExtensionMethods
    {
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