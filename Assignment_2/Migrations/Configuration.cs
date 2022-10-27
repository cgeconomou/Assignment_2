namespace Assignment_2.Migrations
{
    using Assignment_2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment_2.MyContext.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Assignment_2.MyContext.ApplicationContext context)
        {
            #region Trainers
            Trainer t1 = new Trainer() { Name = "Ektoras", LastName = "Gatsos", Email = "hector@hotmail.com", Salary = 50000 };
            Trainer t2 = new Trainer() { Name = "Periklis", LastName = "Aidinopoulos", Email = "peri@hotmail.com", Salary = 60000 };
            Trainer t3 = new Trainer() { Name = "Googlis", LastName = "Tutorialakis", Email = "tootoo@hotmail.com", Salary = 70000 };

            context.Trainers.AddOrUpdate(t=>t.Name,t1,t2,t3);
            context.SaveChanges();
            #endregion         
        }
    }
}
