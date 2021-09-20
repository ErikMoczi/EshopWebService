using System.Net.Http;
using EshopWebService.IntegrationTests.Core.Clients.PublicApi;

namespace EshopWebService.IntegrationTests.Common.Factories
{
    public static class ClientFactory
    {
        #region PublicApiClient

        public static ProductPublicApiV1Client CreateProductPublicApiV1Client(string baseurl, HttpClient httpClient)
        {
            return new ProductPublicApiV1Client(baseurl, httpClient);
        }

        public static ProductPublicApiV2Client CreateProductPublicApiV2Client(string baseurl, HttpClient httpClient)
        {
            return new ProductPublicApiV2Client(baseurl, httpClient);
        }

        #endregion
    }
}