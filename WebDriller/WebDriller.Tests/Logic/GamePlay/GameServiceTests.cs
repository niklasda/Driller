using Driller.Logic.Comm;
using Driller.Logic.GamePlay;
using Driller.Logic.GamePlay.Const;
using Driller.Logic.Interfaces.Comm;
using Driller.Logic.Interfaces.GamePlay;
using Driller.Logic.Interfaces.Settings;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Driller.Tests.Logic.GamePlay
{
    [TestClass]
    public class GameServiceTests
    {
        [TestMethod]
        public void TestDoWithUnknownActionId()
        {
            var state = A.Fake<IGameState>();
            var settings = A.Fake<IGameSettings>();
            IGameService svc = new GameService(state, settings);

            IMessageFromClient message = new MessageFromClient();
            message.ActionId = -1;
            message.SourceSquareName = "asdasd0";

            IMessageResponse response = svc.Do(message);

            Assert.IsFalse(response.Success);
        }

        [TestMethod]
        public void TestDoWithKnownActionId()
        {
            var state = A.Fake<IGameState>();
            var settings = A.Fake<IGameSettings>();

            var squareDefinition = A.Fake<ISquareDefinition>();
            A.CallTo(() => squareDefinition.State).Returns(SquareStateCode.Available);

            A.CallTo(() => state.GetSquareDefinition(SquareTypeCode.Drillable, 0)).Returns(squareDefinition);
            IGameService svc = new GameService(state, settings);

            IMessageFromClient message = new MessageFromClient();
            message.ActionId = (int)SquareActionCode.DrillLandBuy;
            message.SourceSquareName = "drillableSquare_0";

            IMessageResponse response = svc.Do(message);

            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void TestDoWithInvalidActionId()
        {
            var state = A.Fake<IGameState>();
            var settings = A.Fake<IGameSettings>();
            IGameService svc = new GameService(state, settings);

            IMessageFromClient message = new MessageFromClient();
            message.ActionId = (int)SquareActionCode.Drill;
            message.SourceSquareName = "asdasd0";

            IMessageResponse response = svc.Do(message);

            Assert.IsFalse(response.Success);
        }
    }
}
