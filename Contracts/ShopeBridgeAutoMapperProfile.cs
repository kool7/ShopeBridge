using AutoMapper;
using ShopBridge.Contracts.Products;
using ShopBridge.Modals;

namespace ShopBridge.Contracts;

public class ShopeBridgeAutoMapperProfile : Profile
{
    public ShopeBridgeAutoMapperProfile()
    {
        CreateMap<Product, ReadProductDto>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
    }
}