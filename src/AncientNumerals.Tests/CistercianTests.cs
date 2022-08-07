using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using System.Text;
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

        private string GetFullString(string[] lines)
        {
            var sb = new StringBuilder();
            foreach(string line in lines)
            {
                sb.AppendLine(line);
            }
            return sb.ToString().Trim(Environment.NewLine.ToCharArray());
        }

        [Fact]
        [Trait("Type", "ExampleBased")]
        public void Should_ParseZero_When_AnEmptyCipherIsProvided()
        {
            var asciiRepresentation = GetFullString(new[] 
            {
                ".    .    .",
                "     |     ",
                "     |     ",
                "     |     ",
                "     |     ",
                "     |     ",
                ".    |    .",
                "     |     ",
                "     |     ",
                "     |     ",
                "     |     ",
                "     |     ",
                ".    .    .",
            });
            var empty = Cistercian.Parse(asciiRepresentation);
            empty.Value.Should().Be(0);
        }

        [Fact]
        [Trait("Type", "ExampleBased")]
        public void Should_ParseOne_When_CorrespondingCipherIsProvided()
        {
            var asciiRepresentation = GetFullString(new[]
            {
                ".    .----.",
                "     |     ",
                "     |     ",
                "     |     ",
                "     |     ",
                "     |     ",
                ".    |    .",
                "     |     ",
                "     |     ",
                "     |     ",
                "     |     ",
                "     |     ",
                ".    .    .",
            });
            var one = Cistercian.Parse(asciiRepresentation);
            one.Value.Should().Be(1);
        }

        [Fact]
        [Trait("Type", "ExampleBased")]
        public void Numbers()
        {
            var cistercian = new Cistercian(9999);
            var asciiRepresentation = GetFullString(new[]
            {
                ".----.----.",
                "|    |    |",
                "|    |    |",
                "|    |    |",
                "|----|----|",
                "     |     ",
                ".    |    .",
                "     |     ",
                "|----|----|",
                "|    |    |",
                "|    |    |",
                "|    |    |",
                ".----.----.",
            });
            cistercian.ToString().Should().Be(asciiRepresentation);
        }

        [Property(StartSize = 1, EndSize = 9999, Arbitrary = new[] { typeof(CistercianNumberGenerator) })]
        [Trait("Type", "PropertyBased")]
        public Property Given_AllCistercianNumbersStringified_Should_BeParsedBack(int number)
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