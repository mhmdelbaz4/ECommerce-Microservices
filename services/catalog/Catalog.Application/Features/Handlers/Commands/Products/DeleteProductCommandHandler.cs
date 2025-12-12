using AutoMapper;
using Catalog.Application.Features.Requests.Commands.Products;
using Catalog.Domain.Entities;
using Catalog.Application.Interfaces.Repositories;
using MediatR;

namespace Catalog.Application.Features.Handlers.Commands.Products;
public class DeleteProductCommandHandler(IMapper _mapper,
                                        IProductRepository _productRepository) : IRequestHandler<DeleteProductCommandRequest>
{
    public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _productRepository.Delete(request.ProductId);
    }
}
