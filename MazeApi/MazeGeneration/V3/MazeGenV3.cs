using Domain;
using Domain.MazeGenerator;
using Domain.MazeGenerator.Enums;
using Domain.MazeGenerator.MazeGenV3Models;

namespace MazeGeneratorLib.V3
{
    public class MazeGenV3 : IGenerator
    {
        private readonly Random rnd;
        private Maze _maze;
        private List<MazePosition> _unverifiedPathPositions = new List<MazePosition>();

        public MazeGenV3(int? seed)
        {
            if (seed != null) rnd = new Random((int)seed);
            else rnd = new Random((int)DateTime.Now.Ticks);
        }

        public MazeGenV3()
        {
            rnd = new Random((int)DateTime.Now.Ticks);
        }

        public void GenerateMaze(ref Maze maze)
        {
            _maze = maze;
            FillMazePathPositions();

            MazePosition position = new MazePosition(1, 1);
            while (_unverifiedPathPositions.Count != 0)
            {
                //Set current path as Verified Path
                _maze.Tiles[position.Y, position.X] = (int)TileType.VerifiedPath;
                var pathToRemove = _unverifiedPathPositions.SingleOrDefault(p => p.Y == position.Y && p.X == position.X);
                if (pathToRemove != null) _unverifiedPathPositions.Remove(pathToRemove);

                //Carve wall
                var tilesAroundInfo = new TilesAroundInfo(_maze, position.Y, position.X);
                if (tilesAroundInfo.MovableWalls.Count > 1)
                {
                    var wallToChange = tilesAroundInfo.MovableWalls.GetRandomElement<TileInfo>(rnd);
                    _maze.Tiles[wallToChange.Position.Y, wallToChange.Position.X] = (int)TileType.Path;
                    position = wallToChange.NextPosition;
                }

                //If new position is verified path, get new unverified path.
                if (_maze.Tiles[position.Y, position.X] == (int)TileType.VerifiedPath && _unverifiedPathPositions.Count != 0)
                {
                    position = GetRandomUnverifiedPathPosition();
                }
            }
        }

        public MazePosition? GetRandomUnverifiedPathPosition()
        {
            var a = rnd.Next(_unverifiedPathPositions.Count);
            var b = _unverifiedPathPositions[a];

            return b;
        }

        public void FillMazePathPositions()
        {
            for (int row = 1; row < _maze.Height; row += 2)
            {
                for (int column = 1; column < _maze.Width; column += 2)
                {
                    _unverifiedPathPositions.Add(new MazePosition(row, column));
                }
            }
        }
    }
}