using Examen.AccesoDatos;
using Examen.Models;
using Examen.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    public class ExamenController : Controller
    {
        // GET: Examen
        public ActionResult AltaExamen()
        {
            List<Materia> listaMaterias = AD_Examen.ObtenerListaMaterias();


            List<SelectListItem> items = listaMaterias.ConvertAll(d =>
            {
                return new SelectListItem()
                {

                    Text = d.nombre,

                    Value = d.idMateria.ToString(),
                    Selected = false
                };
            });



            ViewBag.items = items;


            return View();
        }

        [HttpPost]
        public ActionResult AltaExamen(Examenes model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Examen.InsertarNuevoExamen(model);
                if (resultado)
                {
                    return RedirectToAction("ListaExamenes", "Examenes");
                }
                else
                {
                    return View(model);
                }

            }
            else
            {
                return View(model);
            }
        }

        public ActionResult ListaExamenes()
        {
            List<ExamenVM> lista = AD_Examen.ObtenerListaExamenes();
            return View(lista);
        }
    }
}