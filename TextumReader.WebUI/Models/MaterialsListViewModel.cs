using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextumReader.ProblemDomain;

namespace TextumReader.WebUI.Models
{
    public class MaterialsListViewModel
    {
        public IEnumerable<Material> Materials { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public string CurrentCategory { get; set; }
    }
}