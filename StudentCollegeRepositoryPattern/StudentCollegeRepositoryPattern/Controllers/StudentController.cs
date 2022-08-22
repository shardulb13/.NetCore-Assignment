using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCollegeRepositoryPattern.Model;
using StudentCollegeRepositoryPattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCollegeRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(studentService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(studentService.GetById(id));
        }

        [HttpPost]
        public IActionResult AddStudent(Student studObj)
        {
            return Ok(studentService.AddStudent(studObj));
        }

        [HttpPut]
        public IActionResult UpdateStudent(Student updateStud)
        {
            return Ok(studentService.UpdateStudent(updateStud));
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            return Ok(studentService.DeleteStudent(id));
        }



    }
}
