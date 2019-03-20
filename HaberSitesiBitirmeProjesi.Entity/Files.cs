using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.Entity
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Files
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "FileUrl")]
        public string FileUrl { get; set; }
        [JsonProperty(PropertyName = "Metadata")]
        public Metadata Metadata { get; set; }

        public virtual Articles Article { get; set; }
    }
}
