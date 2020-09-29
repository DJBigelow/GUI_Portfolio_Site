using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Shared.Models
{
    public class Project
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("requirement")]
        public string Requirement { get; set; }

        [JsonPropertyName("design")]
        public string Design { get; set; }

        [JsonPropertyName("completiondate")]
        public DateTime CompletionDate { get; set; }



        [JsonPropertyName("frameworks")]
        public IList<ProjectFramework> ProjectFrameworks { get; set; }

        [JsonPropertyName("languages")]
        public IList<ProjectLanguage> ProjectLanguages {get; set;}

        [JsonPropertyName("platforms")]
        public IList<ProjectPlatform> ProjectPlatforms {get; set;}

    }
}
