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

            // TODO: �� BUG�A�@����ܤӦh�|�����ծ�
            for (int i = 0; i < config.KuruKuruNumbers; i++)
            {
                KuruKuruForm form = new KuruKuruForm(config);
                form.Show();
            }
        }

        /// <summary>
        /// Ū�� appsettings.json �äϧǦC��
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException">�Ӹ��|�L�ɮ�</exception>
        /// <exception cref="ArgumentException">�]�w�ɰѼƦ��~</exception>
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
        /// ��l�����A�� Kururu.gif ���v���j�p�������j�p�P�I���z��
        /// </summary>
        private void InitializeTheme()
        {
            // �I���z��
            this.TransparencyKey = Color.Red;
            this.BackColor = Color.Red;

            // �]�w��檺�˦�
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.TopMost = true;
        }
    }
}