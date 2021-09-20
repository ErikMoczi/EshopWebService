using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EshopWebService.Application.DTOs.Result;
using EshopWebService.Application.Handlers.Features.Product.Queries.GetAllPaged;
using EshopWebService.IntegrationTests.Common.Constants;
using EshopWebService.IntegrationTests.Core.Clients.Abstractions;

namespace EshopWebService.IntegrationTests.Core.Clients.PublicApi
{
    public class ProductPublicApiV2Client : PublicApiClient
    {
        public ProductPublicApiV2Client(string baseUrl, HttpClient httpClient) : base(baseUrl, httpClient)
        {
        }

        protected override void PrepareUrlBuilder(StringBuilder stringBuilder)
        {
            base.PrepareUrlBuilder(stringBuilder);
            stringBuilder.Append(Configurations.PublicApiV2Endpoints.ProductApi.Controller.TrimEnd('/'));
        }

        public Task<PaginatedResultDto<GetAllProductsPagedResponse>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return GetAsync<object, PaginatedResultDto<GetAllProductsPagedResponse>>(Configurations.PublicApiV2Endpoints.ProductApi.GetAllProduct, new { pageNumber, pageSize }, CancellationToken.None);
        }
    }
}