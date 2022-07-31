using FsCheck;

namespace AncientNumerals.Tests
{
    public static class CistercianNumberGenerator
    {
        public static Arbitrary<int> Generate() =>
            Arb.Default.Int32().Filter(i => i > 0 && i <= 9999);
    }
}
