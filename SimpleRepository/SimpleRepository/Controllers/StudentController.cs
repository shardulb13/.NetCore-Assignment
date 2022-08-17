using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleRepository.Data;
using SimpleRepository.Interface;
using SimpleRepository.Model;
using SimpleRepository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;
        private readonly StudentRepo studentRepoClassObject;

        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;

            studentRepoClassObject = new StudentRepo();
        }

        //public StudentController()
        //{
        //    studentRepoClassObject = new StudentRepo();
        //}

        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            return Ok(await _studentRepo.GetAllStudents());

            //// #BELOW LINE OF CODE IS PERFORMED BY USING CREATING OBJECT OF SERVICE CLASS.....
            //var result = await studentRepoClassObject.GetAllStudents();
            //return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudentsById(int id)
        {
            return Ok(await _studentRepo.GetStudentById(id));

            //var result = await studentRepoClassObject.GetStudentById(id);
            //return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddStudents(Student studobj)
        {
            return Ok(await _studentRepo.AddStudent(studobj));

            //var addStudent = await studentRepoClassObject.AddStudent(studobj);
            //return Ok(addStudent);
        }

        [HttpPut]
        public async Task<Student> UpdateStudents(Student studobj)
        {
            var updateStudent = await _studentRepo.UpdateStudent(studobj);
            return updateStudent;

            //return await studentRepoClassObject.UpdateStudent(studobj);
        }

        [HttpDelete]
        public async Task<Student> DeleteStudents(int id)
        {
            //var deleteStudent = await _studentRepo.DeleteStudent(id);
            //return deleteStudent;

            return await studentRepoClassObject.DeleteStudent(id);
        }

    }
}
