using StudentCollegeRepositoryPattern.DAL;
using StudentCollegeRepositoryPattern.Data;
using StudentCollegeRepositoryPattern.Entities;
using StudentCollegeRepositoryPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCollegeRepositoryPattern.Services
{
    public interface ICollegeService
    {
        IEnumerable<College> GetAll();
        College GetById(int id);
        Task<College> AddCollege(College collegeObj);
        College UpdateCollege(College updateCollege, int id);
        College DeleteCollege(int id);

    }
    public class CollegeService : ICollegeService
    {
        private readonly ICollegeDA CollegeDA;
        public CollegeService(ICollegeDA CollegeDA)
        {
            this.CollegeDA = CollegeDA;
        }

        public async Task<College> AddCollege(College collegeObj)
        {
            var obj = new CollegeEntity
            {
                Name = collegeObj.Name,
                University = collegeObj.University,
                Address = collegeObj.Address,

            };

            var result = await CollegeDA.AddCollege(obj);
            return new College { 
                Id = result.Id
            };
            
        }

        public College DeleteCollege(int id)
        {
            var deleteData = CollegeDA.DeleteCollege(id);
            return new College
            {
                Id = deleteData.Id,
                Name = deleteData.Name,
                University = deleteData.University,
                Address = deleteData.Address,
                District = deleteData.District
            };
        }

        public IEnumerable<College> GetAll()
        {
            var college = CollegeDA.GetAll();
            return (from clg in college
                    select new College
                    {
                        Id = clg.Id,
                        Name = clg.Name,
                        University = clg.University,
                        Address = clg.Address,
                        District = clg.District
                    }).ToList();
        }

        public College GetById(int id)
        {
            var collegeData = CollegeDA.GetById(id);
            if (collegeData != null)
            {
            return new College
            {
                Id = collegeData.Id,
                Name = collegeData.Name,
                University = collegeData.University,
                Address = collegeData.Address
            };
            }
            else
            {
                return null;
            }
        }

        public College UpdateCollege(College updateCollege, int id)
        {
            var obj = new CollegeEntity
            {
                //Id = updateCollege.Id,
                Name = updateCollege.Name,
                University = updateCollege.University,
                Address = updateCollege.Address,
                District = updateCollege.District

            };
            var updatedata = CollegeDA.UpdateCollege(obj, id);
            return new College
            {
                Id = updatedata.Id,
            };

        }
    }
}
