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


        [JsonPropertyName("categories")]
        public IList<ProjectCategory> ProjectCategories { get; set; }

      

        public Project() { }

        public Project(ProjectViewModel vm)
        {
            ID = vm.ID;
            Title = vm.Title;
            Requirement = vm.Requirement;
            Design = vm.Design;
            CompletionDate = vm.CompletionDate;

            ProjectCategories = new List<ProjectCategory>();
            foreach(Category category in vm.Categories ?? new List<Category>())
            {
                ProjectCategories.Add(new ProjectCategory() { Category = category });
            }

      
        }

    }
}
