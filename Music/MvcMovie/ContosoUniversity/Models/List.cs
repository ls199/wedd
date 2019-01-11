using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class List
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Singer{ get; set; }
        public string Album { get; set; }
        public DateTime EnrollmentDate { get; set; }       

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}