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
        public void Numbers()
        {
            var c = new Cistercian(5555);
            _output.WriteLine(c.ToString());
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

        [Property]
        [Trait("Type", "PropertyBased")]
        public Property AllNumbersStringifiedCanBeParsedBack(int number)
        {
            Func<bool> property = () =>
            {
                var asciiRepresentation = new Cistercian(number).ToString();
                var parsed = Cistercian.Parse(asciiRepresentation);
                return parsed.Value == number;
            };
            return property.When(number > 0 && number < 10000)
                .Classify(number > 0 && number < 10, "units")
                .Classify(number >= 10 && number < 100, "dozens")
                .Classify(number >= 100 && number < 1000, "hundreds")
                .Classify(number >= 1000, "thousands")
                ;
        }
    }
}