namespace Domain.MazeGenerator.Enums
{
    public enum TileType
    {
        Path = 0,
        VerifiedPath = 1,
        
        BaseWall = 2,
        MovableWall = 3,
        SolidWall = 4,

        StartPoint = 5,
        TargetPoint = 6,

        OutsideFrame = 7,
    }
}