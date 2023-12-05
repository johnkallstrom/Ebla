namespace Ebla.Web.Extensions
{
    public static class StringExtensions
    {
        public static string ToCustomDateFormat(this DateTime dateTime)
        {
            return dateTime.ToString("dd MMMM yyyy");
        }

        public static string ToYear(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy");
        }
    }
}