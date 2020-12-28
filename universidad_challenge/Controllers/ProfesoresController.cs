using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using universidad_challenge.Filters;
using universidad_challenge.Models;

namespace universidad_challenge.Controllers
{
    
    public class ProfesoresController : Controller
    {
        // GET: Profesores
        [AuthorizeUser(id_rol: 1)]
        public ActionResult Index()
        {
            try
            {
                using (Models.universityEntities db = new Models.universityEntities())
                {
                    return View(db.teachers.ToList());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Se ha producido un error - ", ex.Message);
                return View();
            }
        }
        
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(teachers a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (Models.universityEntities db = new Models.universityEntities())
                {
                    db.teachers.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","Error al agregar profesor - " + ex.Message);
                return View();
            }

        }

        public ActionResult Editar(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
             {
                using (Models.universityEntities db = new Models.universityEntities())
                {
                    //teachers prof = db.teachers.Where(a => a.id_teacher == id).FirstOrDefault();
                    teachers prof = db.teachers.Find(id);
                    return View(prof);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Se ha producido un error - ", ex.Message);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(teachers a)
        {
            try
            {
                using (Models.universityEntities db = new Models.universityEntities())
                {
                    teachers prof = db.teachers.Find(a.id_teacher);

                    prof.teacher_dni = a.teacher_dni;
                    prof.teacher_name = a.teacher_name;
                    prof.teacher_last_name = a.teacher_last_name;
                    prof.active = a.active;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Se ha producido un error - ", ex.Message);
                return View();
            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                using (Models.universityEntities db = new Models.universityEntities())
                {
                    teachers prof = db.teachers.Find(id);
                    db.teachers.Remove(prof);
                    db.SaveChanges();
                    return RedirectToAction("Index");
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