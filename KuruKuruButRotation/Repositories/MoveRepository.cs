using KuruKuruButRotation.Repositories.Model;

namespace KuruKuruButRotation.Repositories
{
    public class MoveRepository
    {
        private readonly MoveSize MoveSizeX;
        private readonly MoveSize MoveSizeY;

        /// <summary>
        /// 管理移動的 Repo
        /// </summary>
        /// <param name="moveSizeX"></param>
        /// <param name="moveSizeY"></param>
        public MoveRepository(MoveSize moveSizeX, MoveSize moveSizeY)
        {
            MoveSizeX = moveSizeX;
            MoveSizeY = moveSizeY;
        }

        public (int x, int y) MoveRightTop()
        {
            return (Random.Shared.Next(MoveSizeX.Min, MoveSizeX.Max), Random.Shared.Next(-MoveSizeY.Max, MoveSizeY.Min));
        }

        public (int x, int y) MoveRightBottom()
        {
            return (Random.Shared.Next(MoveSizeX.Min, MoveSizeX.Max), Random.Shared.Next(MoveSizeY.Min, MoveSizeY.Max));
        }

        public (int x, int y) MoveLeftTop()
        {
            return (Random.Shared.Next(-MoveSizeX.Max, MoveSizeX.Min), Random.Shared.Next(-MoveSizeY.Max, -MoveSizeY.Min));
        }

        public (int x, int y) MoveLeftBottom()
        {
            return (Random.Shared.Next(-MoveSizeX.Max, MoveSizeX.Min), Random.Shared.Next(MoveSizeY.Min, MoveSizeY.Max));
        }
    }
}
