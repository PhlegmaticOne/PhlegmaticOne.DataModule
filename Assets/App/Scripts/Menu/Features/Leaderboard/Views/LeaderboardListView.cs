using App.Scripts.Common.ViewModels;
using UnityEngine;

public class LeaderboardListView : ViewModelListView<LeaderboardEntry, LeaderboardEntryView>
{
    [SerializeField] private RectTransform _contentTransform;
    protected override RectTransform ContentTransform => _contentTransform;
}