using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Firstproject.Models
{
    [Table("Department")]
    public class Department
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> departments { get; set; }
    }
}