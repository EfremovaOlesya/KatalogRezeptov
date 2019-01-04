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
    public class BludoService : IBludo
    {
        private Context context;

        public BludoService(Context context)
        {
            this.context = context;
        }

        public void AddElement(BludoModel model)
        {
            Bludo element = context.Bludoes.FirstOrDefault(rec => rec.BludoName == model.BludoName);
            if (element != null)
            {
                throw new Exception("Уже есть блюдо с таким названием");
            }
            context.Bludoes.Add(new Bludo
            {
                BludoName = model.BludoName,
                Rezepts = model.Rezepts.Select(rec => new Rezept
                {
                    Id = rec.Id,
                    RezeptName = rec.RezeptName,
                    RezeptData = rec.RezeptData,
                    Ingrid = rec.Ingrid,
                    soder = rec.soder,
                    Image = rec.Image,
                    ImageMimeType = rec.ImageMimeType

                }).ToList()
            });
            context.SaveChanges();
        }

        public void AddRezept(RezeptModel model)
        {
            Bludo element = context.Bludoes.FirstOrDefault(rec => rec.Id == model.bludId);
            if (element != null)
            {
                if (element.Rezepts == null)
                {
                    element.Rezepts = new List<Rezept>();
                }
                element.Rezepts.Add(new Rezept
                {
                    RezeptName = model.RezeptName,
                    RezeptData = model.RezeptData,
                    Ingrid = model.Ingrid,
                    soder = model.soder,
                    bludId = model.bludId,
                    Image = model.Image,
                    ImageMimeType = model.ImageMimeType

                });
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public BludoModel GetElement(int id)
        {
            BludoModel element = GetList().Find(rec => rec.Id == id);
            if (element != null)
            {
                return element;
            }
            throw new Exception("Элемент не найден");
        }

        public List<BludoModel> GetList()
        {
            List<BludoModel> result = context.Bludoes.Select(rec => new BludoModel
            {
                Id = rec.Id,
                BludoName = rec.BludoName,
                Rezepts = rec.Rezepts.Select(rez => new RezeptModel
                {
                    Id = rez.Id,
                    bludId = rec.Id,
                    Ingrid = rez.Ingrid,
                    RezeptData = rez.RezeptData,
                    RezeptName = rez.RezeptName,
                    soder = rez.soder,
                    Image = rez.Image,
                    ImageMimeType = rez.ImageMimeType
                }).ToList()
            })
                .ToList();
            return result;
        }

        public void DelElement(int id)
        {
            Bludo element = context.Bludoes.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Bludoes.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

    }
}