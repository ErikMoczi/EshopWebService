using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EshopWebService.Api;
using EshopWebService.IntegrationTests.Core.StartUp;
using Xunit;

namespace EshopWebService.IntegrationTests.Cases.PublicApi.Product
{
    public class GetProductTests : BaseProductTests
    {
        public GetProductTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        #region GetProductById

        [Fact]
        public async Task GetByIdSuccessTest()
        {
            await GetProductById(1);
        }

        [Fact]
        public async Task GetByIdFailedTest()
        {
            await GetProductByIdExceptionAsync(-1, HttpStatusCode.BadRequest);
        }

        #endregion

        #region GetAll

        [Fact]
        public async Task GetAllTest()
        {
            var inputProducts = GetInputData();
            var resultProducts = await CallWithResponseDtoOkAsync(
                GetProductPublicApiV1Client,
                client => client.GetAllAsync()
            );

            Assert.Equal(inputProducts.Count, resultProducts.Count);
            for (var i = 0; i < inputProducts.Count; i++)
            {
                Assert.Equal(inputProducts[i].Id, resultProducts[i].Id);
                Assert.Equal(inputProducts[i].Name, resultProducts[i].Name);
                Assert.Equal(inputProducts[i].Description, resultProducts[i].Description);
                Assert.Equal(inputProducts[i].ImgUri, resultProducts[i].ImgUri);
                Assert.Equal(inputProducts[i].Price, resultProducts[i].Price);
            }
        }

        #endregion

        #region GetAllPaged

        [Fact]
        public async Task GetAllPagedTest()
        {
            var pageNumber = 0;
            var pageSize = 2;

            var inputProducts = GetInputData().Take(pageSize).ToList();
            var resultProducts = await CallWithResponseDtoOkAsync(
                GetProductPublicApiV2Client,
                client => client.GetAllPagedAsync(pageNumber, pageSize)
            );

            Assert.Equal(inputProducts.Count, resultProducts.Count);
            for (var i = 0; i < inputProducts.Count; i++)
            {
                Assert.Equal(inputProducts[i].Id, resultProducts[i].Id);
                Assert.Equal(inputProducts[i].Name, resultProducts[i].Name);
                Assert.Equal(inputProducts[i].Description, resultProducts[i].Description);
                Assert.Equal(inputProducts[i].ImgUri, resultProducts[i].ImgUri);
                Assert.Equal(inputProducts[i].Price, resultProducts[i].Price);
            }
        }

        #endregion
    }
}