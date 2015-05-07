using Driller.Logic.Interfaces.Settings;
using JetBrains.Annotations;

namespace Driller.Logic.Settings
{
    [UsedImplicitly]
    public class GameSettings : IGameSettings
    {
        public int GameDuration
        {
            get { return 60 * 10; }
        }
    }
}