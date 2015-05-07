using Driller.Logic.Interfaces.Comm;

namespace Driller.Logic.Interfaces.GamePlay
{
    public interface IGameService
    {
        IGameState StartNew();

        IMessageResponse Do(IMessageFromClient message);
    }
}