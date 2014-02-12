using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextumReader.ProblemDomain
{
    public class Word
    {
        public Word()
        {
            this.Translations = new List<Translation>();
        }

        public int WordId { get; set; }

        public string Title { get; set; }
        public string SelectedTranslation { get; set; }

        public virtual ICollection<Translation> Translations { get; set; }
    }
}
