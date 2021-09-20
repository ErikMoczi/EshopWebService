using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EshopWebService.Api;
using EshopWebService.Application.DTOs.Result;
using EshopWebService.IntegrationTests.Common.Constants;
using EshopWebService.IntegrationTests.Common.Extensions;
using EshopWebService.IntegrationTests.Common.Factories;
using EshopWebService.IntegrationTests.Core.Clients.Abstractions;
using EshopWebService.IntegrationTests.Core.Clients.PublicApi;
using EshopWebService.IntegrationTests.Core.StartUp;

namespace EshopWebService.IntegrationTests.Cases.Abstractions
{
    public abstract class BasePublicApiTests : BaseIntegrationTests
    {
        protected readonly string BaseUrl = Configurations.BaseUrl;

        protected BasePublicApiTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        #region CallAsync

        protected Task<TResult> CallAsync<TResult>(Func<HttpClient, Task<TResult>> action)
        {
            return action(Client);
        }


        #region CallWithResponseDtoAsync

        private Task<TResult> CallWithResponseDtoInternalAsync<TResult, TClient>(Func<HttpClient, TClient> getClient, Func<TClient, Task<TResult>> action, Action<TResult> checkResponse)
            where TResult : IResultDto
            where TClient : BaseClient
        {
            return CallAsync(async httpClient =>
            {
                var result = await action(getClient(httpClient));
                checkResponse(result);
                return result;
            });
        }

        #region StateOk

        protected Task CallWithResponseDtoOkAsync<TClient>(Func<HttpClient, TClient> getClient, Func<TClient, Task<ResultDto>> action)
            where TClient : BaseClient
        {
            return CallWithResponseDtoInternalAsync(getClient, action, result => result.AssertResultDtoStatusOk());
        }

        protected async Task<TItem> CallWithResponseDtoOkAsync<TItem, TClient>(Func<HttpClient, TClient> getClient, Func<TClient, Task<ResultDto<TItem>>> action)
            where TClient : BaseClient
        {
            var response = await CallWithResponseDtoInternalAsync(getClient, action, result => result.AssertResultDtoStatusOk());
            return response.Data;
        }

        protected async Task<List<TItem>> CallWithResponseDtoOkAsync<TItem, TClient>(Func<HttpClient, TClient> getClient, Func<TClient, Task<PaginatedResultDto<TItem>>> action)
            where TClient : BaseClient
        {
            var response = await CallWithResponseDtoInternalAsync(getClient, action, result => result.AssertResultDtoStatusOk());
            return response.Data;
        }

        #endregion

        #endregion

        #endregion

        protected ProductPublicApiV1Client GetProductPublicApiV1Client(HttpClient httpClient)
        {
            return ClientFactory.CreateProductPublicApiV1Client(BaseUrl, httpClient);
        }

        protected ProductPublicApiV2Client GetProductPublicApiV2Client(HttpClient httpClient)
        {
            return ClientFactory.CreateProductPublicApiV2Client(BaseUrl, httpClient);
        }
    }
}