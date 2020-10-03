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


        public Project() { }

        public Project(ProjectViewModel vm)
        {
            ID = vm.ID;
            Title = vm.Title;
            Requirement = vm.Requirement;
            Design = vm.Design;
            CompletionDate = vm.CompletionDate;

            ProjectFrameworks = new List<ProjectFramework>();
            foreach(Framework framework in vm.Frameworks ?? new List<Framework>())
            {
                ProjectFrameworks.Add(new ProjectFramework() { Framework = framework });
            }

            ProjectLanguages = new List<ProjectLanguage>();
            foreach(Language language in vm.Languages ?? new List<Language>())
            {
                ProjectLanguages.Add(new ProjectLanguage() { Language = language });
            }

            ProjectPlatforms = new List<ProjectPlatform>(); 
            foreach(Platform platform in vm.Platforms ?? new List<Platform>())
            {
                ProjectPlatforms.Add(new ProjectPlatform() { Platform = platform });
            }
        }

    }
}
