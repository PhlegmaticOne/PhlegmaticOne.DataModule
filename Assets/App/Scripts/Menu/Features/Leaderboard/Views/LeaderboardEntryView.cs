using App.Scripts.Common.ViewModels;
using TMPro;
using UnityEngine;

public class LeaderboardEntryView : ViewModelListViewItem<LeaderboardEntry>
{
    [SerializeField] private TextMeshProUGUI _userNameText;
    [SerializeField] private TextMeshProUGUI _maxScoreText;

    public override void UpdateView(LeaderboardEntry leaderboardEntry)
    {
        _maxScoreText.text = leaderboardEntry.GlobalScore.ToString();
        _userNameText.text = leaderboardEntry.UserName;
    }
}
