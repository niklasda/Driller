namespace Driller.Logic.Interfaces.Comm
{
    public interface IMessageFromClient
    {
        string SourceSquareName { get; set; }

        int ActionId { get; set; }
    }
}