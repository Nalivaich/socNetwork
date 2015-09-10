using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace socNetworkWebApi.Models
{
    public class FilesUploadResult
    {
        [JsonProperty("files")]
        public List<FileUploadResult> Files { get; set; }
    }
}