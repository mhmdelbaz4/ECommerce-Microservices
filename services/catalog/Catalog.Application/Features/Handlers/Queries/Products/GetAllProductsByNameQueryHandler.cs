using AutoMapper;
using Catalog.Application.Features.Requests.Queries.Products;
using Catalog.Application.Responses.Products;
using Catalog.Application.Interfaces.Repositories;
using MediatR;

namespace Catalog.Application.Features.Handlers.Queries.Products;
public class GetAllProductsByNameQueryHandler(IMapper _mapper,
                                          IProductRepository _productRepository)
                                        : IRequestHandler<GetAllProductsByNameQueryRequest, List<ProductResponse>>
{
    public async Task<List<ProductResponse>> Handle(GetAllProductsByNameQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetAllProductsByNameAsyc(request.Name);
        return _mapper.Map<List<ProductResponse>>(result);
    }
}
