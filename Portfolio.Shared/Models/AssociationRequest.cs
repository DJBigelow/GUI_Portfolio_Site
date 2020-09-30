using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared.Models
{
    public class AssociationRequest
    {
        public string CategoryType { get; set; }
        public int ProjectID { get; set; }
        public string Category { get; set; }
    }
}
