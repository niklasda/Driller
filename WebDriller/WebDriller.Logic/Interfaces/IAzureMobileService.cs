using System;
using Microsoft.WindowsAzure.MobileServices;

namespace Driller.Logic.Interfaces
{
    [CLSCompliant(false)]
    public interface IAzureMobileService
    {
        IMobileServiceClient Client { get; }
    }
}