using System.Net;
using System.Threading.Tasks;
using EshopWebService.Api;
using EshopWebService.Application.Handlers.Features.Product.Commands.Update;
using EshopWebService.IntegrationTests.Core.StartUp;
using Xunit;

namespace EshopWebService.IntegrationTests.Cases.PublicApi.Product
{
    public class UpdateProductTests : BaseProductTests
    {
        public UpdateProductTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        #region UpdateProduct

        [Fact]
        public async Task UpdateProductSuccessTest()
        {
            const int id = 1;
            var inputProduct = GetById(id);

            inputProduct.Description = "UpdateTest";

            var updateProductCommand = new UpdateProductCommand
            {
                Id = inputProduct.Id,
                Description = inputProduct.Description
            };

            var resultProductId = await UpdateProductAsync(updateProductCommand);

            Assert.Equal(inputProduct.Id, resultProductId);

            await GetProductById(id);
        }

        [Fact]
        public async Task UpdateProductFailTest()
        {
            var updateProductCommand = new UpdateProductCommand
            {
                Id = -1,
                Description = "test"
            };

            // TODO wrong HttpStatusCode api response => 405
            await UpdateProductExceptionAsync(updateProductCommand, HttpStatusCode.BadRequest);
        }

        #endregion
    }
}