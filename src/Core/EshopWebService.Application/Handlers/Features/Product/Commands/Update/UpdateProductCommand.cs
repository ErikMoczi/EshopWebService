using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using EshopWebService.Application.DTOs.Result;
using EshopWebService.Application.Factories;
using EshopWebService.Application.Interfaces.Repositories;
using MediatR;

namespace EshopWebService.Application.Handlers.Features.Product.Commands.Update
{
    public class UpdateProductCommand : IRequest<IResultDto<int>>
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)] public string Description { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IResultDto<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProductRepository _productRepository;

            public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
            {
                _productRepository = Guard.Against.Null(productRepository, nameof(productRepository));
                _unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
            }

            public async Task<IResultDto<int>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(command.Id);
                if (product == null)
                {
                    throw ApiExceptionFactory.Throw("Product Not Found.");
                }

                product.Description = command.Description ?? product.Description;

                await _productRepository.UpdateAsync(product);

                await _unitOfWork.Commit(cancellationToken);

                return ResultDtoFactory.Success(product.Id);
            }
        }
    }
}