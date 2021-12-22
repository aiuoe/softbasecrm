using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Common
{
    public static class MethodExtensions
    {
        public static bool ExceedLength(this string inputText, int maxLength)
        {
            return inputText != null && inputText.Length > maxLength;
        }
    }
}
