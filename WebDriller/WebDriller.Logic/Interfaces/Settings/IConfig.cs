namespace Driller.Logic.Interfaces.Settings
{
    public interface IConfig
    {
        string AppName { get; }
        string AzureApplicationKey { get; }
        string AzureServiceUri { get; }
    }
}