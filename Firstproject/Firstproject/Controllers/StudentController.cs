using Firstproject.Models;
using Firstproject.Repository.Db;
using System;
using System.Collections.Generic;
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

       
        
    }
}
