using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Features.Leaderboard.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Menu.Features.Leaderboard.Views
{
    public class LeaderboardEntryView : ViewModelListViewItem<LeaderboardEntryViewModel>
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private TextMeshProUGUI _userNameText;
        [SerializeField] private TextMeshProUGUI _maxScoreText;
        [SerializeField] private ViewModelCommandButton _showStatisticsButton;

        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _currentUserColor;

        public override void UpdateView(LeaderboardEntryViewModel leaderboardEntryViewModel)
        {
            var color = leaderboardEntryViewModel.IsCurrentUser ? _currentUserColor : _defaultColor;
            _maxScoreText.text = leaderboardEntryViewModel.GlobalScore.ToString();
            _userNameText.text = leaderboardEntryViewModel.UserName;
            _backgroundImage.color = color;
            _showStatisticsButton.Setup(leaderboardEntryViewModel.ShowStatisticsCommand);
        }

        public override void OnReset()
        {
            _showStatisticsButton.Dispose();
            base.OnReset();
        }
    }
}
