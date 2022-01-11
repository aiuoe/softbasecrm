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
    }
}
