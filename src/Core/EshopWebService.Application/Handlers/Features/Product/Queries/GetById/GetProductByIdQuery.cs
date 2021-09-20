using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using EshopWebService.Application.DTOs.Result;
using EshopWebService.Application.Factories;
using EshopWebService.Application.Interfaces.Repositories;
using MediatR;

namespace EshopWebService.Application.Handlers.Features.Product.Queries.GetById
{
    public class GetProductByIdQuery : IRequest<IResultDto<GetProductByIdResponse>>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, IResultDto<GetProductByIdResponse>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = Guard.Against.Null(productRepository, nameof(productRepository));
                _mapper = Guard.Against.Null(mapper, nameof(mapper));
            }

            public async Task<IResultDto<GetProductByIdResponse>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(query.Id);
                var mappedProduct = _mapper.Map<GetProductByIdResponse>(product);
                return ResultDtoFactory.Success(mappedProduct);
            }
        }
    }
}