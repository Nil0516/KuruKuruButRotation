using System.Media;

namespace KuruKuruButRotation.Repositories
{
    /// <summary>
    /// 播放音效 Repo
    /// </summary>
    public class AudioRepository
    {
        private readonly SoundPlayer[] SoundPlayer;

        /// <summary>
        /// 輸入 wav 的路徑
        /// </summary>
        /// <param name="resources"></param>
        /// <exception cref="InvalidOperationException">請確認參數使否正常</exception>
        public AudioRepository(IEnumerable<string> resources)
        {
            if (resources.Count() <= 0) throw new InvalidOperationException("無參數");

            SoundPlayer = new SoundPlayer[resources.Count()];

            int i = 0;
            foreach (var resource in resources)
            {
                SoundPlayer[i++] = new SoundPlayer(resource);
            }
        }

        /// <summary>
        /// 隨機播放音樂
        /// </summary>
        public void PlayRandom()
        {
            SoundPlayer[Random.Shared.Next(0, SoundPlayer.Length)].Play();
        }
    }
}
