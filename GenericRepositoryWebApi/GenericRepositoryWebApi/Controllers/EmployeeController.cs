using GenericRepositoryWebApi.Interface;
using GenericRepositoryWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        public readonly IGenericEmployee<Employee> _genericEmployee;
        public EmployeeController(IGenericEmployee<Employee> genericEmployee)
        {
            _genericEmployee = genericEmployee;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _genericEmployee.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddEmpDetails( Employee employee)
        {
           var resultset =  _genericEmployee.AddEmp(employee);
            return Ok(resultset);
        }

        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)
        {
            return _genericEmployee.GetbyId(id);
        }

        [HttpPut]
        public bool Update(Employee emp, int id)
        {
            int c = 0;
            var DataUpdate = _genericEmployee.GetAll().Where(obj => obj.Id == id).ToList();
            foreach (var UpdateData in DataUpdate)
            {
                if (UpdateData.Id == id)
                {

                    UpdateData.Firstname = emp.Firstname;
                    UpdateData.Lastname = emp.Lastname;
                    _genericEmployee.UpdateEmp(UpdateData);
                    c++;
                    return true;

                }

            }
            if (c < 1)
            {
                return false;
            }

            return   true;

        }

        [HttpDelete]
        public bool DeleteEmp(int id)
        {
        
            var dataDelete = _genericEmployee.GetAll().Where(obj => obj.Id == id).ToList();
            foreach (var data in dataDelete)
            {
                if (data.Id == id)
                {
                    _genericEmployee.DeleteEmp(data);
   
                    return true;
                }
             
            }
            return true;
        }

    }
}
