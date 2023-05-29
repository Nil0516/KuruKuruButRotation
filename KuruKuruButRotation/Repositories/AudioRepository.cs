using KuruKuruButRotation.Properties;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

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
