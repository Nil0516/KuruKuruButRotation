using KuruKuruButRotation.Repositories;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace KuruKuruButRotation
{
    public partial class KururuForm : Form
    {
        private readonly Size ScreenSize;
        private readonly MoveRepository MoveRepository;
        private readonly AudioRepository AudioRepository;
        private readonly BoarderCheckRepository BoarderCheckRepository;

        public KururuForm()
        {
            InitializeComponent();
            ScreenSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            MoveRepository = new MoveRepository();
            BoarderCheckRepository = new BoarderCheckRepository(Location, ScreenSize, mainImage.Size);
            // TODO: Refactor. Please useing the appsettings.json to set audio path.
            AudioRepository = new AudioRepository(new List<string> { "./Audios/Kurukuru.wav", "./Audios/Kurulin.wav" });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeTheme();
            DvdStyleMove();
        }

        private async Task DvdStyleMove()
        {
            int moveX = Random.Shared.Next(0, 50);
            int moveY = Random.Shared.Next(0, 50);

            // TODO: Refactor this dirty code.
            while (true)
            {
                if (BoarderCheckRepository.IsTopBorderEdge())
                {
                    if (YesOrNo())
                    {
                        (moveX, moveY) = MoveRepository.MoveRightBottom();
                    }
                    else
                    {
                        (moveX, moveY) = MoveRepository.MoveLeftBottom();
                    }
                } else if (BoarderCheckRepository.IsBottomBorderEdge())
                {
                    if (YesOrNo())
                    {
                        (moveX, moveY) = MoveRepository.MoveRightTop();
                    } else
                    {
                        (moveX, moveY) = MoveRepository.MoveLeftTop();
                    }
                } else if (BoarderCheckRepository.IsLeftBorderEdge())
                {
                    if (YesOrNo())
                    {
                        (moveX, moveY) = MoveRepository.MoveRightBottom();
                    } else
                    {
                        (moveX, moveY) = MoveRepository.MoveRightTop();
                    }
                } else if (BoarderCheckRepository.IsRightBorderEdge())
                {
                    if (YesOrNo())
                    {
                        (moveX, moveY) = MoveRepository.MoveLeftBottom();
                    }
                    else
                    {
                        (moveX, moveY) = MoveRepository.MoveLeftTop();
                    }
                }
                await MoveForm(10, moveX, moveY);
                BoarderCheckRepository.UpdateLocation(Location);
            }
        }

        private bool YesOrNo()
        {
            int luckyNumber = Random.Shared.Next(0, 100);
            if (luckyNumber < 50)
            {
                return true;
            }
            return false;
        }

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
        }

        private void mainImage_Click(object sender, EventArgs e)
        {
            AudioRepository.PlayRandom();
        }
    }
}