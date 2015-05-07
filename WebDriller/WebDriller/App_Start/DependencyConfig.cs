using Driller.Azure.Services;
using Driller.Logic.DataModels;
using Driller.Logic.GamePlay;
using Driller.Logic.Interfaces;
using Driller.Logic.Interfaces.GamePlay;
using Driller.Logic.Interfaces.Settings;
using Driller.Logic.Interfaces.ViewModels;
using Driller.Logic.Settings;
using Driller.ViewModels;
using StructureMap;

namespace Driller
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            // configuration container
            ObjectFactory.Initialize(x =>
            {
                x.For<IConfig>().Singleton().Use<Config>();
                x.For<IGameSettings>().Singleton().Use<GameSettings>();

                x.For<IGameState>().Singleton().Use<GameState>().Ctor<IGameSettings>().Is<GameSettings>();

                // data models
                x.For<IHighScore>().Use<HighScore>();

                // view models
                x.For<IErrorViewModel>().Use<ErrorViewModel>().Ctor<IConfig>().Is<Config>();
                x.For<IStartViewModel>().Use<StartViewModel>().Ctor<IConfig>().Is<Config>();
                x.For<IAboutViewModel>().Use<AboutViewModel>().Ctor<IConfig>().Is<Config>();
                x.For<IHelpViewModel>().Use<HelpViewModel>().Ctor<IConfig>().Is<Config>();
                x.For<IPlayViewModel>().Use<PlayViewModel>().Ctor<IConfig>().Is<Config>();
                x.For<ILeaderboardViewModel>().Use<LeaderboardViewModel>().Ctor<IConfig>().Is<Config>();

                // services
                x.For<IAzureMobileService>().Use<AzureMobileService>().Ctor<IConfig>().Is<Config>();
                x.For<ILeaderboardService>().Use<LeaderboardService>().Ctor<IAzureMobileService>().Is<AzureMobileService>();
                x.For<IGameService>().Use<GameService>().Ctor<IGameState>().Is<GameState>().Ctor<IGameSettings>().Is<GameSettings>();

            });
        }
    }
}
