using AncientNumerals.Tests.Properties;
using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using Xunit.Abstractions;

namespace AncientNumerals.Tests
{
    public class CistercianTests
    {
        private readonly ITestOutputHelper _output;

        public CistercianTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        [Trait("Type", "ExampleBased")]
        public void Should_ParseZero_When_AnEmptyCipherIsProvided()
        {
            Resources.ResourceManager.GetString("");
            var empty = Cistercian.Parse(Resources.String0000);
            empty.Value.Should().Be(0);
        }

        [Fact]
        [Trait("Type", "ExampleBased")]
        public void Should_ParseOne_When_CorrespondingCipherIsProvided()
        {
            var one = Cistercian.Parse(Resources.String0001);
            one.Value.Should().Be(1);
        }

        [Fact]
        [Trait("Type", "ExampleBased")]
        public void Numbers()
        {
            var cistercian = new Cistercian(9999);
            cistercian.ToString().Should().Be(Resources.String9999);
        }

        [Property(StartSize = 1, EndSize = 9999, Arbitrary = new[] { typeof(CistercianNumberGenerator) })]
        [Trait("Type", "PropertyBased")]
        public Property Given_AllCistercianNumbersStringified_Should_AllBeParsedBack(int number)
        {
            Func<bool> property = () =>
            {
                var asciiRepresentation = new Cistercian(number).ToString();
                var parsed = Cistercian.Parse(asciiRepresentation);
                return parsed.Value == number;
            };
            return property
                .Label($"Expected {number} to be stringified and parsed back");
        }
    }
}