using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EshopWebService.Application.DTOs.Result;
using EshopWebService.Application.Handlers.Features.Product.Commands.Update;
using EshopWebService.Application.Handlers.Features.Product.Queries.GetAll;
using EshopWebService.Application.Handlers.Features.Product.Queries.GetById;
using EshopWebService.IntegrationTests.Common.Constants;
using EshopWebService.IntegrationTests.Core.Clients.Abstractions;

namespace EshopWebService.IntegrationTests.Core.Clients.PublicApi
{
    public class ProductPublicApiV1Client : PublicApiClient
    {
        public ProductPublicApiV1Client(string baseUrl, HttpClient httpClient) : base(baseUrl, httpClient)
        {
        }

        protected override void PrepareUrlBuilder(StringBuilder stringBuilder)
        {
            base.PrepareUrlBuilder(stringBuilder);
            stringBuilder.Append(Configurations.PublicApiV1Endpoints.ProductApi.Controller.TrimEnd('/'));
        }

        public Task<ResultDto<GetProductByIdResponse>> GetByIdAsync(int id)
        {
            return GetAsync<object, ResultDto<GetProductByIdResponse>>(Configurations.PublicApiV1Endpoints.ProductApi.GetProductById(id), null, CancellationToken.None);
        }

        public Task<ResultDto<int>> UpdateProductAsync(UpdateProductCommand command)
        {
            return PutAsync<object, ResultDto<int>>(Configurations.PublicApiV1Endpoints.ProductApi.UpdateProduct, command, CancellationToken.None);
        }

        public Task<ResultDto<List<GetAllProductsResponse>>> GetAllAsync()
        {
            return GetAsync<object, ResultDto<List<GetAllProductsResponse>>>(Configurations.PublicApiV1Endpoints.ProductApi.GetAllProduct, null, CancellationToken.None);
        }
    }
}