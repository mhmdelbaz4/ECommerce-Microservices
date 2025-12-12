using Catalog.Application.Dtos.Product;
using MediatR;

namespace Catalog.Application.Features.Requests.Commands.Products;
public class UpdateProductCommandRequest:IRequest
{
    public UpdateProductCommandRequest(UpdateProductDto dto)
    {
        ProductDto = dto;
    }
    public UpdateProductDto ProductDto { get; set; }
}
