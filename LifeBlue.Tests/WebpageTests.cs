using LifeBlue.Tests.DataGenerators;

namespace LifeBlue.Tests
{
    public class WebpageTests
    {
        [Theory]
        [MemberData(nameof(WebpageDataGenerator.URL_TESTS), MemberType = typeof(WebpageDataGenerator))]
        public void Url_ShouldBe(string myUrl, string requestedUrl, bool expected)
        {
            var webpage = new Webpage();

            var result = webpage.ShowHighlight(myUrl, requestedUrl);

            Assert.Equal(expected, result);
        }
    }
}