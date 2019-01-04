using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Katalog_v_2.Models;
using Katalog_v_2.Models.Abstract;
using Katalog_v_2.Models.Interface;

namespace Katalog_v_2.Service.BDService
{
    public class BludoService : AbstractDbService<Bludo>, IBludo
    {
        private dbContext context = new dbContext();

        public override DbSet<Bludo> Pata { get { return context.Bludoes; } }

        public override dbContext Сontext { get { return context; } }

        public override List<AModel> GetList()
        {
            List<AModel> amodel = new List<AModel>();
            List<Bludo> Bludos = context.Bludoes.ToList();
            List < Rezept > rezept= context.Rezepts.ToList();
            foreach (Bludo bludo in Bludos) {
                bludo.Rezepts = rezept.FindAll(rec => rec.bludId == bludo.Id);
                amodel.Add(bludo);
            }
            return amodel;
        }

        public void AddRezept(Rezept rezept) {
            Bludo bludo = context.Bludoes.Find(rezept.bludId);
            if (bludo.Rezepts == null) {
                bludo.Rezepts = new List<Rezept>();
            }
            bludo.Rezepts.Add(rezept);
            context.SaveChanges();
        }

        public Rezept GetRezept(string name, int Bludo_id)
        {
            Rezept rezept = context.Rezepts.FirstOrDefault(rec => rec.Name.Equals(name) && rec.bludId == Bludo_id);
            
            return rezept;
        }
    }
}