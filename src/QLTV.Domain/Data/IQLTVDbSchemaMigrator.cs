using System.Threading.Tasks;

namespace QLTV.Data
{
    public interface IQLTVDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
