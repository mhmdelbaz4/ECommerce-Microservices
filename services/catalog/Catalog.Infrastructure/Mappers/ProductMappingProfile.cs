using AutoMapper;
using Catalog.Application.Dtos.Product;
using Catalog.Application.Responses;
using Catalog.Application.Responses.Products;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Documents;

namespace Catalog.Infrastructure.Mappers
{
    public class ProductMappingProfile: Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDocument>().ReverseMap();
            CreateMap<Product,ProductResponse>().ReverseMap();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<PaginationReponse<ProductDocument>, PaginationReponse<Product>>().ReverseMap();
            CreateMap<PaginationReponse<Product>, PaginationReponse<ProductResponse>>().ReverseMap();



        }
    }
}
