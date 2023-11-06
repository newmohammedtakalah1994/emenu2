using emenu2.Core.Models;
using emenu2.Controllers.Resources.ProductVariants;

namespace emenu2.Mapping
{
    public class ProductVariantProfile : AutoMapper.Profile
    {
        public ProductVariantProfile()
        {
            CreateMap<CreateProductVariantRes, ProductVariant>();

            CreateMap<UpdateProductVariantRes, ProductVariant>();

            CreateMap<ProductVariant, ProductVariantRes>();


            CreateMap<ProductDetails, ProductDetailsRes>();

            CreateMap<CreateProductDetailsRes, ProductDetails>();


            CreateMap<CreateProductVariantImageRes, ProductVariantImage>();
            CreateMap<ProductVariantImage, ProductVariantImageRes>();


        }
    }
}
