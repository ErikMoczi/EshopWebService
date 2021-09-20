using System.Net.Http;
using EshopWebService.Api;
using EshopWebService.IntegrationTests.Core.StartUp;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EshopWebService.IntegrationTests.Cases.Abstractions
{
    public abstract class BaseIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient Client;
        protected readonly CustomWebApplicationFactory<Startup> Factory;

        protected BaseIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            Factory = factory;
            Client = factory.CreateClient(new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                }
            );
        }
    }
}