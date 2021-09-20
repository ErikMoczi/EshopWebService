using AutoMapper;
using EshopWebService.Application.DTOs.Result;
using EshopWebService.Application.Handlers.Features.Product.Queries.GetAll;
using EshopWebService.Application.Handlers.Features.Product.Queries.GetAllPaged;
using EshopWebService.Application.Handlers.Features.Product.Queries.GetById;
using EshopWebService.Domain.Entities;

namespace EshopWebService.Application.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsPagedResponse, Product>().ReverseMap();
            CreateMap<PaginatedResultDto<GetAllProductsPagedResponse>, PaginatedResultDto<Product>>().ReverseMap();
        }
    }
}