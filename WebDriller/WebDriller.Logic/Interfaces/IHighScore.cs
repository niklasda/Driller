namespace Driller.Logic.Interfaces
{
    public interface IHighScore
    {
        int Id { get; set; }
        string Name { get; set; }
        int Score { get; set; }
        int Game { get; set; }
    }
}