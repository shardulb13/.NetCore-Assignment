using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StudentController
    {

        [HttpGet]
        public List<Student> GetStudent()
        {
            return StudentDetails();
        }
       
        [HttpPost]
        public string PostStudent()
        {
            return "This is post method";
        }

        [HttpPut]
        public string PutStudents()
        {
            return "This is put Method";
        }

       
        List<Student> StudentDetails()
        {
            return new List<Student>()
            {
                new Student()
                {
                    id = 1,
                    name = "Shardul"
                }
            };
        }
    }
}
