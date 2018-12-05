using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDAE2Demo.Areas.General.Services;
using Microsoft.AspNetCore.Mvc;
using AppDAE2Demo.Models;

namespace AppDAE2Demo.Areas.General.Controllers
{
    [Area("General")]
    public class CatEdificiosController : Controller
    {
        SrvCatEdificiosList srvCatEdificiosList;

        public CatEdificiosController()
        {
            srvCatEdificiosList = new SrvCatEdificiosList();
        }

        public IActionResult Edificioslist()
        {
            try
            {
                List<Eva_cat_edificios> listaEdificios = srvCatEdificiosList
                    .getListCatEdificios().Result;
                ViewBag.Title = "Catalogo de edificios";
                return View(listaEdificios);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                if (e.InnerException != null) {
                    System.Diagnostics.Debug.WriteLine("{0}", e.InnerException);
                }
                throw;
            }
        }//Fin ViCatEdificiosList

        public ActionResult Edificioadd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edificioadd(Eva_cat_edificios edificioNuevo)
        {
            srvCatEdificiosList.postEdificio(edificioNuevo).Wait();
            return RedirectToAction("Edificioslist");
        }

        public IActionResult Edificiosdetalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Eva_cat_edificios edificio = srvCatEdificiosList
                    .getEdificio(id).Result;

            if (edificio == null)
            {
                return NotFound();
            }

            return View(edificio);
        }//Fin de detalle

        public IActionResult Edificioedit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Eva_cat_edificios edificio = srvCatEdificiosList
                   .getEdificio(id).Result;

            if (edificio == null)
            {
                return NotFound();
            }

            return View(edificio);
        }//Fin de edit

        [HttpPost]
        public ActionResult Edificioedit(Eva_cat_edificios edificio)
        {
            System.Diagnostics.Debug.WriteLine(edificio.DesEdificio);
            srvCatEdificiosList.putEdificio(edificio);

            return RedirectToAction("Edificioslist");
        }

        public ActionResult Edificiodelete(int ? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            srvCatEdificiosList.deleteEdificio(id).Wait();

            return RedirectToAction("Edificioslist");
        }
    }
}