using Portfolio.Shared.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared
{
    public class ProjectViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Requirement { get; set; }
        public string Design { get; set; }
        public DateTime CompletionDate { get; set; }


        public IList<Category> Categories { get; set; }


        public ProjectViewModel(Project project)
        {
            ID = project.ID;
            Title = project.Title;
            Requirement = project.Requirement;
            Design = project.Design;
            CompletionDate = project.CompletionDate;

            

            Categories = new List<Category>();
            foreach(ProjectCategory pc in project.ProjectCategories ?? new List<ProjectCategory>())
            {
                Categories.Add(pc.Category);
            }
          
        }

        public ProjectViewModel() { }


    }
}
