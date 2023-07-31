namespace Domain.MazeGenerator
{
    public class MazePosition
    {
        public int Y;
        public int X;

        public MazePosition(int _y, int _x)
        {
            Y = _y;
            X = _x;
        }

        public bool IsEqual(MazePosition otherMazePosition)
        {
            return Y == otherMazePosition.Y && X == otherMazePosition.X;
        }
    }
}
