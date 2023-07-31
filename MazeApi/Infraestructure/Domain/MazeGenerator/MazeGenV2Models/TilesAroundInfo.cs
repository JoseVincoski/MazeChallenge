using Domain.MazeGenerator.Enums;

namespace Domain.MazeGenerator.MazeGenV2Models
{
    public class TilesAroundInfo
    {
        private MazePosition basePosition;
        private Maze maze;

        public List<TileInfo> TileInfos = new List<TileInfo>();

        public List<TileInfo> MovableWalls { get { UpdateTiles(); return GetTileType(TileType.MovableWall); } }

        public TilesAroundInfo(Maze maze, int Y, int X)
        {
            basePosition = new MazePosition(Y, X);
            this.maze = maze;

            UpdateTiles();
        }
        private List<TileInfo> GetTileType(TileType tileType)
        {
            return TileInfos.FindAll(x => x.TileType == tileType);
        }

        private void UpdateTiles()
        {
            TileInfos.Clear();
            TileInfos.Add(new TileInfo()
            {
                Position = new MazePosition(basePosition.Y - 1, basePosition.X),
                TileType = maze.GetTileTypeInPosition(basePosition.Y - 1, basePosition.X),
                Direction = TileDirection.N,
            });

            TileInfos.Add(new TileInfo()
            {
                Position = new MazePosition(basePosition.Y, basePosition.X + 1),
                TileType = maze.GetTileTypeInPosition(basePosition.Y, basePosition.X + 1),
                Direction = TileDirection.E,
            });

            TileInfos.Add(new TileInfo()
            {
                Position = new MazePosition(basePosition.Y + 1, basePosition.X),
                TileType = maze.GetTileTypeInPosition(basePosition.Y + 1, basePosition.X),
                Direction = TileDirection.S,
            });

            TileInfos.Add(new TileInfo()
            {
                Position = new MazePosition(basePosition.Y, basePosition.X - 1),
                TileType = maze.GetTileTypeInPosition(basePosition.Y, basePosition.X - 1),
                Direction = TileDirection.W,
            });
        }
    }
}
