using UnityEngine;

namespace Assets.App.Scripts.Menu.Features.Leaderboard.Configs
{
    [CreateAssetMenu(fileName = "LeaderboardConfig", menuName = "Menu/Features/Leaderboard/Config")]
    public class LeaderboardConfig : ScriptableObject
    {
        [SerializeField] private int _leadersCountToShow;

        public int LeadersCountToShow => _leadersCountToShow;
    }
}
