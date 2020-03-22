using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;

namespace SampleApp.Tests
{
    public class Tests
    {
        private CustomWebApplicationFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new CustomWebApplicationFactory();
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            factory.Dispose();
        }


        [TestCase("/WeatherForecast")]
        public async Task Test1(string url)
        {
            var client = factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            var stringResult = await response.Content.ReadAsStringAsync();
            var forecasts = JsonConvert.DeserializeObject<List<WeatherForecast>>(stringResult);
            Assert.AreEqual(5, forecasts.Count);
        }
    }
}