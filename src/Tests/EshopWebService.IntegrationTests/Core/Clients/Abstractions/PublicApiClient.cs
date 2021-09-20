using System.Net.Http;

namespace EshopWebService.IntegrationTests.Core.Clients.Abstractions
{
    public abstract class PublicApiClient : BaseClient
    {
        protected PublicApiClient(string baseUrl, HttpClient httpClient) : base(baseUrl, httpClient)
        {
        }
    }
}