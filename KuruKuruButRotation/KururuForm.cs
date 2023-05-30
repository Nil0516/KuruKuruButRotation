using KuruKuruButRotation.Repositories;
using KuruKuruButRotation.Repositories.Model;

namespace KuruKuruButRotation
{
    public partial class KururuForm : Form
    {
        private readonly Size ScreenSize;
        private readonly MoveRepository MoveRepository;
        private readonly AudioRepository AudioRepository;
        private readonly CheckBoardSideRepository CheckBoardSideRepository;

        public KururuForm()
        {
            InitializeComponent();
            ScreenSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            // TODO: Refactor. Please useing the appsettings.json to set audio path.
            AudioRepository = new AudioRepository(new List<string> { "./Audios/Kurukuru.wav", "./Audios/Kurulin.wav" });
            MoveRepository = new MoveRepository(new MoveSize { Min = 1, Max = 50 }, new MoveSize { Min = 1, Max = 50 });
            CheckBoardSideRepository = new CheckBoardSideRepository(Location, ScreenSize, mainImage.Size);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeTheme();
            DvdStyleMove();
        }

        private async Task DvdStyleMove()
        {
            Point point = new Point(Random.Shared.Next(-50, 50), Random.Shared.Next(-50, 50));
            
            while (true)
            {
                if (CheckBoardSideRepository.IsTopBorderEdge())
                {
                    point = MoveRepository.MoveRightOrLeftBottom();
                } else if (CheckBoardSideRepository.IsBottomBorderEdge())
                {
                    point = MoveRepository.MoveRightOrLeftTop();
                } else if (CheckBoardSideRepository.IsLeftBorderEdge())
                {
                    point = MoveRepository.MoveRightRopOrBottom();
                } else if (CheckBoardSideRepository.IsRightBorderEdge())
                {
                    point = MoveRepository.MoveLeftTopOrBottom();
                }
                await MoveForm(10, point.X, point.Y);
                CheckBoardSideRepository.UpdateLocation(Location);
            }
        }

        

        private async Task MoveForm(int delay, int x = 0, int y = 0)
        {
            this.Invoke((MethodInvoker)delegate {
                this.Location = new Point(this.Location.X + x, this.Location.Y + y);
            });
            await Task.Delay(delay);
        }

        /// <summary>
        /// ��l�����A�� Kururu.gif ���v���j�p�������j�p�P�I���z��
        /// </summary>
        private void InitializeTheme()
        {
            // �I���z��
            this.TransparencyKey = Color.Red;
            this.BackColor = Color.Red;

            // �]�w��檺�j�p���I���Ϥ����j�p
            this.ClientSize = mainImage.Size;

            // �]�w��檺�˦�
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void mainImage_Click(object sender, EventArgs e)
        {
            AudioRepository.PlayRandom();
        }
    }
}