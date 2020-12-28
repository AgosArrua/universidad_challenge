using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using universidad_challenge.Filters;
using universidad_challenge.Models;

namespace universidad_challenge.Controllers
{
    public class MateriasController : Controller
    {
        // GET: Materias
        [AuthorizeUser(id_rol: 1)]
        public ActionResult Index()
        {
            try
            {
                using (Models.universityEntities db = new Models.universityEntities())
                {
                    return View(db.subjects.ToList());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Se ha producido un error - ", ex.Message);
                return View();
            }
        }

        public ActionResult AgregarMateria()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarMateria(subjects a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (Models.universityEntities db = new Models.universityEntities())
                {
                    db.subjects.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar materia - " + ex.Message);
                return View();
            }

        }

        public ActionResult ListaProfesores()
        {
            using (Models.universityEntities db = new Models.universityEntities())
            {
                return PartialView(db.teachers.ToList());
            }
        }

        public ActionResult EditarMateria(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMateria(subjects a)
        {
            try
            {
                using (Models.universityEntities db = new Models.universityEntities())
                {
                    subjects mat = db.subjects.Find(a.id_subject);

                    mat.subject_name = a.subject_name;
                    mat.id_teacher = a.id_teacher;
                    mat.start_time = a.start_time;
                    mat.end_time = a.end_time;
                    mat.students_max = a.students_max;
                    mat.students = a.students;
                    mat.description = a.description;

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

        public ActionResult EliminarMateria(int id)
        {
            try
            {
                using (Models.universityEntities db = new Models.universityEntities())
                {
                    subjects mat = db.subjects.Find(id);
                    db.subjects.Remove(mat);
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