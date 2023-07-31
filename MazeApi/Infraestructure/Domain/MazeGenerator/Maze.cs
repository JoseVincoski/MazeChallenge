using Domain.MazeGenerator.Enums;

namespace Domain.MazeGenerator
{
    public class Maze
    {
        public int[,] Tiles { get; set; }
        public MazePosition StartPosition { get; set; }
        public MazePosition TargetPosition { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }

        public TileType GetTileTypeInPosition(int y, int x)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return TileType.OutsideFrame;

            var mazePosition = new MazePosition(y, x);

            if (mazePosition.IsEqual(StartPosition)) return TileType.Start;
            else if (mazePosition.IsEqual(TargetPosition)) return TileType.Target;

            else return (TileType)Tiles[y, x];
        }

        public TilesAround GetTilesTypeAroundPosition(int y, int x)
        {
            return new TilesAround()
            {
                NTile = GetTileTypeInPosition(y - 1, x),
                ETile = GetTileTypeInPosition(y, x + 1),
                STile = GetTileTypeInPosition(y + 1, x),
                WTile = GetTileTypeInPosition(y, x - 1),
            };
        }

        public Maze(int _mazeHeight, int _mazeWidth)
        {
            Height = _mazeHeight * 3;
            Width = _mazeWidth * 3;

            Tiles = new int[Height, Width];
        }
    }
}
