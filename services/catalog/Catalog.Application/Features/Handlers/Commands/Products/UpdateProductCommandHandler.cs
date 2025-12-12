using AutoMapper;
using Catalog.Application.Features.Requests.Commands.Products;
using Catalog.Application.Interfaces.Repositories;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.Handlers.Commands.Products;

public class UpdateProductCommandHandler(
        IMapper _mapper,
        IProductRepository _productsRepository
    ) : IRequestHandler<UpdateProductCommandRequest>
{
    public async Task Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        Product product = _mapper.Map<Product>(request.ProductDto);
        await _productsRepository.Update(product);
    }
}
