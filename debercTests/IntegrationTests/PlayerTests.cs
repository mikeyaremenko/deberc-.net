using debercApi.Models;
using System.Net.Http.Json;

namespace debercTests.IntegrationTests
{
    [TestClass]
    public class PlayerTests : BaseTest
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            ApiUrl = "/api/player";
        }

        [TestMethod]
        public async Task GetAll()
        {
            var response = await _httpClient.GetAsync(ApiUrl);
            var result = await response.Content.ReadFromJsonAsync(typeof(List<Player>));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Create()
        {
            var player = GetPlayer();
            var response = await _httpClient.PostAsJsonAsync(ApiUrl, player);
            var result = await response.Content.ReadAsStringAsync();

            Assert.IsNotNull(result);
        }

        private Player GetPlayer()
            => new() { Name = "John", Password = "p@ssw0rd", Index = 0 };
    }
}