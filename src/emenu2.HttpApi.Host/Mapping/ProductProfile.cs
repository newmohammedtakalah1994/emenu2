using emenu2.Core.Models;
using Volo.Abp.AutoMapper;
using emenu2.Controllers.Resources.Products;
using emenu2.Controllers.Resources;
using emenu2.Controllers.Resources.ProductVariants;
using emenu2.Controllers.Resources.Variants;
using emenu2.Controllers.Resources.VariantValues;

namespace emenu2.Mapping
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
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




            CreateMap<CreateVariantValueRes, VariantValue>();

            CreateMap<UpdateVariantValueRes, VariantValue>();

            CreateMap<VariantValue, VariantValueRes>();

        }
    }
}
