using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TextumReader.ProblemDomain
{
    public class Material
    {
        [HiddenInput(DisplayValue = false)]
        public int MaterialId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CategoryId { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Text in a foreign language")]
        [DataType(DataType.MultilineText)]
        public string ForeignText { get; set; }

        [Display(Name = "Translation")]
        [DataType(DataType.MultilineText)]
        public string NativeText { get; set; }

        public virtual Category Category { get; set; }
        public virtual Dictionary Dictionary { get; set; }
    }
}
