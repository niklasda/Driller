using Driller.Logic.GamePlay.Const;
using Driller.Logic.Interfaces.Comm;

namespace Driller.Logic.Comm
{
    public class MessageResponse : IMessageResponse
    {
        public int Id { get; set; }

        public int TimeLeftInSeconds { get; set; }
        
        public int Money { get; set; }
        
        public int CrudeOil { get; set; }
        
        public string MessageFromServer { get; set; }
        
        public string StatusText { get { return string.Format("${0} - Oil: {1} bbl - {2}", Money, CrudeOil, MessageFromServer); } }

        public bool Success { get; set; }
        
        public int MoneyCost { get; set; }
        
        public SquareStateCode StateCode { get; set; }
        
        public SquareStateCode StateCodeWhenDone { get; set; }
        
        public int TimeCost { get; set; }
    }
}