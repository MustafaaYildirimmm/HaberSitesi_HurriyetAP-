using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.Entity.API
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ArticleApi
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "ContentType")]
        public string ContentType { get; set; }
        [JsonProperty(PropertyName = "CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "Files")]
        public List<FilesApi> Files { get; set; }
        [JsonProperty(PropertyName = "ModifiedDate")]
        public DateTime ModifiedDate { get; set; }
        [JsonProperty(PropertyName = "Path")]
        public string Path { get; set; }
        [JsonProperty(PropertyName = "StartDate")]
        public DateTime StartDate { get; set; }
        public List<string> Tags { get; set; }
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "Url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName ="Text")]
        public string Text { get; set; }
    }
}
