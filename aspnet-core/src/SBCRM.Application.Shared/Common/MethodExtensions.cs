using System;

namespace SBCRM.Common
{
    /// <summary>
    /// This class is used as a tool for common method extensions for the entire application
    /// </summary>
    public static class MethodExtensions
    {
        /// <summary>
        /// Method used to know if a string exceeds or not its length
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static bool ExceedLength(this string inputText, int maxLength)
        {
            return inputText != null && inputText.Length > maxLength;
        }

        /// <summary>
        /// Reset time to 00 Hours from DateTime object
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime? ResetTimeToZeroHours(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return null;
            }

            return new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day);
        }

        /// <summary>
        /// Reset time to 00 Hours of the next day from DateTime object
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime? ResetTimeToLastHoursNextDay(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return null;
            }

            return ResetTimeToZeroHours(dateTime).Value.AddDays(1);
        }
    }
}
