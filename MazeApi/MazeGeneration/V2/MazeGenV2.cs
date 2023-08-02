using Domain;
using Domain.MazeGenerator;
using Domain.MazeGenerator.Enums;
using Domain.MazeGenerator.MazeGenV2Models;

namespace MazeGeneratorLib.V2
{
    public class MazeGenV2 : IGenerator
    {
        private readonly Random rnd;
        public MazeGenV2(int? seed)
        {
            if (seed != null) rnd = new Random((int)seed);
            else rnd = new Random((int)DateTime.Now.Ticks);
        }

        public MazeGenV2()
        {
            rnd = new Random((int)DateTime.Now.Ticks);
        }

        public void GenerateMaze(ref Maze maze)
        {
            for (int row = 1; row < maze.Height; row += 2)
            {
                for (int column = 1; column < maze.Width; column += 2)
                {
                    var tilesAroundInfo = new TilesAroundInfo(maze, row, column);

                    if (tilesAroundInfo.MovableWalls.Count > 1)
                    {
                        var numberOfWallsToCarve = GetRandomIntLowerThan(tilesAroundInfo.MovableWalls.Count);

                        for (int i = 0; i < numberOfWallsToCarve; i++)
                        {
                            var wallToChange = tilesAroundInfo.MovableWalls.GetRandomElement<TileInfo>(rnd).Position;
                            maze.Tiles[wallToChange.Y, wallToChange.X] = (int)TileType.Path;
                        }

                        //Set last wall as solid wall
                        if (tilesAroundInfo.MovableWalls.Count == 1)
                        {
                            var wallToChange = tilesAroundInfo.MovableWalls.First().Position;
                            maze.Tiles[wallToChange.Y, wallToChange.X] = (int)TileType.SolidWall;
                        }

                        //Set current path as verified path
                        maze.Tiles[row, column] = (int)TileType.VerifiedPath;
                    }
                }
            }
        }

        public int GetRandomIntLowerThan(int value)
        {
            return rnd.Next(1, value);
        }
    }

    //This generator is not good. It doesn't necessarelly generates a path between the start and the target
}