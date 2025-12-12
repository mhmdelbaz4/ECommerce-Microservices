using AutoMapper;
using Catalog.Application.Features.Requests.Commands.Products;
using Catalog.Application.Interfaces.Repositories;
using Entities = Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.Handlers.Commands.Products;
public class CreateProductCommandHandler(IMapper _mapper,
                                        IProductRepository _productRepository)
                                : IRequestHandler<CreateProductCommandRequest>
{
    public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        Entities.Product product = _mapper.Map<Entities.Product>(request.ProductDto);
        await _productRepository.Add(product);
    }
}
