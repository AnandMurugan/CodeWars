using System.Text.RegularExpressions;

namespace KataPrograms
{
    public static class Kata
    {
        public static bool ValidPhoneNumber(string phoneNumber)
        {
            return Regex.Match(phoneNumber,
                @"^\([0-9]{3}\) [0-9]{3}\-[0-9]{4}$").Success;
        }
    }
}