using previous_project.Models;
using previous_project.Repository.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Firstproject.Controllers
{


    [Authorize]
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            BadEntities1 entities = new BadEntities1();
            var students = entities.Tables.ToList();
            List<Student> studentList = new List<Student>();
            foreach (var tables in students)
            {
                Student student = new Student();
                student.City = tables.City;
                student.Id = tables.Id;
                student.Gender = tables.Gender;
                student.Name = tables.Name;
                student.Stream = tables.Stream;
                studentList.Add(student);

            }
            return View(studentList);
        }
        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            Table table = new Table();
            table.Name = student.Name;
            table.Id = student.Id;
            table.Gender = student.Gender;
            table.City = student.City;
            table.Stream = student.Stream;
            BadEntities1 entities = new BadEntities1();
            entities.Tables.Add(table);
            entities.SaveChanges();



            return Redirect("Index");




        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            BadEntities1 entities = new BadEntities1();
            var table = entities.Tables.Where(t => t.Id == id).FirstOrDefault();
            return View(table);
        }

        [HttpPost]
        public ActionResult Edit(int id, Table student)
        {
            if (ModelState.IsValid)
            {
                Table table = new Table();
                table.Name = student.Name;
                table.Id = student.Id;
                table.Gender = student.Gender;
                table.City = student.City;
                table.Stream = student.Stream;
                BadEntities1 entities = new BadEntities1();
                entities.Entry(table).State = EntityState.Modified;
                entities.SaveChanges();



                return RedirectToAction("Index");
            }

            return View(student);




        }

        [HttpGet]

        public ActionResult Delete(int id)
        {
            BadEntities1 entities = new BadEntities1();
            return View(entities.Tables.Where(t => t.Id == id).FirstOrDefault());

        }

        [HttpPost]

        public ActionResult Delete(int id, Student student)
        {
            BadEntities1 entities = new BadEntities1();
            Table table = entities.Tables.Where(t => t.Id == id).FirstOrDefault();
            entities.Tables.Remove(table);
            entities.SaveChanges();



            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult Details(int id)
        {


            BadEntities1 entities = new BadEntities1();
            var table = entities.Tables.Where(t => t.Id == id).FirstOrDefault();
            Student student = new Student();
            student.City = table.City;
            student.Id = table.Id;
            student.Gender = table.Gender;
            student.Name = table.Name;
            student.Stream = table.Stream;

            return View(student);
        }
        public ActionResult GetStudents(int department)
        {
            BadEntities1 entities = new BadEntities1();
            var tables = entities.Tables.Where(t => t.Department_id == department).ToList();
            return View(tables);
        }


    }
}
