using AutoMapper;
using Catalog.Application.Features.Requests.Queries.Products;
using Catalog.Application.Responses.Products;
using Catalog.Domain.Entities;
using Catalog.Application.Interfaces.Repositories;
using MediatR;

namespace Catalog.Application.Features.Handlers.Queries.Products;
internal class GetProductByIdQueryHandler(IMapper _mapper,
                                         IProductRepository _productRepository) : IRequestHandler<GetProductByIdQueryRequest, ProductResponse?>
{
    public async Task<ProductResponse?> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
    {
        Product? product =await _productRepository.GetEntityByIdAsync(request.Id);
        return _mapper.Map<ProductResponse>(product);
    }
}
