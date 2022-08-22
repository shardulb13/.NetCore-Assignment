using Microsoft.EntityFrameworkCore;
using StudentCollegeRepositoryPattern.Data;
using StudentCollegeRepositoryPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCollegeRepositoryPattern.DataAccess
{
    public interface IStudentDA
    {
        IEnumerable<StudentEntity> GetAll();
        StudentEntity GetById(int id);
        Task<StudentEntity> AddStudent(StudentEntity stdObj);
        StudentEntity UpdateStudent(StudentEntity updateStud, int id);
        StudentEntity DeleteStudent(int id);
    }
    public class StudentDA : IStudentDA
    {
        private readonly ApplicationDbContext _context;

        public StudentDA(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<StudentEntity> AddStudent(StudentEntity studObj)
        {
            var data = await _context.StudentTable.AddAsync(studObj);
            _context.SaveChanges();
            return data.Entity;
        }

        public StudentEntity DeleteStudent(int id)
        {
            var result = _context.StudentTable.Where(a => a.Id == id).FirstOrDefault();
            if (result != null)
            {
                _context.StudentTable.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }

        public IEnumerable<StudentEntity> GetAll()
        {
            return _context.StudentTable.ToList();
        }

        public StudentEntity GetById(int id)
        {
            return _context.StudentTable.FirstOrDefault(a => a.Id == id);
        }

        public StudentEntity UpdateStudent(StudentEntity updateStud, int id)
        {
            var update = _context.StudentTable.Where(a => a.Id == id).ToList();
            foreach (var data in update)
            {
                if (data.Id == id)
                {
                    data.FirstName = updateStud.FirstName;
                    data.LastName = updateStud.LastName;
                    data.Email = updateStud.Email;
                    data.Phone = updateStud.Phone;
                    data.DateOfBirth = updateStud.DateOfBirth;
                    data.CollegeId = updateStud.CollegeId;

                    var updatedData = _context.StudentTable.Update(data);
                    _context.SaveChanges();
                    return updatedData.Entity;
                }
            }
            return updateStud;
        }
    }
}
