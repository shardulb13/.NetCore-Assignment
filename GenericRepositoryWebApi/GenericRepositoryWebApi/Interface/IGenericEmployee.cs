using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryWebApi.Interface
{
   public interface IGenericEmployee<T> where T: class
    {
        List<T> GetAll();
        T GetbyId(object Id);
        public Task<T> AddEmp(T obj);
        public void UpdateEmp(T obj);
        T DeleteEmp(T obj);

    }
}
