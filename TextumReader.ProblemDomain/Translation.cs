using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TextumReader.ProblemDomain
{
    public class Translation
    {
        public int TranslationId { get; set; }

        public int WordId { get; set; }
        public string Title { get; set; }

        [ForeignKey("WordId")]
        public virtual Word Word { get; set; }
    }
}
