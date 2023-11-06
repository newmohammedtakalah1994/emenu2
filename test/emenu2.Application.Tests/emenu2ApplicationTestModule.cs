using Volo.Abp.Modularity;

namespace emenu2;

[DependsOn(
    typeof(emenu2ApplicationModule),
    typeof(emenu2DomainTestModule)
    )]
public class emenu2ApplicationTestModule : AbpModule
{

}
