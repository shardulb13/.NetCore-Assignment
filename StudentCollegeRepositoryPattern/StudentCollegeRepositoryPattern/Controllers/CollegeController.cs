using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCollegeRepositoryPattern.Model;
using StudentCollegeRepositoryPattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCollegeRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeService collegeService;
        public CollegeController(ICollegeService collegeService)
        {
            this.collegeService = collegeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(collegeService.GetAll());
        }

        [HttpGet("{collegeId}")]
        public IActionResult GetById(int collegeId)
        {
            return Ok(collegeService.GetById(collegeId));
        }

        [HttpPost]
        public IActionResult AddCollege(College collegeobj)
        {
            return Ok(collegeService.AddCollege(collegeobj));
        }

        [HttpPut]
        public IActionResult UpdateCollege(College updateClg)
        {
            return Ok(collegeService.UpdateCollege(updateClg));
        }

        [HttpDelete]
        public IActionResult DeleteCollege(int id)
        {
           return Ok(collegeService.DeleteCollege(id));
            
        }
    }
}
