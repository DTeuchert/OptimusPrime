using Moq;
using OptimusPrime.Server.Services;
using Xunit;

namespace OptimusPrime.Server.Tests.Services
{
    public class PrimeServiceTest
    {
        private readonly IPrimeService _primeService;

        public PrimeServiceTest()
        {
            _primeService = new PrimeService();
        }

        [Fact]
        public void IsNotPrime()
        {
            /* Arrange */
            /* Act */
            var result = _primeService.IsPrime(1);

            /* Assert */
            Assert.False(result, "1 should not be prime");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        public void IsPrime(int number)
        {
            /* Arrange */
            /* Act */
            var result = _primeService.IsPrime(number);

            /* Assert */
            Assert.True(result, $"{number} should be a prime");
        }

        [Fact]
        public void MockingPrimeService()
        {
            /* Arrange */
            var mock = new Mock<IPrimeService>();
            mock.Setup(p => p.IsPrime(1)).Returns(false);

            var primeService = mock.Object;

            /* Act */
            var result = primeService.IsPrime(1);

            /* Assert */
            Assert.False(result, "1 should not be prime");
        }
    }
}
