using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EshopWebService.Api;
using EshopWebService.Application.Handlers.Features.Product.Commands.Update;
using EshopWebService.Application.Handlers.Features.Product.Queries.GetById;
using EshopWebService.IntegrationTests.Cases.Abstractions;
using EshopWebService.IntegrationTests.Common.Helpers;
using EshopWebService.IntegrationTests.Core.StartUp;
using EshopWebService.Intrastructure.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EshopWebService.IntegrationTests.Cases.PublicApi.Product
{
    public abstract class BaseProductTests : BasePublicApiTests, IDisposable
    {
        protected List<Domain.Entities.Product> InputProduct = DataUtilities.GetSeedingProducts();

        protected BaseProductTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        #region Helpers

        protected Task<GetProductByIdResponse> GetByIdAsync(int id)
        {
            return CallWithResponseDtoOkAsync(
                GetProductPublicApiV1Client,
                client => client.GetByIdAsync(id)
            );
        }

        protected Task<int> UpdateProductAsync(UpdateProductCommand updateProductCommand)
        {
            return CallWithResponseDtoOkAsync(
                GetProductPublicApiV1Client,
                client => client.UpdateProductAsync(updateProductCommand)
            );
        }

        protected Task GetProductByIdExceptionAsync(int id, HttpStatusCode httpStatusCode)
        {
            return ApiExceptionHelper.CheckErrorDuringApiCallAsync(() => GetByIdAsync(id), httpStatusCode);
        }

        protected Task UpdateProductExceptionAsync(UpdateProductCommand updateProductCommand, HttpStatusCode httpStatusCode)
        {
            return ApiExceptionHelper.CheckErrorDuringApiCallAsync(() => UpdateProductAsync(updateProductCommand), httpStatusCode);
        }

        protected async Task GetProductById(int id)
        {
            var inputProduct = GetById(id);

            var resultProduct = await GetByIdAsync(id);

            Assert.Equal(inputProduct.Id, resultProduct.Id);
            Assert.Equal(inputProduct.Name, resultProduct.Name);
            Assert.Equal(inputProduct.Description, resultProduct.Description);
            Assert.Equal(inputProduct.ImgUri, resultProduct.ImgUri);
            Assert.Equal(inputProduct.Price, resultProduct.Price);
        }

        protected List<Domain.Entities.Product> GetInputData()
        {
            return InputProduct;
        }

        protected Domain.Entities.Product GetById(int id)
        {
            return GetInputData().FirstOrDefault(x => x.Id == id);
        }

        #endregion

        public void Dispose()
        {
            using var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var applicationDbContext = scopedServices.GetRequiredService<ApplicationDbContext>();

            InputProduct = DataUtilities.ReinitializeDbForTests(applicationDbContext);
        }
    }
}