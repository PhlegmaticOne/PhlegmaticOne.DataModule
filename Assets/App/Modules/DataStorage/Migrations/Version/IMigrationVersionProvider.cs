namespace PhlegmaticOne.DataStorage.Migrations.Version {
    public interface IMigrationVersionProvider {
        int GetVersion();
        void SetVersion(int version);
        void ResetVersion();
    }
}