using SimpleRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRepository.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int studId);
        Task<Student> AddStudent(Student studobj);
        Task<Student> UpdateStudent(Student studobj);
        Task<Student> DeleteStudent(int id);
    }
}
