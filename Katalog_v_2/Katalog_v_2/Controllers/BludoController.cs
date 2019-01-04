using Katalog_v_2.Models;
using Katalog_v_2.Models.Interface;
using Katalog_v_2.Service.BDService;
using Katalog_v_2.Service.FileService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Katalog_v_2.Controllers
{
    public class BludoController : Controller
    {
        private readonly IBludo _service;

        public BludoController()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["BD"]) == true)
            {
                _service = new BludoService();
            }
            else
            {
                _service = new BludoFileService();

            }
        }

        [HttpGet]
        public ActionResult Bludos()
        {
            var list = _service.GetList();
            ViewBag.Bludoes = list;
            return View();
        }


        [HttpGet]
        public ActionResult Rezept(string RezeptName, int bludId)
        {
            
            Rezept rezeptModel = _service.GetRezept(RezeptName, bludId);
            ViewBag.Rezepts = rezeptModel;
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddRezept(int Id)
        {
            var Bludo = _service.GetElement(Id);
            ViewBag.Bludo = Bludo;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddRezept(Rezept rezeptModel, HttpPostedFileBase imagedata = null)
        {
            rezeptModel.RezeptData = DateTime.Now.ToLongDateString();
            if (imagedata != null)
            {
                rezeptModel.ImageMimeType = imagedata.ContentType;
                rezeptModel.Image = new byte[imagedata.ContentLength];
                imagedata.InputStream.Read(rezeptModel.Image, 0, imagedata.ContentLength);
            }
            _service.AddRezept(rezeptModel);
            return RedirectToAction("Bludos", "Bludo");
        }


        public FileContentResult GetImage(string Name, int bludId)
        {
            Rezept rezeptModel = _service.GetRezept(Name, bludId);
            if (rezeptModel != null)
            {
                return File(rezeptModel.Image, rezeptModel.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}