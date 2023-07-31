using Domain.MazeGenerator;
using Domain.MazeGenerator.Enums;

namespace Domain.MazeGenerator.MazeGenV2Models
{
    public class TileInfo
    {
        public TileType TileType { get; set; }
        public TileDirection Direction { get; set; }
        public MazePosition Position { get; set; }
    }
}
