using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KuruKuruButRotation
{
    public class AppsettingsConfig
    {
        /// <summary>
        /// Kuru Kuru 的數量，最大限制 20
        /// </summary>
        [Range(1, 20)]
        public int KuruKuruNumbers { get; set; } = 1;

        public IEnumerable<string> Audios { get; set; }
    }
}
