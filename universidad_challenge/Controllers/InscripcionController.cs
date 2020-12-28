using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using universidad_challenge.Filters;
using universidad_challenge.Models;

namespace universidad_challenge.Controllers
{
    public class InscripcionController : Controller
    {
        // GET: Inscripcion
        [AuthorizeUser(id_rol: 2)]
        public ActionResult Index()
        {
            try
            {
                using (Models.universityEntities db = new Models.universityEntities())
                {
                    return View(db.subjects.OrderBy(p => p.subject_name).ToList());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Se ha producido un error - ", ex.Message);
                return View();
            }
        }

        public ActionResult DetallesMateria(int id)
        {
            try
            {
                using (Models.universityEntities db = new Models.universityEntities())
                {
                    subjects mat = db.subjects.Find(id);
                    return View(mat);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Se ha producido un error - ", ex.Message);
                return View();
            }
        }

        public ActionResult InscripcionMateria(int id)
        {
            try
            {
                using (Models.universityEntities db = new Models.universityEntities())
                {
                    subjects mat = db.subjects.Find(id);
                    if (mat.students < mat.students_max)
                    {
                        mat.students++;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    } else
                    {
                        //aca faltaria el mensaje informando que no es posible inscribir
                        return RedirectToAction("Index");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Se ha producido un error - ", ex.Message);
                return View();
            }
        }

    }
}