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

        [Fact]
        public void StringIsEmailAddress_NullSource_ThrowsArgumentNullException()
        {
            string source = null;
            Assert.Throws<ArgumentNullException>(() => source.IsEmailAddress());
        }

        [Theory] // TODO: review this list and the logic: https://blogs.msdn.microsoft.com/testing123/2009/02/06/email-address-test-cases/
        [InlineData("email@domain.com", true)]
        [InlineData("firstname.lastname@domain.com", true)]
        [InlineData("email@subdomain.domain.com", true)]
        [InlineData("firstname+lastname@domain.com", true)]
        [InlineData("email@123.123.123.123", true)]
        [InlineData("email@[123.123.123.123]", true)]
        [InlineData("\"email\"@domain.com", true)]
        [InlineData("1234567890@domain.com", true)]
        [InlineData("email@domain-one.com", true)]
        [InlineData("_______@domain.com", true)]
        [InlineData("email@domain.name", true)]
        [InlineData("email@domain.co.jp", true)]
        [InlineData("firstname-lastname@domain.com", true)]
        [InlineData("plainaddress", false)]
        [InlineData("#@%^%#$@#$@#.com", false)]
        [InlineData("@domain.com", false)]
        //[InlineData("Joe Smith <email@domain.com>", false)]
        [InlineData("email.domain.com", false)]
        [InlineData("email@domain@domain.com", false)]
        //[InlineData(".email@domain.com", false)]
        //[InlineData("email.@domain.com", false)]
        //[InlineData("email..email@domain.com", false)]
        //[InlineData("あいうえお@domain.com", false)]
        //[InlineData("email@domain.com (Joe Smith)", false)]
        //[InlineData("email@domain", false)]
        //[InlineData("email@-domain.com", false)]
        //[InlineData("email@domain.web", false)]
        //[InlineData("email@111.222.333.44444", false)]
        //[InlineData("email@domain..com", false)]
        public void StringIsEmailAddress_EqualsExpected(string source, bool expected)
        {
            Assert.Equal(expected, source.IsEmailAddress());
        }
    }
}
