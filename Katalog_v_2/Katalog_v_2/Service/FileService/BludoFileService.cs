using Katalog_v_2.Models;
using Katalog_v_2.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Katalog_v_2.Service.FileService
{
    public class BludoFileService: AbstractFileService, IBludo
    {
        new string Name = "Bludo";
        new string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Bludo";
        new XmlSerializer xsSubmit = new XmlSerializer(typeof(Bludo));

        public BludoFileService()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }

        public void AddRezept(Rezept rezept) {
            Bludo bludo =(Bludo)base.GetElement(rezept.bludId);
            if (bludo.Rezepts.Find(rec => rec.Name.Equals(rezept.Name)) != null) {
                throw new Exception("Уже есть рецепт с таким названием");
            }
            else
            {
                rezept.bludId = bludo.Id;
                bludo.Rezepts.Add(rezept);
                UpdateElement(bludo);
            }
        }

        public Rezept GetRezept(string name, int Bludo_id)
        {
            Bludo bludo  = (Bludo)base.GetElement(Bludo_id);
            Rezept rezept = bludo.Rezepts.FirstOrDefault(rec => rec.Name == name);
            return rezept;
        }
    }
}