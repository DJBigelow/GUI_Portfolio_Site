using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Shared.Models
{
    public class Project
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Requirement { get; set; }

        public string Design { get; set; }

        public DateTime CompletionDate { get; set; }
    }
}
