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
        /// 放入 .wav path
        /// </summary>
        /// <param name="resources"></param>
        public AudioRepository(IEnumerable<string> resources)
        {
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
