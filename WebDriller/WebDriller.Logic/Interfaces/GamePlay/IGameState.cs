
using Driller.Logic.GamePlay.Const;

namespace Driller.Logic.Interfaces.GamePlay
{
    public interface IGameState
    {
        string SessionId { get; set; }
        
        int Money { get; set; }
        
        int CrudeOil { get; set; }
        
        int TimeLeftSeconds { get; }

        ISquareDefinition GetSquareDefinition(SquareTypeCode squareType, int x);

        void SetSquareState(SquareTypeCode squareType, int x, SquareStateCode squareState);
    }
}