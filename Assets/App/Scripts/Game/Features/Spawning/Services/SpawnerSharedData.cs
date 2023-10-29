namespace App.Scripts.Game.Features.Spawning.Services {
    public class SpawnerSharedData : ISpawnerSharedData {
        public SpawnerSharedData() {
            Data = new SpawnerData();
            Remote = new SpawnerData();
        }
        
        public SpawnerData Data { get; }
        public SpawnerData Remote { get; }
    }
}