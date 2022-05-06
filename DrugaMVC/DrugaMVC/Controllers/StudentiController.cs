using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrugaMVC.Models;

namespace DrugaMVC.Controllers
{
    public class StudentiController : Controller
    {
        // GET: Studenti
        public ActionResult Index()
        {
            var studentList = new List<student>{
 new student() { Studentid = 1, Studentname = "John", Age = 18 } ,
 new student() { Studentid = 2, Studentname = "Steve", Age = 21 } ,
 new student() { Studentid = 3, Studentname = "Bill", Age = 25 } ,
 new student() { Studentid = 4, Studentname = "Ram" , Age = 20 } ,
 new student() { Studentid = 5, Studentname = "Ron" , Age = 31 } ,
 new student() { Studentid = 4, Studentname = "Chris" , Age = 17 } ,
 new student() { Studentid = 4, Studentname = "Rob" , Age = 19 }
 };
            return View(studentList);
        }
        public ActionResult TestRazorja()
            
        {
            student miha = new student()
            {
                Studentid = 12,
                Studentname = "Miha",
                Age = 21
            };
            return View(miha);
        }
        public ActionResult Edit(int? id)
        {
            var studentList = new List<student>{
 new student() { Studentid = 1, Studentname = "John", Age = 18 } ,
 new student() { Studentid = 2, Studentname = "Steve", Age = 21 } ,
 new student() { Studentid = 3, Studentname = "Bill", Age = 25 } ,
 new student() { Studentid = 4, Studentname = "Ram" , Age = 20 } ,
 new student() { Studentid = 5, Studentname = "Ron" , Age = 31 } ,
 new student() { Studentid = 4, Studentname = "Chris" , Age = 17 } ,
 new student() { Studentid = 4, Studentname = "Rob" , Age = 19 }
 };
            var miha = studentList.Where(a => a.Studentid == id).FirstOrDefault();
            return View(miha);

        }
        [HttpPost]
        public ActionResult Edit([Bind(Include ="Studentid,Studentname")]student std)
        {
            string x = std.Studentname;
            //dejansko posodobi bazo
            return RedirectToAction("Index");
        }
    }
}