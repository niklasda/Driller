using Driller.Logic.Interfaces.GamePlay;

namespace Driller.Logic.GamePlay
{
    public class StorageSquareDefinition : SquareDefinitionBase, ISquareDefinition
    {
        public StorageSquareDefinition(int columnIndex)
            : base(columnIndex)
        {
        }
    }
}