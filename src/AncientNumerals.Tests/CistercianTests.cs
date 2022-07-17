using FluentAssertions;
using FsCheck;
using Xunit.Abstractions;
using FsCheck.Xunit;

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
            var empty = Cistercian.Parse(@"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    .");
            empty.Value.Should().Be(0);
        }

        [Fact]
        [Trait("Type", "ExampleBased")]
        public void Should_ParseOne_When_CorrespondingCipherIsProvided()
        {
            var one = Cistercian.Parse(@"
.    .----.
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    .");
            one.Value.Should().Be(1);
        }

        [Fact]
        [Trait("Type", "PropertyBased")]
        public void WeCanGoBackFromTheCipherStringRepresentation()
        {
            Prop.ForAll<int>(number =>
            {
                Func<bool> property = () =>
                {
                    var asciiRepresentation = new Cistercian(number).ToString();
                    var parsed = Cistercian.Parse(asciiRepresentation);
                    return parsed.Value == number;
                };
                return property.When(number > 1 && number < 10000);
            }).QuickCheck(_output);
        }
    }
}