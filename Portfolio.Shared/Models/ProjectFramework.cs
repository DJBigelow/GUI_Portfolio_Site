using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared.Models
{
    public class ProjectFramework
    {
        public int ProjectID { get; set; }

        public int FrameworkID { get; set; }

        public Project Project { get; set; }

        public Framework Framework { get; set; }
    }
}
