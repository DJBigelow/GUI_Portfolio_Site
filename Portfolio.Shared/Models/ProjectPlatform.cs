using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared.Models
{
    public class ProjectPlatform
    {
        public int ProjectID { get; set; }

        public int PlatformID { get; set; }

        public Project Project { get; set; }

        public Platform Platform { get; set; }
    }
}
