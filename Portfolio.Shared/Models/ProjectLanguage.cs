using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared.Models
{
    public class ProjectLanguage
    {
        public int ProjectID { get; set; }

        public int LanguageID { get; set; }

        public Project Project { get; set; }

        public Language Language { get; set; }

    }
}
