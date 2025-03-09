using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ImageModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                { "_id", Id },
                { "url", Url }
            };
        }

        public static ImageModel FromDictionary(Dictionary<string, object> data)
        {
            return new ImageModel
            {
                Id = data.ContainsKey("_id") ? data["_id"]?.ToString() : null,
                Url = data.ContainsKey("url") ? data["url"]?.ToString() : null
            };
        }
    }
}
