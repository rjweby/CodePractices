using Firstproject.Models;
using Firstproject.Repository.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Firstproject.Controllers
{



    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            BadEntities entities = new BadEntities();
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
            BadEntities entities = new BadEntities();
            entities.Tables.Add(table);
            entities.SaveChanges();



            return Redirect("Index");
                

           

        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            BadEntities entities = new BadEntities();
            var table = entities.Tables.Where(t => t.Id == id).FirstOrDefault();
            return View(table);
        }

        [HttpPost]
        public ActionResult Edit(int id,Student student)
        {
            if (ModelState.IsValid)
            {
                Table table = new Table();
                table.Name = student.Name;
                table.Id = student.Id;
                table.Gender = student.Gender;
                table.City = student.City;
                table.Stream = student.Stream;
                BadEntities entities = new BadEntities();
                entities.Entry(table).State = EntityState.Modified;
                entities.SaveChanges();



                return RedirectToAction("Index");
            }
            
                return View(student);
            



        }

        [HttpGet]

        public ActionResult Delete(int id)
        {
            BadEntities entities = new BadEntities();
            return View(entities.Tables.Where(t => t.Id == id).FirstOrDefault());
            
        }

        [HttpPost]

        public ActionResult Delete(int id,Student student)
        {
            BadEntities entities = new BadEntities();
            Table table = entities.Tables.Where(t => t.Id == id).FirstOrDefault();
            entities.Tables.Remove(table);
            entities.SaveChanges();



            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult Details(int id)
        {


            BadEntities entities = new BadEntities();
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
            BadEntities entities = new BadEntities();
            var tables = entities.Tables.Where(t => t.Department_id == department).ToList();
            return View(tables);
        }


    }
}
