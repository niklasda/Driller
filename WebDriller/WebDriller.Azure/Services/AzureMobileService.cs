using System;
using Driller.Logic.Interfaces;
using Driller.Logic.Interfaces.Settings;
using JetBrains.Annotations;
using Microsoft.WindowsAzure.MobileServices;

namespace Driller.Azure.Services
{
    [CLSCompliant(false)]
    [UsedImplicitly]
    public class AzureMobileService : IAzureMobileService
    {
        private readonly IMobileServiceClient _client;

        public AzureMobileService(IConfig config)
        {
            _client = new MobileServiceClient(config.AzureServiceUri, config.AzureApplicationKey);
        }

        public IMobileServiceClient Client { get { return _client; } }

    }
}