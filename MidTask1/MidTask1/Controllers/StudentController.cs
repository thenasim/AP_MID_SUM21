using MidTask1.Models;
using MidTask1.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidTask1.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            Database db = new Database();
            var students = db.Students.GetAll();
            return View(students);
        }

        public ActionResult Insert()
        {
            Student s = new Student();
            return View(s);
        }

        [HttpPost]
        public ActionResult Insert(Student s)
        {
            Database db = new Database();
            db.Students.Insert(s);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Database db = new Database();
            Student s = db.Students.Get(id);
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            Database db = new Database();
            db.Students.Update(s);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Database db = new Database();
            db.Students.Delete(id);
            return RedirectToAction("Index");
        }
    }
}