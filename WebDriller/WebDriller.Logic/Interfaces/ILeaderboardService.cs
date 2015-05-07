using System.Collections.Generic;
using System.Threading.Tasks;
using Driller.Logic.DataModels;

namespace Driller.Logic.Interfaces
{
    public interface ILeaderboardService
    {
        Task<IList<HighScore>> GetLeaderboard();

        void SaveHighScore(HighScore score);
    }
}