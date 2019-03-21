using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.Entity.API
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class FilesApi
    {
        [JsonProperty(PropertyName = "FileUrl")]
        public string FileUrl { get; set; }
    }
}
