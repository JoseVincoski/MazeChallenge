using Domain;
using Domain.MazeGenerator;

namespace MazeGeneratorLib.V1
{
    public class MazeGenV1 : IGenerator
    {
        private readonly Random rnd;
        public MazeGenV1(int? seed)
        {
            if (seed != null) rnd = new Random((int)seed);
            else rnd = new Random((int)DateTime.Now.Ticks);
        }

        public MazeGenV1()
        {
            rnd = new Random((int)DateTime.Now.Ticks);
        }

        public void GenerateMaze(ref Maze maze)
        {
            for (int row = 1; row < maze.Height - 1; row++)
            {
                bool rowIsEven = row.IsEven();
                for (int column = 1; column < maze.Width - 1; column++)
                {
                    bool columnIsEven = column.IsEven();

                    //Both odd -> always wall
                    //Both even -> always path
                    if (rowIsEven == columnIsEven) continue;

                    //Row even | Column odd -> Vertical Path
                    //Row odd | Column even -> Horizontal Path
                    maze.Tiles[row, column] = rnd.Next(2);
                }
            }
        }
    }

    //This generator is completelly random. It doesn't necessarelly generates a path between the start and the target
}
