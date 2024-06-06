using AutoMapper;
using eShopping.Catalog.Application.Products.Commands.Create;
using eShopping.Catalog.Application.Products.Commands.Update;
using eShopping.Catalog.Core.Entities.ProductAggregate;

namespace eShopping.Catalog.Application
{
    public class CatalogMappingProfile : Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<ProductBrand, ProductBrandDto>().ReverseMap();
            CreateMap<ProductType, ProductTypeDto>().ReverseMap();
        }
    }
}