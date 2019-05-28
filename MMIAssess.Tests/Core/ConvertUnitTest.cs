using MMIAssess.Core.Exceptions;
using MMIAssess.Core.Interfaces;
using MMIAssess.Core.Models;
using MMIAssess.Core.Models.Conversions;
using MMIAssess.Core.Models.UnitsOfMeasure;
using MMIAssess.Core.Shared;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace MMIAssess.Tests.Core
{
    public class ConvertUnitTest
    {
        [Theory]
        [InlineData("mph", "Celsius", 200)]
        public void TestIncompatibleConversion(string from, string to, decimal value)
        {
            var conversion = new TemperatureConversion();
            Assert.Throws<IncompatibleConversionException>(() =>
            {
                conversion.DoConversion(from, to, value);
            });
        }

        [Theory]
        [MemberData(nameof(ExpectedConversionResult))]
        public void TestSuccessfulConversion(ConversionResult expected)
        {
            var conversion = new TemperatureConversion();
            var convertResult = conversion.DoConversion("kelvin", "celsius", 100);
            expected.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> ExpectedConversionResult
            => new []
            {
                new object[] { new ConversionResult(
                    ConversionType.Temperature,
                    new KelvinUOM(),
                    new CelciusUOM(),
                    100,
                    (decimal)-173.15
                    )
                } 
            };
    }
}
