using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRepository.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int StudentClass { get; set; }
    }
}
