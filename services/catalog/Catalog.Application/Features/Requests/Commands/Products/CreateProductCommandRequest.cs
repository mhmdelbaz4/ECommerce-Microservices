using Catalog.Application.Dtos.Product;
using MediatR;

namespace Catalog.Application.Features.Requests.Commands.Products;
public class CreateProductCommandRequest : IRequest
{
    public CreateProductCommandRequest(CreateProductDto dto)
    {
        ProductDto = dto;
    }
    public CreateProductDto ProductDto { get; set; }
}
