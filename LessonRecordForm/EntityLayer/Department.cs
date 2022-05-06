using System.Collections.Generic;

namespace EntityLayer
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentBoss { get; set; }
       
        public List<Student> Students { get; set; }

    }
}
