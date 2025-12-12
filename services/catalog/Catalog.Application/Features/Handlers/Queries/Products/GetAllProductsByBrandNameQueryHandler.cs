using AutoMapper;
using Catalog.Application.Features.Requests.Queries.Products;
using Catalog.Application.Responses.Products;
using Catalog.Application.Interfaces.Repositories;
using MediatR;

namespace Catalog.Application.Features.Handlers.Queries.Products;
public class GetAllProductsByBrandNameQueryHandler(
        IProductRepository _productRepository,
        IMapper _mapper
    ) : IRequestHandler<GetAllProductsByBrandNameQueryRequest, List<ProductResponse>>
{
    public async Task<List<ProductResponse>> Handle(GetAllProductsByBrandNameQueryRequest request, CancellationToken cancellationToken)
    {
        var products =await _productRepository.GetAllProductsByBrandNameAsync(request.BrandName);
        return _mapper.Map<List<ProductResponse>>(products);
    }
}
