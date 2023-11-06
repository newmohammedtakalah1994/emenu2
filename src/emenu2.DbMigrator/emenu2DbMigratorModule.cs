using emenu2.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace emenu2.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(emenu2EntityFrameworkCoreModule),
    typeof(emenu2ApplicationContractsModule)
    )]
public class emenu2DbMigratorModule : AbpModule
{
}
