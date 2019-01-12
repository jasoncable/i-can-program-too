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