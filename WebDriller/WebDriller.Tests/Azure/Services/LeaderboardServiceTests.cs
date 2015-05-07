using System.Collections.Generic;
using System.Threading.Tasks;
using Driller.Azure.Services;
using Driller.Logic.DataModels;
using Driller.Logic.Interfaces;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Driller.Tests.Azure.Services
{
    [TestClass]
    public class LeaderboardTests
    {
        [TestMethod]
        public void TestGetLeaderboard()
        {
            var azure = A.Fake<IAzureMobileService>();
            ILeaderboardService svc = new LeaderboardService(azure);
            
            Task<IList<HighScore>> leaderboard = svc.GetLeaderboard();

            Assert.IsNotNull(leaderboard);
        }
    }
}
