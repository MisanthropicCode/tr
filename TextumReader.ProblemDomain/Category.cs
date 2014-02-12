using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TextumReader.ProblemDomain
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public string Name { get; set; }
    }
}
