using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Driller.Logic.DataModels;
using Driller.Logic.Interfaces;
using Microsoft.WindowsAzure.MobileServices;

namespace Driller.Azure.Services
{
    [CLSCompliant(false)]
    public class LeaderboardService : ILeaderboardService
    {
        private readonly IMobileServiceClient _client;

        public LeaderboardService(IAzureMobileService azure)
        {
            _client = azure.Client;
        }

        public async Task<IList<HighScore>> GetLeaderboard()
        {
            IMobileServiceTable<HighScore> hs = _client.GetTable<HighScore>();

            IList<HighScore> b = await hs.ToListAsync();
            
            return b;
        }

        public void SaveHighScore(HighScore score)
        {
            IMobileServiceTable<HighScore> hs = _client.GetTable<HighScore>();

            hs.InsertAsync(score);
        }
    }
}