using System.Threading.Tasks;
using App.Scripts.Menu.Features.Statistics.Models;
using Firebase.Database;
using Newtonsoft.Json;

namespace App.Scripts.Menu.Features.Statistics.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly FirebaseDatabase _database;
        public StatisticsService()
        {
            _database = FirebaseDatabase.DefaultInstance;
        }
        
        public async Task<StatisticsModel> LoadStatisticsAsync(string userId)
        {
            var value = await _database.RootReference
                .Child("users")
                .Child(userId)
                .Child(nameof(StatisticsModel))
                .GetValueAsync();

            var json = value.GetRawJsonValue();
            return JsonConvert.DeserializeObject<StatisticsModel>(json);
        }
    }
}