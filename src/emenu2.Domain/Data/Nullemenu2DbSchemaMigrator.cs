using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace emenu2.Data;

/* This is used if database provider does't define
 * Iemenu2DbSchemaMigrator implementation.
 */
public class Nullemenu2DbSchemaMigrator : Iemenu2DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
