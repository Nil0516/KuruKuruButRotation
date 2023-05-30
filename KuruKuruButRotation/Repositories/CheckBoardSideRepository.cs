namespace KuruKuruButRotation.Repositories
{
    /// <summary>
    /// 檢查是否碰到主螢幕邊境
    /// </summary>
    public class CheckBoardSideRepository
    {
        private Point Location;
        private readonly Size ScreenSize;
        private readonly Size ImageSize;

        public CheckBoardSideRepository(Point location, Size screenSize, Size imageSize)
        {
            Location = location;
            ScreenSize = screenSize;
            ImageSize = imageSize;
        }

        /// <summary>
        /// 檢查圖片是否碰到邊境 (右側)
        /// </summary>
        public bool IsRightBorderEdge()
        {
            if (Location.X >= ScreenSize.Width - ImageSize.Width)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 檢查圖片是否碰到邊境 (左側)
        /// </summary>
        public bool IsLeftBorderEdge()
        {
            if (Location.X <= 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 檢查圖片是否碰到邊境 (上側)
        /// </summary>
        public bool IsTopBorderEdge()
        {
            if (Location.Y <= 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 檢查圖片是否碰到邊境 (下側)
        /// </summary>
        public bool IsBottomBorderEdge()
        {
            if (Location.Y >= ScreenSize.Height - ImageSize.Height)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新當前位置
        /// </summary>
        /// <param name="location"></param>
        public void UpdateLocation(Point location)
        {
            Location = location;
        }
    }
}
