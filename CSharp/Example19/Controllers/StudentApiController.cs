using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example19.Models;
using Microsoft.AspNetCore.Mvc;
using School.Data;

namespace Example19.Controllers
{
    [Route("api/student")]
    public class StudentApiController : Controller
    {
        private SchoolDbContext _schoolDbContext;

        public StudentApiController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _schoolDbContext.Students.ToList();
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult GetById(int id)
        {
            var student = _schoolDbContext.Students.FirstOrDefault(s => s.ID == id);

            if (student == null)
                return NotFound();

            return new ObjectResult(student);
        }
    }
}