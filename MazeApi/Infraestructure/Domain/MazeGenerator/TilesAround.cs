using Domain.MazeGenerator.Enums;

namespace Domain.MazeGenerator
{
    public class TilesAround
    {
        public TileType NTile;
        public TileType ETile;
        public TileType STile;
        public TileType WTile;
        public readonly int MovableWallsCount;
    }
}
