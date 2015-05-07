using Driller.Logic.GamePlay.Const;
using Driller.Logic.Interfaces.GamePlay;

namespace Driller.Logic.GamePlay
{
    public abstract class SquareDefinitionBase : ISquareDefinition
    {
        protected SquareDefinitionBase(int columnIndex)
        {
            ColumnIndex = columnIndex;
            State = SquareStateCode.Available;
        }

        public int ColumnIndex { get; private set; }

        public SquareStateCode State { get; set; }
    }
}