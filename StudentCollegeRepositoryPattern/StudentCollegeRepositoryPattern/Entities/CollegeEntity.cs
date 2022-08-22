using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCollegeRepositoryPattern.Entities
{
    public class CollegeEntity
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        [Required, MaxLength(30)]
        public string University { get; set; }

        [Required, MaxLength(30)]
        public string Address { get; set; }

        public string District { get; set; }
    }
}
