namespace Driller.Logic.GamePlay.Const
{
    public enum SquareStateCode
    {
        /* should be in sync with javascript */

        // todo: might need buying state
        Available = 1000,
        Owned,
        UnderConstruction,
        Built,
        UnderUpgrade
    }
}