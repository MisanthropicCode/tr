using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextumReader.ProblemDomain;

namespace TextumReader.DataLayer.Abstract
{
    public interface IMaterialRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<Material> Materials { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<Dictionary> Dictionaries { get; }
        IQueryable<Word> Words { get; }
        IQueryable<Translation> Translations { get; }

        void SaveMaterial(Material material);
        Material DeleteMaterial(int materialId);
    }
}
