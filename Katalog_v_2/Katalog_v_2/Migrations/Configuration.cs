namespace Katalog_v_2.Migrations
{
    using Katalog_v_2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Katalog_v_2.Service.dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Katalog_v_2.Service.dbContext context)
        {
            context.Bludoes.Add(new Bludo
            {
                Name = "Закуски",
                Rezepts = new List<Rezept>()
            });
            context.Bludoes.Add(new Bludo
            {
                Name = "Салаты",
                Rezepts = new System.Collections.Generic.List<Rezept>()
            });
            context.Bludoes.Add(new Bludo
            {
                Name = "Супы",
                Rezepts = new System.Collections.Generic.List<Rezept>()
            });
            context.Bludoes.Add(new Bludo
            {
                Name = "Выпечка",
                Rezepts = new System.Collections.Generic.List<Rezept>()
            });
            context.Bludoes.Add(new Bludo
            {
                Name = "Каши",
                Rezepts = new System.Collections.Generic.List<Rezept>()
            });
            context.Bludoes.Add(new Bludo
            {
                Name = "Торты",
                Rezepts = new System.Collections.Generic.List<Rezept>()
            });
            context.Bludoes.Add(new Bludo
            {
                Name = "Десерты",
                Rezepts = new System.Collections.Generic.List<Rezept>()
            });
            context.SaveChanges();
        }
    }
}
