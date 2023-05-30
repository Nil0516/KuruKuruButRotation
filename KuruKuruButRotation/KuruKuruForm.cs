using KuruKuruButRotation.Repositories;
using KuruKuruButRotation.Repositories.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuruKuruButRotation
{
    public partial class KuruKuruForm : Form
    {
        private readonly AppsettingsConfig AppsettingsConfig;

        private readonly Size ScreenSize;
        private readonly MoveRepository MoveRepository;
        private readonly AudioRepository AudioRepository;
        private readonly CheckBoardSideRepository CheckBoardSideRepository;

        public KuruKuruForm(AppsettingsConfig appsettingsConfig)
        {
            InitializeComponent();
            AppsettingsConfig = appsettingsConfig;
            
            // init repository
            ScreenSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            AudioRepository = new AudioRepository(AppsettingsConfig.Audios);
            MoveRepository = new MoveRepository(new MoveSize { Min = 1, Max = 50 }, new MoveSize { Min = 1, Max = 50 });
            CheckBoardSideRepository = new CheckBoardSideRepository(Location, ScreenSize, mainImage.Size);
        }

        private void KuruKuruForm_Load(object sender, EventArgs e)
        {
            InitializeTheme();
            DvdStyleMove();
        }

        /// <summary>
        /// 模擬 DVD 風格的移動
        /// </summary>
        /// <returns></returns>
        private async Task DvdStyleMove()
        {
            Point point = new Point(Random.Shared.Next(-50, 50), Random.Shared.Next(-50, 50));

            while (true)
            {
                if (CheckBoardSideRepository.IsTopBorderEdge())
                {
                    point = MoveRepository.MoveRightOrLeftBottom();
                }
                else if (CheckBoardSideRepository.IsBottomBorderEdge())
                {
                    point = MoveRepository.MoveRightOrLeftTop();
                }
                else if (CheckBoardSideRepository.IsLeftBorderEdge())
                {
                    point = MoveRepository.MoveRightRopOrBottom();
                }
                else if (CheckBoardSideRepository.IsRightBorderEdge())
                {
                    point = MoveRepository.MoveLeftTopOrBottom();
                }
                await MoveForm(10, point.X, point.Y);
                CheckBoardSideRepository.UpdateLocation(Location);
            }
        }

        /// <summary>
        /// 移動視窗
        /// </summary>
        private async Task MoveForm(int delay, int x = 0, int y = 0)
        {
            this.Invoke((MethodInvoker)delegate {
                this.Location = new Point(this.Location.X + x, this.Location.Y + y);
            });
            await Task.Delay(delay);
        }

        /// <summary>
        /// 初始介面，讓 Kururu.gif 的影像大小為視窗大小與背景透明
        /// </summary>
        private void InitializeTheme()
        {
            // 背景透明
            this.TransparencyKey = Color.Red;
            this.BackColor = Color.Red;

            // 設定表單的大小為背景圖片的大小
            this.ClientSize = mainImage.Size;

            // 設定表單的樣式
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.TopMost = true;
        }

        private void mainImage_Click(object sender, EventArgs e)
        {
            AudioRepository.PlayRandom();
        }
    }
}
