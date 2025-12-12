using MediatR;

namespace Catalog.Application.Features.Requests.Commands.Products;
public class DeleteProductCommandRequest: IRequest
{
    public DeleteProductCommandRequest(string id)
    {
        ProductId = id;
    }
    public string ProductId { get; set; }
}
