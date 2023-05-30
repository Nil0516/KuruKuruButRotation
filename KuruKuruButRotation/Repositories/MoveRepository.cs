using KuruKuruButRotation.Repositories.Model;
using System.Threading;

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

        /// <summary>
        /// 右上方移動
        /// </summary>
        public Point MoveRightTop()
        {
            return GeneratePoint(Random.Shared.Next(MoveSizeX.Min, MoveSizeX.Max), Random.Shared.Next(-MoveSizeY.Max, MoveSizeY.Min));
        }

        /// <summary>
        /// 右下方移動
        /// </summary>
        public Point MoveRightBottom()
        {
            return GeneratePoint(Random.Shared.Next(MoveSizeX.Min, MoveSizeX.Max), Random.Shared.Next(MoveSizeY.Min, MoveSizeY.Max));
        }

        /// <summary>
        /// 左上方移動
        /// </summary>
        /// <returns></returns>
        public Point MoveLeftTop()
        {
            return GeneratePoint(Random.Shared.Next(-MoveSizeX.Max, MoveSizeX.Min), Random.Shared.Next(-MoveSizeY.Max, -MoveSizeY.Min));
        }

        /// <summary>
        /// 左下方移動
        /// </summary>
        /// <returns></returns>
        public Point MoveLeftBottom()
        {
            return GeneratePoint(Random.Shared.Next(-MoveSizeX.Max, MoveSizeX.Min), Random.Shared.Next(MoveSizeY.Min, MoveSizeY.Max));
        }

        /// <summary>
        /// 隨機右下或左下移動
        /// </summary>
        public Point MoveRightOrLeftBottom()
        {
            if (YesOrNo())
            {
                return MoveRightBottom();
            }
            else
            {
                return MoveLeftBottom();
            }
        }

        /// <summary>
        /// 隨機右上或左上移動
        /// </summary>
        public Point MoveRightOrLeftTop()
        {
            if (YesOrNo())
            {
                return MoveRightTop();
            }
            else
            {
                return MoveLeftTop();
            }
        }

        /// <summary>
        /// 隨機右下或右上移動
        /// </summary>
        /// <returns></returns>
        public Point MoveRightRopOrBottom()
        {
            if (YesOrNo())
            {
                return MoveRightBottom();
            }
            else
            {
                return MoveRightTop();
            }
        }

        /// <summary>
        /// 隨機左上或左下移動
        /// </summary>
        /// <returns></returns>
        public Point MoveLeftTopOrBottom()
        {
            if (YesOrNo())
            {
                return MoveLeftBottom();
            }
            else
            {
                return MoveLeftTop();
            }
        }

        /// <summary>
        /// 將 number 1 與 number 2 轉換成 Point
        /// </summary>
        /// <returns></returns>
        private Point GeneratePoint(int number1, int number2)
        {
            return new Point(number1, number2);
        }

        /// <summary>
        /// 隨機 True Or False，概率皆為 50 %
        /// </summary>
        /// <returns></returns>
        private bool YesOrNo()
        {
            int luckyNumber = Random.Shared.Next(0, 100);
            if (luckyNumber < 50)
            {
                return true;
            }
            return false;
        }
    }
}
