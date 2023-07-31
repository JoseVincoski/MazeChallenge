using Domain.MazeGenerator;

namespace MazeGeneratorLib
{
    public class MazeGenerator
    {
        public Maze Maze;
        private IGenerator Generator;

        public MazeGenerator(IGenerator _generator, int _mazeHeight, int _mazeWidth)
        {
            Maze = new Maze(_mazeHeight, _mazeWidth);
            Generator = _generator;

            Generator.GenerateBase(ref Maze);
        }

        public Maze GetMaze()
        {
            Generator.GeneratePoints(ref Maze);
            Generator.GenerateMaze(ref Maze);

            return Maze;
        }
    }
}