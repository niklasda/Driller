using Driller.Logic.Interfaces;
using JetBrains.Annotations;

namespace Driller.Logic.DataModels
{
    [UsedImplicitly] public class HighScore : IHighScore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int Game { get; set; } 
    }
}