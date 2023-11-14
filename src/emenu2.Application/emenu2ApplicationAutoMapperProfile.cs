using AutoMapper;
using emenu2.Application.Contracts.Resources;
using emenu2.Application.Contracts.Resources.Products;
using emenu2.Application.Contracts.Resources.ProductVariants;
using emenu2.Application.Contracts.Resources.Variants;
using emenu2.Application.Contracts.Resources.VariantValues;
using emenu2.Domain.Models;
 

namespace emenu2;

public class emenu2ApplicationAutoMapperProfile : Profile
{
    public emenu2ApplicationAutoMapperProfile()
    {
        CreateMap<CreateUpdateProductDto, Product>();

        CreateMap<Product, ProductDto>();

        CreateMap<ImageDto, Image>();
        CreateMap<Image, ImageDto>();


        CreateMap<CreateUpdateProductImageDto, ProductImage>();
        CreateMap<ProductImage, ProductImageDto>();



        CreateMap<CreateUpdateProductVariantInProductDto, ProductVariant>();

        CreateMap<CreateUpdateProductVariantDto, ProductVariant>();


        CreateMap<ProductVariant, ProductVariantResDto>();


        CreateMap<ProductDetails, ProductDetailsDto>();

        CreateMap<CreateUpdateProductDetailsDto, ProductDetails>();


        CreateMap<CreateProductVariantImageDto, ProductVariantImage>();
        CreateMap<ProductVariantImage, ProductVariantImageDto>();



        CreateMap<CreateUpdateVariantDto, Variant>();

        
        CreateMap<Variant, VariantDto>();


        CreateMap<CreateUpdateVariantValueDto, VariantValue>();

        CreateMap<VariantValue, VariantValueDto>();

        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
