 namespace TextumReader.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TextumReader.ProblemDomain;

    public sealed class Configuration : DbMigrationsConfiguration<TextumReader.DataLayer.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TextumReader.DataLayer.Concrete.EFDbContext context)
        {
#if false
            context.Categories.AddOrUpdate(p => p.Name,
                new Category { Name = "�����" },
                new Category { Name = "������" },
                new Category { Name = "��������" },
                new Category { Name = "������" });

            context.SaveChanges();

            context.Materials.AddOrUpdate(p => p.Title,
                new Material
                {
                    CategoryId = context.Categories.FirstOrDefault(x => x.Name == "�����").CategoryId,
                    Category = context.Categories.FirstOrDefault(x => x.Name == "�����"),
                    Title = "Yakov Fain Methodologies in Software and Medicine",
                    ForeignText = "When a person gets into an emergency room in a hospital, he or she gets treated by regular doctors, not geniuses. I believe, this is the goal of the modern medical science � to makes sure that lots of doctors are available to provide medical help to patients. I�d assume that ER personnel has some well defined and strict procedures as to what to do when a person shows up with specific symptoms.",
                },
                new Material
                {
                    CategoryId = context.Categories.FirstOrDefault(x => x.Name == "�����").CategoryId,
                    Category = context.Categories.FirstOrDefault(x => x.Name == "�����"),
                    Title = "Record 1",
                    ForeignText = "When a person gets into an emergency room in a hospital, he or she gets treated by regular doctors, not geniuses. I believe, this is the goal of the modern medical science � to makes sure that lots of doctors are available to provide medical help to patients. I�d assume that ER personnel has some well defined and strict procedures as to what to do when a person shows up with specific symptoms.",
                },
                new Material
                {
                    CategoryId = context.Categories.FirstOrDefault(x => x.Name == "������").CategoryId,
                    Category = context.Categories.FirstOrDefault(x => x.Name == "������"),
                    Title = "Record 2",
                    ForeignText = "When a person gets into an emergency room in a hospital, he or she gets treated by regular doctors, not geniuses. I believe, this is the goal of the modern medical science � to makes sure that lots of doctors are available to provide medical help to patients. I�d assume that ER personnel has some well defined and strict procedures as to what to do when a person shows up with specific symptoms.",
                },
                new Material
                {
                    CategoryId = context.Categories.FirstOrDefault(x => x.Name == "������").CategoryId,
                    Category = context.Categories.FirstOrDefault(x => x.Name == "������"),
                    Title = "Record 3",
                    ForeignText = "When a person gets into an emergency room in a hospital, he or she gets treated by regular doctors, not geniuses. I believe, this is the goal of the modern medical science � to makes sure that lots of doctors are available to provide medical help to patients. I�d assume that ER personnel has some well defined and strict procedures as to what to do when a person shows up with specific symptoms.",
                },
                new Material
                {
                    CategoryId = context.Categories.FirstOrDefault(x => x.Name == "��������").CategoryId,
                    Category = context.Categories.FirstOrDefault(x => x.Name == "��������"),
                    Title = "Record 4",
                    ForeignText = "When a person gets into an emergency room in a hospital, he or she gets treated by regular doctors, not geniuses. I believe, this is the goal of the modern medical science � to makes sure that lots of doctors are available to provide medical help to patients. I�d assume that ER personnel has some well defined and strict procedures as to what to do when a person shows up with specific symptoms.",
                },
                new Material
                {
                    CategoryId = context.Categories.FirstOrDefault(x => x.Name == "������").CategoryId,
                    Category = context.Categories.FirstOrDefault(x => x.Name == "������"),
                    Title = "Record 4",
                    ForeignText = "When a person gets into an emergency room in a hospital, he or she gets treated by regular doctors, not geniuses. I believe, this is the goal of the modern medical science � to makes sure that lots of doctors are available to provide medical help to patients. I�d assume that ER personnel has some well defined and strict procedures as to what to do when a person shows up with specific symptoms.",
                });

            context.SaveChanges();
#endif
        }
    }
}
