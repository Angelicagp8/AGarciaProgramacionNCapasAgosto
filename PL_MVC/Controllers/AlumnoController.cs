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
    }
}