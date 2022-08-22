using StudentCollegeRepositoryPattern.DataAccess;
using StudentCollegeRepositoryPattern.Entities;
using StudentCollegeRepositoryPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCollegeRepositoryPattern.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        Task<Student> AddStudent(Student studObj);
        Student UpdateStudent(Student updateStud, int id);
        Student DeleteStudent(int id);

    }
    public class StudentService : IStudentService
    {
        private readonly IStudentDA StudentDA;
        public StudentService(IStudentDA StudentDA)
        {
            this.StudentDA = StudentDA;
        }

        public async Task<Student> AddStudent(Student studObj)
        {
            var obj = new StudentEntity
            {
                FirstName = studObj.FirstName,
                LastName = studObj.LastName,
                Email = studObj.Email,
                Phone = studObj.Phone,
                DateOfBirth = studObj.DateOfBirth,
                CollegeId = studObj.CollegeId
            
            };

            var result = await StudentDA.AddStudent(obj);
            return new Student
            {
                Id = result.Id
            };

        }

        public Student DeleteStudent(int id)
        {
            var deleteData = StudentDA.DeleteStudent(id);
            return new Student
            {
                FirstName = deleteData.FirstName,
                LastName = deleteData.LastName,
                Email = deleteData.Email,
                Phone = deleteData.Phone,
                DateOfBirth = deleteData.DateOfBirth,
                CollegeId = deleteData.CollegeId
            };
        }

        public IEnumerable<Student> GetAll()
        {
            var students = StudentDA.GetAll();
            return (from std in students
                    select new Student
                    {
                        Id = std.Id,
                        FirstName = std.FirstName,
                        LastName = std.LastName,
                        Email = std.Email,
                        Phone = std.Phone,
                        DateOfBirth = std.DateOfBirth,
                        CollegeId = std.CollegeId
                    }).ToList();
        }

        public Student GetById(int id)
        {
            var studentData = StudentDA.GetById(id);
            if (studentData != null)
            {
                return new Student
                {
                    Id  = studentData.Id,
                    FirstName = studentData.FirstName,
                    LastName = studentData.LastName,
                    Email = studentData.Email,
                    Phone = studentData.Phone,
                    DateOfBirth = studentData.DateOfBirth,
                    CollegeId = studentData.CollegeId
                };
            }
            else
            {
                return null;
            }
        }

        public Student UpdateStudent(Student updateStud, int id)
        {
            var obj = new StudentEntity
            {
               Id = updateStud.Id,
               FirstName = updateStud.FirstName,
               LastName = updateStud.LastName,
               Email= updateStud.Email,
               Phone = updateStud.Phone,
               DateOfBirth = updateStud.DateOfBirth,
               CollegeId = updateStud.CollegeId

            };
            var updatedata = StudentDA.UpdateStudent(obj, id);
            return new Student
            {
                Id = updatedata.Id,
                FirstName = updatedata.FirstName
             };
            
          
        }
    }
}
