using Microsoft.EntityFrameworkCore;
using StudentCollegeRepositoryPattern.Data;
using StudentCollegeRepositoryPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCollegeRepositoryPattern.DAL
{
    public interface ICollegeDA
    {
        IEnumerable<CollegeEntity> GetAll();
        CollegeEntity GetById(int id);
        Task<CollegeEntity> AddCollege(CollegeEntity clgObj);
        CollegeEntity UpdateCollege(CollegeEntity updateClg, int id);
        CollegeEntity DeleteCollege(int id);
    }
    public class CollegeDA : ICollegeDA
    {
        private readonly ApplicationDbContext _context;

        public CollegeDA(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<CollegeEntity> AddCollege(CollegeEntity clgObj)
        {
            var data = await _context.CollegeTable.AddAsync(clgObj);
            _context.SaveChanges();
            return data.Entity; 
        }

        public CollegeEntity DeleteCollege(int id)
        {
            var result = _context.CollegeTable.Where(a => a.Id == id).FirstOrDefault();
            if (result!=null)
            {
                _context.CollegeTable.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }

        public IEnumerable<CollegeEntity> GetAll()
        {
            return _context.CollegeTable.ToList();
        }

        public CollegeEntity GetById(int id)
        {
            return _context.CollegeTable.FirstOrDefault(a=> a.Id == id);
        }

        public CollegeEntity UpdateCollege(CollegeEntity updateClg, int id)
        {
            var update = _context.CollegeTable.Where(a => a.Id == id).ToList();
            foreach (var data in update)
            {
                if (data.Id == id)
                {
                    data.Name = updateClg.Name;
                    data.University = updateClg.University;
                    data.Address = updateClg.Address;
                    data.District = updateClg.District;
                    var updatedData = _context.CollegeTable.Update(data);
                    _context.SaveChanges();
                    return updatedData.Entity;
                }
            }
            return updateClg;
        }
    }
}
