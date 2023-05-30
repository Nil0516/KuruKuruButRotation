namespace KuruKuruButRotation.Repositories
{
    public class MoveRepository
    {
        public (int x, int y) MoveRightTop()
        {
            return (Random.Shared.Next(1, 50), Random.Shared.Next(-50, -1));
        }

        public (int x, int y) MoveRightBottom()
        {
            return (Random.Shared.Next(1, 50), Random.Shared.Next(1, 50));
        }

        public (int x, int y) MoveLeftTop()
        {
            return (Random.Shared.Next(-50, -1), Random.Shared.Next(-50, -1));
        }

        public (int x, int y) MoveLeftBottom()
        {
            return (Random.Shared.Next(-50, -1), Random.Shared.Next(1, 50));
        }
    }
}
