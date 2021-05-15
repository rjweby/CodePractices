using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Firstproject.Models
{
    
    public class StudentContext:DbContext
    {
        public DbSet<Student> student { get; set; }
        
      
    }
}