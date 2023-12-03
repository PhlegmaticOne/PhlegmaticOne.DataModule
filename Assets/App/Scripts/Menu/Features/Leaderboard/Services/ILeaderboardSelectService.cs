using System.Collections.Generic;
using System.Threading.Tasks;

public interface ILeaderboadSelectService
{
    Task<IReadOnlyList<LeaderboardEntry>> SelectTopPlayersAsync(int count);
}