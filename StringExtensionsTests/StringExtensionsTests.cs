using System;
using Xunit;

namespace zzzzzeke.Extensions.Tests
{
    public class StringExtensionsTests 
    {
        [Fact]
        public void StringContains_NullSource_ThrowsArgumentNullException()
        {
            string source = null;
            Assert.Throws<ArgumentNullException>(() => source.Contains("value", StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public void StringContains_NullValue_ThrowsArgumentNullException()
        {
            string value = null;
            Assert.Throws<ArgumentNullException>(() => "source".Contains(value, StringComparison.OrdinalIgnoreCase));
        }

        [Theory]
        [InlineData("Some test string", "TEST", StringComparison.OrdinalIgnoreCase, true)]
        public void StringContains_EqualsExpected(string source, string value, StringComparison stringComparison, bool expected)
        {
            Assert.Equal(expected, source.Contains(value, stringComparison));
        }
    }
}
