using KuruKuruButRotation.Repositories;
using KuruKuruButRotation.Repositories.Model;
using System.Configuration;
using System.Diagnostics;
using System.Text.Json;

namespace KuruKuruButRotation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeTheme();
            var config = ReadAppsettings();

            // TODO: 有 BUG，一次顯示太多會先有白框
            for (int i = 0; i < config.KuruKuruNumbers; i++)
            {
                KuruKuruForm form = new KuruKuruForm(config);
                form.Show();
            }
        }

        /// <summary>
        /// 讀取 appsettings.json 並反序列化
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException">該路徑無檔案</exception>
        /// <exception cref="ArgumentException">設定檔參數有誤</exception>
        private AppsettingsConfig ReadAppsettings(string path = "./appsettings.json")
        {
            if (!File.Exists(path)) throw new FileNotFoundException();
            var json = File.ReadAllText(path);
            try
            {
                var config = JsonSerializer.Deserialize<AppsettingsConfig>(json);
                return config;
            }
            catch
            {
                throw new ArgumentException($"Please check your {path} file was valid.");
            }
        }

        /// <summary>
        /// 初始介面，讓 Kururu.gif 的影像大小為視窗大小與背景透明
        /// </summary>
        private void InitializeTheme()
        {
            // 背景透明
            this.TransparencyKey = Color.Red;
            this.BackColor = Color.Red;

            // 設定表單的樣式
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.TopMost = true;
        }
    }
}