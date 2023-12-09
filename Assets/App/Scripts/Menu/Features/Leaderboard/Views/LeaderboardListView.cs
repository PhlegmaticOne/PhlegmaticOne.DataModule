using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Features.Leaderboard.ViewModels;
using UnityEngine;

namespace App.Scripts.Menu.Features.Leaderboard.Views
{
    public class LeaderboardListView : ViewModelListView<LeaderboardEntryViewModel, LeaderboardEntryView>
    {
        [SerializeField] private RectTransform _contentTransform;
        protected override RectTransform ContentTransform => _contentTransform;
    }
}