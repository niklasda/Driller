using Driller.Logic.GamePlay.Const;

namespace Driller.Logic.Interfaces.Comm
{
    public interface IMessageResponse
    {
        int Id { get; set; }
        
        int TimeLeftInSeconds { get; set; }
        
        int Money { get; set; }
        
        int CrudeOil { get; set; }
        
        string MessageFromServer { get; set; }

        string StatusText { get; }
        
        bool Success { get; set; }
        
        int MoneyCost { get; set; }
        
        SquareStateCode StateCode { get; set; }
        
        SquareStateCode StateCodeWhenDone { get; set; }
        
        int TimeCost { get; set; }
    }
}