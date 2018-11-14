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
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                if (e.InnerException != null) {
                    System.Diagnostics.Debug.WriteLine("{0}",e.InnerException);
                }
                throw;
            }
        }//Fin ViCatEdificiosList
    }
}