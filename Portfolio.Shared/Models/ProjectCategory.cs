using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared.Models
{
    public class ProjectCategory
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }


        public int ProjectID { get; set; }
        public Project Project { get; set; }

    }
}
