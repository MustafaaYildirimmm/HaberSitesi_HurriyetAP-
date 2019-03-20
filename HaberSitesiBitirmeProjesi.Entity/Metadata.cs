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
    public class Metadata
    {
        [Key]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
    }
}
