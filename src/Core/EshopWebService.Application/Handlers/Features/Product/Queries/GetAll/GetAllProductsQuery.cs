using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using EshopWebService.Application.DTOs.Result;
using EshopWebService.Application.Factories;
using EshopWebService.Application.Interfaces.Repositories;
using MediatR;

namespace EshopWebService.Application.Handlers.Features.Product.Queries.GetAll
{
    public class GetAllProductsQuery : IRequest<IResultDto<List<GetAllProductsResponse>>>
    {
        public class GetAllProductsCachedQueryHandler : IRequestHandler<GetAllProductsQuery, IResultDto<List<GetAllProductsResponse>>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetAllProductsCachedQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = Guard.Against.Null(productRepository, nameof(productRepository));
                _mapper = Guard.Against.Null(mapper, nameof(mapper));
            }

            public async Task<IResultDto<List<GetAllProductsResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var productList = await _productRepository.GetAsync();
                var mappedProducts = _mapper.Map<List<GetAllProductsResponse>>(productList);
                return ResultDtoFactory.Success(mappedProducts);
            }
        }
    }
}