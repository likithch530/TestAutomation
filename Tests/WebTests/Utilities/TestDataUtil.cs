using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomationPractice.Tests.WebTests.Utilities
{
    public static class TestDataUtil
    {
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            return new string(
                Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray()
            );
        }

        public static string GenerateRandomEmail()
        {
            Random _random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            string localPart = new string(
                Enumerable.Repeat(chars, 10)
                          .Select(s => s[_random.Next(s.Length)])
                          .ToArray()
            );

            string domain = new string(
                Enumerable.Repeat(chars, 6)
                          .Select(s => s[_random.Next(s.Length)])
                          .ToArray()
            );

            return $"{localPart}@{domain}.com";
        }

        /// <summary>
        /// Generates a random date of birth between today - <paramref name="maxAge"/> years and today - <paramref name="minAge"/> years.
        /// Returns a tuple of strings suitable for selecting dropdowns: (Day, MonthName, Year).
        /// Defaults to an adult age range of 18..65.
        /// </summary>
        public static (string Day, string Month, string Year) GenerateRandomDOB(int minAge = 18, int maxAge = 65)
        {
            Random _random = new Random();
            if (minAge < 0) throw new ArgumentOutOfRangeException(nameof(minAge), "minAge must be >= 0");
            if (maxAge < minAge) throw new ArgumentOutOfRangeException(nameof(maxAge), "maxAge must be >= minAge");

            DateTime today = DateTime.Today;
            DateTime latest = today.AddYears(-minAge);   // newest allowed DOB
            DateTime earliest = today.AddYears(-maxAge); // oldest allowed DOB

            int daysRange = (latest - earliest).Days;
            int offsetDays = _random.Next(daysRange + 1); // inclusive

            DateTime dob = earliest.AddDays(offsetDays);

            // Day as number (e.g. "5"), Month as full month name (e.g. "January"), Year as number (e.g. "1990")
            return (dob.Day.ToString(), dob.ToString("MMMM"), dob.Year.ToString());
        }
    }
}
