using System;
using Driller.Logic.GamePlay.Const;
using Driller.Logic.Interfaces.GamePlay;
using Driller.Logic.Interfaces.Settings;

namespace Driller.Logic.GamePlay
{
    public class GameState : IGameState
    {
        private readonly IGameSettings _gameSettings;
        private readonly ISquareDefinition[][] _squares;

        public GameState(IGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _squares = new ISquareDefinition[BoardConstants.BoardHeight][];
            _squares[BoardConstants.MarketSquareRowIndex] = new ISquareDefinition[BoardConstants.MarketSquareRowSize] { new MarketSquareDefinition(0), new MarketSquareDefinition(1), new MarketSquareDefinition(2), new MarketSquareDefinition(3) };
            _squares[BoardConstants.StorageSquareRowIndex] = new ISquareDefinition[BoardConstants.StorageSquareRowSize] { new StorageSquareDefinition(0), new StorageSquareDefinition(1), new StorageSquareDefinition(2) };
            _squares[BoardConstants.DrillableSquareRowIndex] = new ISquareDefinition[BoardConstants.DrillableSquareRowSize] { new DrillableSquareDefinition(0), new DrillableSquareDefinition(1), new DrillableSquareDefinition(2), new DrillableSquareDefinition(3) };

            StartTime = DateTime.Now;
            Money = 1000 * 1000;
            CrudeOil = 0;
        }

        public ISquareDefinition GetSquareDefinition(SquareTypeCode squareType, int x)
        {
            int y;
            if (squareType == SquareTypeCode.Market)
            {
                y = BoardConstants.MarketSquareRowIndex;
            } 
            else if (squareType == SquareTypeCode.Storage)
            {
                y = BoardConstants.StorageSquareRowIndex;
            }
            else if (squareType == SquareTypeCode.Pumpable || squareType == SquareTypeCode.Drillable)
            {
                y = BoardConstants.DrillableSquareRowIndex;                
            }
            else
            {
                return null;
            }

            ISquareDefinition sq;
            try
            {
                sq = _squares[y][x];
            }
            catch (Exception)
            {
                return null;
            }

            return sq;
        }

        public void SetSquareState(SquareTypeCode squareType, int x, SquareStateCode squareState)
        {

            int y;
            if (squareType == SquareTypeCode.Market)
            {
                y = BoardConstants.MarketSquareRowIndex;
            }
            else if (squareType == SquareTypeCode.Storage)
            {
                y = BoardConstants.StorageSquareRowIndex;
            }
            else if (squareType == SquareTypeCode.Pumpable || squareType == SquareTypeCode.Drillable)
            {
                y = BoardConstants.DrillableSquareRowIndex;
            }
            else
            {
                throw new Exception("Unknown square type");
            }

            _squares[y][x].State = squareState;
        }

        private DateTime StartTime { get; set; }

        public int TimeLeftSeconds { get { return (int) (_gameSettings.GameDuration - (DateTime.Now - StartTime).TotalSeconds); } }

        public int Money { get; set; }

        public int CrudeOil { get; set; }

        public string SessionId { get; set; }

    }
}