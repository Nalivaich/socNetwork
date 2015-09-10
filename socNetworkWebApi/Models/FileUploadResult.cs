using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace socNetworkWebApi.Models
{
    [JsonObject]
    public class FileUploadResult
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("newName")]
        public string NewName { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }
        [JsonProperty("deleteUrl")]
        public string DeleteUrl { get; set; }
        [JsonProperty("deleteType")]
        public string DeleteType { get; set; }
    }
}