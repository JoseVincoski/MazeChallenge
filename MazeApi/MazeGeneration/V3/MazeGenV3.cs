using Domain.MazeGenerator;

namespace MazeGeneratorLib.V3
{
    public class MazeGenV3 : IGenerator
    {
        private readonly Random rnd;
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

        }

        public int GetRandomIntLowerThan(int value)
        {
            return rnd.Next(1, value);
        }

    }
}