using System;
using Driller.Logic.Comm;
using Driller.Logic.GamePlay.Const;
using Driller.Logic.Interfaces.Comm;
using Driller.Logic.Interfaces.GamePlay;
using Driller.Logic.Interfaces.Settings;
using JetBrains.Annotations;

namespace Driller.Logic.GamePlay
{
    [UsedImplicitly]
    public class GameService : IGameService
    {
        private readonly IGameSettings _gameSettings;
        private readonly IGameState _gameState;

        public GameService(IGameState gameState, IGameSettings gameSettings)
        {
            _gameState = gameState;
            _gameSettings = gameSettings;
        }

        public IGameState StartNew()
        {
            IGameState gs = new GameState(_gameSettings);
            return gs;
        }

        public IMessageResponse Do(IMessageFromClient message)
        {
            IMessageResponse response;

            switch (message.ActionId)
            {
                case (int)SquareActionCode.DrillLandBuy:
                    response = BuyLand(message);
                    break;
                case (int)SquareActionCode.MarketPumpStationBuild:
                case (int)SquareActionCode.StorageBuild:
                case (int)SquareActionCode.PumpBuild:
                case (int)SquareActionCode.DrillBuild:
                    response = BuildStructure(message);
                    break;
                case (int)SquareActionCode.Drill:
                case (int)SquareActionCode.Pump:
                case (int)SquareActionCode.MarketSell:
                    response = PerformAction(message);
                    break;
                case (int)SquareActionCode.MarketPumpStationUprade:
                case (int)SquareActionCode.StorageCapacityUpgrade:
                case (int)SquareActionCode.StorageProcessingUpgrade:
                case (int)SquareActionCode.PumpUpgrade:
                    response = UpgradeStructure(message);
                    break;

                default:
                    response = ErrorResponse("Unknown ID");
                    break;
            }

            response.TimeLeftInSeconds = _gameState.TimeLeftSeconds;

            return response;
        }

        private IMessageResponse ErrorResponse(string message)
        {
            var response = new MessageResponse();
            response.Success = false;
            response.MessageFromServer = message;
            return response;
        }

        private IMessageResponse BuyLand(IMessageFromClient message)
        {
            var response = new MessageResponse();

            if (IsActionValidForBuy(message))
            {
                _gameState.SetSquareState(GetSquareType(message.SourceSquareName), GetSquareIndex(message.SourceSquareName), SquareStateCode.Owned);
                _gameState.Money -= 10000;

                response.Success = true;
                response.MoneyCost = 10000;
                response.StateCode = SquareStateCode.Available;
                response.StateCodeWhenDone = SquareStateCode.Owned;
                response.TimeCost = 1;
                response.MessageFromServer = "Buy Land";
                response.Money = _gameState.Money;
                response.CrudeOil = _gameState.CrudeOil;
            }
            else
            {
                response.Success = false;
                response.MessageFromServer = "Invalid Buy Action";
            }

            return response;
        }

        private IMessageResponse BuildStructure(IMessageFromClient message)
        {
            var response = new MessageResponse();

            if (IsActionValidForBuild(message))
            {
                _gameState.SetSquareState(GetSquareType(message.SourceSquareName), GetSquareIndex(message.SourceSquareName), SquareStateCode.Built);
                _gameState.Money -= 20000;

                response.Success = true;
                response.MoneyCost = 20000;
                response.StateCode = SquareStateCode.UnderConstruction;
                response.StateCodeWhenDone = SquareStateCode.Built;
                response.TimeCost = 2; 
                response.MessageFromServer = "Build Structure";
                response.Money = _gameState.Money;
                response.CrudeOil = _gameState.CrudeOil;
            }
            else
            {
                response.Success = false;
                response.MessageFromServer = "Invalid Build Action";
            }

            return response;
        }

        private IMessageResponse PerformAction(IMessageFromClient message)
        {
            var response = new MessageResponse();

            if (IsActionValidForAction(message))
            {
                _gameState.SetSquareState(GetSquareType(message.SourceSquareName), GetSquareIndex(message.SourceSquareName), SquareStateCode.Built);
                _gameState.Money -= 20000; // todo: extract costs 

                response.Success = true;
                response.MoneyCost = 20000;
                response.StateCode = SquareStateCode.Built;
                response.StateCodeWhenDone = SquareStateCode.Built;
                response.TimeCost = 3; // todo: extract costs 
                response.MessageFromServer = "Perform Action";
                response.Money = _gameState.Money;
                response.CrudeOil = _gameState.CrudeOil;
            }
            else
            {
                response.Success = false;
                response.MessageFromServer = "Invalid Action";
            }

            return response;
        }

        private IMessageResponse UpgradeStructure(IMessageFromClient message)
        {
            IMessageResponse response = new MessageResponse();

            if (IsActionValidForUpgrade(message))
            {
                _gameState.SetSquareState(GetSquareType(message.SourceSquareName), GetSquareIndex(message.SourceSquareName), SquareStateCode.Built);
                _gameState.Money -= 30000;

                response.Success = true;
                response.MoneyCost = 30000;
                response.StateCode = SquareStateCode.UnderUpgrade;
                response.StateCodeWhenDone = SquareStateCode.Built;
                response.TimeCost = 4;
                response.MessageFromServer = "Upgrade Structure";
                response.Money = _gameState.Money;
                response.CrudeOil = _gameState.CrudeOil;
            }
            else
            {
                response.Success = false;
                response.MessageFromServer = "Invalid Upgrade Action";
            }

            return response;
        }

        private bool IsActionValidForBuy(IMessageFromClient message)
        {
            //var squareType = GetSquareType(message.SourceSquareName);
            var squareState = GetSquareState(message.SourceSquareName);

            if (squareState == SquareStateCode.Available)
            {
                return true;
            }

            return false;
        }

        private bool IsActionValidForBuild(IMessageFromClient message)
        {
            //var squareType = GetSquareType(message.SourceSquareName);
            var squareState = GetSquareState(message.SourceSquareName);

            if (squareState == SquareStateCode.Owned)
            {
                return true;
            }

            return false;
        }

        private bool IsActionValidForAction(IMessageFromClient message)
        {
            //var squareType = GetSquareType(message.SourceSquareName);
            var squareState = GetSquareState(message.SourceSquareName);

            if (squareState == SquareStateCode.Built)
            {
                return true;
            }

            return false;
        }

        private bool IsActionValidForUpgrade(IMessageFromClient message)
        {
            //var squareType = GetSquareType(message.SourceSquareName);
            var squareState = GetSquareState(message.SourceSquareName);

            if (squareState == SquareStateCode.Built)
            {
                return true;
            }

            return false;
        }

        private SquareStateCode GetSquareState(string squareName)
        {
            SquareTypeCode squareType = GetSquareType(squareName);
            int squareIndex = GetSquareIndex(squareName);

            var squareDefinition = _gameState.GetSquareDefinition(squareType, squareIndex);

            return squareDefinition.State;
        }

        private int GetSquareIndex(string squareName)
        {
            var parts = squareName.Split('_');
            if (parts.Length == 2)
            {
                //var squareType = parts[0];
                var squareIndex = parts[1];

                return int.Parse(squareIndex);
            }

            return -1;
        }

        private SquareTypeCode GetSquareType(string squareName)
        {
            var parts = squareName.Split('_');
            if (parts.Length == 2)
            {
                var squareType = parts[0];

                if (squareType.StartsWith(SquareTypeCode.Drillable.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    return SquareTypeCode.Drillable;
                }

                if (squareType.StartsWith(SquareTypeCode.Pumpable.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    return SquareTypeCode.Drillable;
                }

                if (squareType.StartsWith(SquareTypeCode.Storage.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    return SquareTypeCode.Storage;
                }

                if (squareType.StartsWith(SquareTypeCode.Market.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    return SquareTypeCode.Market;
                }
            }

            return SquareTypeCode.Error;
        }
    }
}
