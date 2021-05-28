using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Firstproject.Models
{
    [Table("Tables")]
    public class Student
    {
        internal int? department_id;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Stream { get; set; }
    }
}