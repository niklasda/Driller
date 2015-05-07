using Driller.Logic.GamePlay.Const;

namespace Driller.Logic.Interfaces.GamePlay
{
    public interface ISquareDefinition
    {
        int ColumnIndex { get; }

        SquareStateCode State { get; set; }
    }
}