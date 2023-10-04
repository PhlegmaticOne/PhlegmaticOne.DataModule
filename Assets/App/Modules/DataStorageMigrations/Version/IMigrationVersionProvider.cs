namespace PhlegmaticOne.DataStorageMigrations.Version {
    public interface IMigrationVersionProvider {
        int GetVersion();
        void SetVersion(int version);
        void ResetVersion();
    }
}