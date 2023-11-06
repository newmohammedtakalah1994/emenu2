using emenu2.Core.Models;
using emenu2.Controllers.Resources.Variants;

namespace emenu2.Mapping
{
    public class VariantProfile : AutoMapper.Profile
    {
        public VariantProfile()
        {
            CreateMap<CreateVariantRes, Variant>();

            CreateMap<UpdateVariantRes, Variant>();

            CreateMap<Variant, VariantRes>();


        }
    }
}
