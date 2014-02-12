using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TextumReader.ProblemDomain
{
    public class Dictionary
    {
        public int DictionaryId { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Word> Words { get; set; }
    }
}
