using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextumReader.DataLayer.Abstract;
using TextumReader.DataLayer.Concrete;
using TextumReader.ProblemDomain;

namespace TextumReader.DataLayer.Concrete
{
    public class EFMaterialRepository : IMaterialRepository
    {
        private EFDbContext context = new EFDbContext();
        
        public IQueryable<User> Users
        {
            get { return context.Users; }
        }

        public IQueryable<Material> Materials
        {
            get { return context.Materials; }
        }

        public IQueryable<Category> Categories
        {
            get { return context.Categories; }
        }

        public IQueryable<Dictionary> Dictionaries
        {
            get { return context.Dictionaries; }
        }

        public IQueryable<Word> Words
        {
            get { return context.Words; }
        }

        public IQueryable<Translation> Translations
        {
            get { return context.Translations; }
        }

        public void SaveMaterial(Material material)
        {
            if (material.MaterialId == 0)
                context.Materials.Add(material);
            else
                context.Entry(material).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }

        public Material DeleteMaterial(int materialId)
        {
            Material dbMaterial = context.Materials.Find(materialId);
            if (dbMaterial != null)
            {
                context.Materials.Remove(dbMaterial);
                context.SaveChanges();
            }

            return dbMaterial;
        }
    }
}
