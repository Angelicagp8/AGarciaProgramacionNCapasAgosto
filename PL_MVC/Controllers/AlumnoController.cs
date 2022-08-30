using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
       
        [HttpGet] //ACTION VERB: Controla la acción del método
        public ActionResult GetAll() // ACTION METOD : Métodos  que tenemos en el controller 
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Alumno.GetAllEF();

            if(result.Correct)
            {
                alumno.Alumnos = result.Objects;
            }
            return View(alumno); //ACTION RESULT : TIpos de retorno que tenemos en los métodos EJEMPLO : ActionResult -> Vista en HTML // JsonResult -> Objeto de tipo JSON  para responder a peticiones AJAX
        }

        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.Semestre = new ML.Semestre();
            if(IdAlumno == null)
            {
                return View(alumno);
            }
            else
            {
                //Formulario precargado con los datos del registro GETBYID
            }

            return View();

        }
        [HttpPost] 
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            if(alumno.IdAlumno == 0)
            {
                result = BL.Alumno.AddEF(alumno);

                if(result.Correct)
                {
                    ViewBag.Mensaje = "Registro exitoso";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al insertar el registro" + result.ErrorMessage;
                }
            }
            else
            {
                //UPDATE
            }
            return PartialView("Modal");
        }

    }
}