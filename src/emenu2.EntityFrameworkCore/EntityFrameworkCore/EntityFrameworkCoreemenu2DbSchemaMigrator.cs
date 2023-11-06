using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using emenu2.Data;
using Volo.Abp.DependencyInjection;

namespace emenu2.EntityFrameworkCore;

public class EntityFrameworkCoreemenu2DbSchemaMigrator
    : Iemenu2DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreemenu2DbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the emenu2DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<emenu2DbContext>()
            .Database
            .MigrateAsync();
    }
}
