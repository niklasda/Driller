using Driller.Logic.Interfaces.GamePlay;

namespace Driller.Logic.GamePlay
{
    public class DrillableSquareDefinition : SquareDefinitionBase, ISquareDefinition
    {
        public DrillableSquareDefinition(int columnIndex)
            : base(columnIndex)
        {
        }
    }
}