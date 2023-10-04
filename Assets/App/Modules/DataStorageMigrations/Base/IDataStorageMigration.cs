using System.Threading;
using System.Threading.Tasks;

namespace PhlegmaticOne.DataStorageMigrations.Base {
    public interface IDataStorageMigration {
        bool IsMigrationAvailable { get; }
        Task MigrateAsync(CancellationToken ct = default);
    }
}