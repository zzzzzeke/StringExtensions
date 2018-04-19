using System;
using System.ComponentModel.DataAnnotations;

namespace zzzzzeke.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string value, StringComparison stringComparison)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return source.IndexOf(value, stringComparison) >= 0;
        }

        public static bool IsEmailAddress(this string source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            return new EmailAddressAttribute().IsValid(source);
        }
    }
}
