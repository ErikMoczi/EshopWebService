using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using EshopWebService.Application.DTOs.Result;
using EshopWebService.Application.Interfaces.Repositories;
using MediatR;

namespace EshopWebService.Application.Handlers.Features.Product.Queries.GetAllPaged
{
    public class GetAllProductsPagedQuery : IRequest<IPaginatedResultDto<GetAllProductsPagedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllProductsPagedQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public class GetAllProductsPagedQueryHandler : IRequestHandler<GetAllProductsPagedQuery, IPaginatedResultDto<GetAllProductsPagedResponse>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetAllProductsPagedQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = Guard.Against.Null(productRepository, nameof(productRepository));
                _mapper = Guard.Against.Null(mapper, nameof(mapper));
            }

            public async Task<IPaginatedResultDto<GetAllProductsPagedResponse>> Handle(GetAllProductsPagedQuery request, CancellationToken cancellationToken)
            {
                var paginatedResultDto = await _productRepository.GetAsync(request.PageNumber, request.PageSize);
                var mappedPaginatedResultDto = _mapper.Map<PaginatedResultDto<GetAllProductsPagedResponse>>(paginatedResultDto);
                return mappedPaginatedResultDto;
            }
        }
    }
}