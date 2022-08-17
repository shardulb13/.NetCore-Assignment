using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleRepository.Data;
using SimpleRepository.Interface;
using SimpleRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRepository.Services
{
    public class StudentRepo : IStudentRepository
    {
        private readonly ApplicationDbContext _DbContext;
        //public readonly DbSet<Student> _entities;

        public StudentRepo()
        {
            _DbContext = new ApplicationDbContext();
        }
        //public StudentRepo(ApplicationDbContext DbContext)
        //{
        //    _DbContext = DbContext;
        //    _entities = _DbContext.Set<Student>();
        //}

        public async Task<Student> AddStudent(Student studobj)
        {
            var addemp = await _DbContext.studentsTable.AddAsync(studobj);
            _DbContext.SaveChanges();
            return addemp.Entity;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var result = await _DbContext.studentsTable.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                _DbContext.studentsTable.Remove(result);
                await _DbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _DbContext.studentsTable.ToListAsync(); 
        }

        public async Task<Student> GetStudentById(int studId)
        {
            return await _DbContext.studentsTable.FirstOrDefaultAsync(a => a.Id == studId);   
        }

        public async Task<Student> UpdateStudent(Student studobj)
        {
            var result = await _DbContext.studentsTable.FirstOrDefaultAsync(a => a.Id == studobj.Id);
            if (result != null)
            {
                result.StudentName = studobj.StudentName;
                result.StudentClass = studobj.StudentClass;
                await _DbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
