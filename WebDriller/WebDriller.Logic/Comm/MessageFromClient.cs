using Driller.Logic.Interfaces.Comm;

namespace Driller.Logic.Comm
{
    public class MessageFromClient : IMessageFromClient
    {
        public string SourceSquareName { get; set; }
       
        public int ActionId { get; set; }
    }
}