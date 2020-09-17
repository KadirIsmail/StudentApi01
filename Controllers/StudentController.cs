using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi01.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApi01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _db;

        public StudentController(StudentDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public List<Student> GetStudents()//select
        {
            var StudList = _db.Students.AsNoTracking().ToList();
            return StudList;
        }

        //Get Students by Id
        [HttpGet("{id}")]
        public Student GetEmployeeById(int id)
        {
            Student Stud = _db.Students.FirstOrDefault(s => s.Id == id);
            return Stud;
        }

        [HttpPost]
        public string Create(Student objStudent)
        {
            _db.Students.Add(objStudent);
            _db.SaveChanges();
            return "Save Successfully";
        }

        //Update Students Info
        [HttpPut("{id}")]
        public string UpdateStudent(Student objStudent)
        {
            _db.Students.Update(objStudent);
            _db.SaveChanges();
            return "Update Successfully";
        }


        //Delete students
        [HttpDelete("{id}")]
        public string DeleteEmployee(Student objStudent)
        {
            _db.Remove(objStudent);
            _db.SaveChanges();
            return "Delete Successfully";
        }
    }
}
