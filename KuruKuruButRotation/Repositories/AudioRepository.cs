using System.Media;

namespace KuruKuruButRotation.Repositories
{
    public class AudioRepository
    {
        private readonly SoundPlayer[] SoundPlayer;

        public AudioRepository(IEnumerable<string> resources)
        {
            SoundPlayer = new SoundPlayer[resources.Count()];

            int i = 0;
            foreach (var resource in resources)
            {
                SoundPlayer[i++] = new SoundPlayer(resource);
            }
        }

        public void PlayRandom()
        {
            SoundPlayer[Random.Shared.Next(0, SoundPlayer.Length)].Play();
        }
    }
}
