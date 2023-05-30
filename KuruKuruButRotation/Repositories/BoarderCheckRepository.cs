namespace KuruKuruButRotation.Repositories
{
    public class BoarderCheckRepository
    {
        private Point Location;
        private readonly Size ScreenSize;
        private readonly Size ImageSize;

        public BoarderCheckRepository(Point location, Size screenSize, Size imageSize)
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

        public void UpdateLocation(Point location)
        {
            Location = location;
        }
    }
}
