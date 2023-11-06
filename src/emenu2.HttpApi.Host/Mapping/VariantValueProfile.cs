using emenu2.Core.Models;
using emenu2.Controllers.Resources.VariantValues;

namespace emenu2.Mapping
{
    public class VariantValueProfile : AutoMapper.Profile
    {
        public VariantValueProfile()
        {
            CreateMap<CreateVariantValueRes, VariantValue>();

            CreateMap<UpdateVariantValueRes, VariantValue>();

            CreateMap<VariantValue, VariantValueRes>();

        }
    }
}
