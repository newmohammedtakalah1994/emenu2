using emenu2.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace emenu2;

[DependsOn(
    typeof(emenu2EntityFrameworkCoreTestModule)
    )]
public class emenu2DomainTestModule : AbpModule
{

}
