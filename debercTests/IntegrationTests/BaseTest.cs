using debercApi.Controllers;
using DotNet.Testcontainers.Builders;
using Microsoft.AspNetCore.Mvc.Testing;
using Testcontainers.MsSql;

namespace debercTests.IntegrationTests
{
    [TestClass]
    public class BaseTest
    {
        protected HttpClient _httpClient = new();
        protected string ApiUrl = string.Empty;

        [TestInitialize]
        public virtual void Initialize()
        {
            var webAppFactory = new WebApplicationFactory<PlayerController>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        private void CreateTestContainers()
        {
            const string storage = "weatherForecastStorage";
            const string connectionString = $"server={storage};user id={MsSqlBuilder.DefaultUsername};password={MsSqlBuilder.DefaultPassword};database={MsSqlBuilder.DefaultDatabase}";

            var debercNetwork = new NetworkBuilder()
              .Build();

            var _msSqlContainer = new MsSqlBuilder()
              .WithNetwork(debercNetwork)
              .WithNetworkAliases(storage)
              .Build();

            // TODO create app container?
        }
    }
}