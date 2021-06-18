using MidTask1.Models;
using MidTask1.Models.Database;
using MidTask1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
            Database db = new Database();

            // First way to show the multiple model in a view

            /*dynamic mymodel = new ExpandoObject();
            mymodel.Student = new Student();
            mymodel.Depts = db.Depts.GetAll();*/


            // Second way to show the multiple model in a view
            StudentDepts studentDepts = new StudentDepts
            {
                Student = new Student(),
                Depts = db.Depts.GetAll()
            };


            return View(studentDepts);
        }

        [HttpPost]
        public ActionResult Insert(Student s)
        {
            Database db = new Database();

            if (ModelState.IsValid)
            {
                db.Students.Insert(s);
                return RedirectToAction("Index");
            }

            StudentDepts studentDepts = new StudentDepts
            {
                Student = s,
                Depts = db.Depts.GetAll()
            };

            return View(studentDepts);
        }

        public ActionResult Edit(int id)
        {
            Database db = new Database();

            StudentDepts studentDepts = new StudentDepts
            {
                Student = db.Students.Get(id),
                Depts = db.Depts.GetAll()
            };

            return View(studentDepts);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            Database db = new Database();

            if (ModelState.IsValid)
            {
                db.Students.Update(s);
                return RedirectToAction("Index");
            }

            StudentDepts studentDepts = new StudentDepts
            {
                Student = s,
                Depts = db.Depts.GetAll()
            };

            return View(studentDepts);
        }

        public ActionResult Delete(int id)
        {
            Database db = new Database();
            db.Students.Delete(id);
            return RedirectToAction("Index");
        }
    }
}