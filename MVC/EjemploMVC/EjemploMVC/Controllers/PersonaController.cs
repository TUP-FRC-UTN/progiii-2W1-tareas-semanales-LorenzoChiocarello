using EjemploMVC.AccesoDatos;
using EjemploMVC.Models;
using EjemploMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace EjemploMVC.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult EliminarPersona(int idPersona)
        {
            Persona resultado = AD_Personas.ObtenerPersona(idPersona);
           
            return View(resultado);
        }

        [HttpPost]
        public ActionResult EliminarPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Personas.EliminarPersona(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoPersonas", "Persona");
                }
                else
                {
                    return View(model);
                }
            }
            return View();
        }

        public ActionResult DatosPersona(int idPersona ) 
        {
            List<SexoItemVM> listaSexo = AD_Personas.ObtenerListasSexos();

            List<SelectListItem> itemsCombo = listaSexo.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdSexo.ToString(),
                    Selected = false

                };
            });

            Persona resultado = AD_Personas.ObtenerPersona(idPersona);

            foreach(var item in itemsCombo) 
            {
                if (item.Value.Equals(resultado.idSexo.ToString())) 
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.items = itemsCombo;

            ViewBag.Nombre = resultado.Nombre + " " + resultado.Apellido;
            return View(resultado);
        }

        [HttpPost]
        public ActionResult DatosPersona(Persona model)
        {
            if (ModelState.IsValid) 
            {
                bool resultado = AD_Personas.ActualizarDatosPersona(model);
                if (resultado) 
                {
                    return RedirectToAction("ListadoPersonas", "Persona");
                }
                else 
                {
                    return View(model);
                }
            }
            return View();
        }



        public ActionResult AltaPersona()
        {
            List<SexoItemVM> listaSexo = AD_Personas.ObtenerListasSexos();

            List<SelectListItem> items = listaSexo.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdSexo.ToString(),
                    Selected = false

                };
            });

            ViewBag.items = items;


            return View();
        }

        [HttpPost]
        public ActionResult AltaPersona(Persona model)
        {
            if (ModelState.IsValid) 
            {
                bool resultado = AD_Personas.InsertaNuevaPersona(model);
                if (resultado) 
                {
                    return RedirectToAction("ListadoPersonas", "Persona");
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

        public ActionResult ListadoPersonas()
        {
            List<Persona> lista = AD_Personas.ObtenerListaPersona();
            return View(lista);
        }
    }
}