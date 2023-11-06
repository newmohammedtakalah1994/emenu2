using System.Threading.Tasks;

namespace emenu2.Data;

public interface Iemenu2DbSchemaMigrator
{
    Task MigrateAsync();
}
