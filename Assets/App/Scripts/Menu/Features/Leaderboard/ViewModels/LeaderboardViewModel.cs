using PhlegmaticOne.ViewModels.App.Modules.ViewModels.Collections;
using PhlegmaticOne.ViewModels.Contracts;
using System.Threading.Tasks;

public class LeaderboardViewModel : BaseViewModel
{
    private readonly ILeaderboadSelectService _leaderboadSelectService;

    public LeaderboardViewModel(ILeaderboadSelectService leaderboadSelectService)
    {
        _leaderboadSelectService=leaderboadSelectService;
        LeaderboardEntries = new ReactiveCollection<LeaderboardEntry>();
    }

    public ReactiveCollection<LeaderboardEntry> LeaderboardEntries { get; }

    public override async Task InitializeAsync()
    {
        var leaders = await _leaderboadSelectService.SelectTopPlayersAsync(10);
        LeaderboardEntries.Initialize(leaders);
    }
}
