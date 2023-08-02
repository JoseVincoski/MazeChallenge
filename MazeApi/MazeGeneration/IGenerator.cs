using Domain;
using Domain.MazeGenerator;
using Domain.MazeGenerator.Enums;

namespace MazeGeneratorLib
{
    public interface IGenerator
    {
        public void GenerateMaze(ref Maze maze) { throw new NotImplementedException(); }

        public void GeneratePoints(ref Maze maze)
        {
            var startPosition = new MazePosition(1, 1);
            var targetPosition = new MazePosition(1, 1);

            Random rnd = new Random();
            while (targetPosition.IsEqual(startPosition))
            {
                targetPosition.Y = rnd.Next(maze.Height / 2) * 2 + 1;
                targetPosition.X = rnd.Next(maze.Width / 2) * 2 + 1;
            }

            maze.Tiles[startPosition.Y, startPosition.X] = (int)TileType.StartPoint;
            maze.Tiles[targetPosition.Y, targetPosition.X] = (int)TileType.TargetPoint;
        }

        public void GenerateBase(ref Maze maze)
        {
            for (int row = 0; row < maze.Height; row++)
            {
                for (int column = 0; column < maze.Width; column++)
                {
                    //Generate Frame
                    if (row == 0 || column == 0) maze.Tiles[row, column] = (int)TileType.BaseWall;
                    else if (row == maze.Height - 1 || column == maze.Width - 1) maze.Tiles[row, column] = (int)TileType.BaseWall;
                    //Generate inside base walls
                    else if (column.IsEven() && row.IsEven()) maze.Tiles[row, column] = (int)TileType.BaseWall;
                    else if (column.IsEven() || row.IsEven()) maze.Tiles[row, column] = (int)TileType.MovableWall;
                }
            }
        }
    }
}
