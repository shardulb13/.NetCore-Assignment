using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCollegeRepositoryPattern.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string FirstName { get; set; }
        [Required, MaxLength(20)]
        public string LastName { get; set; }

        [Required, MaxLength(20), EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(10), Phone]
        public string Phone { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int CollegeId { get; set; }
    }
}
