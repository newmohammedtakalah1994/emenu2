using AutoMapper;
using emenu2.Application.Contracts.Resources;
using emenu2.Application.Contracts.Resources.Products;
using emenu2.Application.Contracts.Resources.ProductVariants;
using emenu2.Application.Contracts.Resources.Variants;
using emenu2.Application.Contracts.Resources.VariantValues;
using emenu2.Domain.Models;
using emenu2.Domain.Queries;

namespace emenu2;

public class emenu2ApplicationAutoMapperProfile : Profile
{
    public emenu2ApplicationAutoMapperProfile()
    {
        CreateMap<CreateProductRes, Product>();

        CreateMap<UpdateProductRes, Product>();

        CreateMap<Product, ProductRes>();

        CreateMap<ImageRes, Image>();
        CreateMap<Image, ImageRes>();


        CreateMap<CreateProductImageRes, ProductImage>();
        CreateMap<ProductImage, ProductImageRes>();



        CreateMap<CreateProductVariantRes, ProductVariant>();

        CreateMap<UpdateProductVariantRes, ProductVariant>();

        CreateMap<ProductVariant, ProductVariantRes>();


        CreateMap<ProductDetails, ProductDetailsRes>();

        CreateMap<CreateProductDetailsRes, ProductDetails>();


        CreateMap<CreateProductVariantImageRes, ProductVariantImage>();
        CreateMap<ProductVariantImage, ProductVariantImageRes>();



        CreateMap<CreateVariantRes, Variant>();

        CreateMap<UpdateVariantRes, Variant>();

        CreateMap<Variant, VariantRes>();


        CreateMap<PagingInfoRes, PagingInfo>();
        CreateMap<PagingInfo, PagingInfoRes>();

        



        CreateMap<CreateVariantValueRes, VariantValue>();

        CreateMap<UpdateVariantValueRes, VariantValue>();

        CreateMap<VariantValue, VariantValueRes>();

        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
