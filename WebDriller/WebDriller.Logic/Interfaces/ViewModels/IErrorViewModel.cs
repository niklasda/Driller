namespace Driller.Logic.Interfaces.ViewModels
{
    public interface IErrorViewModel : IBaseViewModel
    {
        string Message { get; set; }
    }
}