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

        public IList<Framework> Frameworks { get; set; }
        public IList<Language> Languages { get; set; }
        public IList<Platform> Platforms { get; set; }

        public ProjectViewModel(Project project)
        {
            ID = project.ID;
            Title = project.Title;
            Requirement = project.Requirement;
            Design = project.Design;
            CompletionDate = project.CompletionDate;

            
            Frameworks = new List<Framework>(project.ProjectFrameworks.Select(pf => pf.Framework));
            Languages = new List<Language>(project.ProjectLanguages.Select(pl => pl.Language));
            Platforms = new List<Platform>(project.ProjectPlatforms.Select(pp => pp.Platform));

        }


    }
}
