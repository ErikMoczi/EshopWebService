using System.Threading.Tasks;
using EshopWebService.Api.Controllers.Abstractions;
using EshopWebService.Application.Handlers.Features.Product.Commands.Update;
using EshopWebService.Application.Handlers.Features.Product.Queries.GetAll;
using EshopWebService.Application.Handlers.Features.Product.Queries.GetAllPaged;
using EshopWebService.Application.Handlers.Features.Product.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace EshopWebService.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class ProductController : BaseApiController<ProductController>
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetProductByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize = 10)
        {
            var result = await Mediator.Send(new GetAllProductsPagedQuery(pageNumber, pageSize));
            return Ok(result);
        }

        [HttpPut]
        // TODO authorization
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}