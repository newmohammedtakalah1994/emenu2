using emenu2.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace emenu2
{
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class MyModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MyModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MyModule>();
                options.AddProfile<ProductProfile>();

            });
        }
    }

}
