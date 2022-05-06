using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        [NotMapped]
        public string StudentFullName { get { return StudentName + " " + StudentSurname; } }
        public DateTime StudentBirthDay { get; set; }
        public DateTime StudentRecortDate { get; set; }
        public char StudentTerm { get; set; }
        public List<StudentLesson> StudentLessons { get; set; }
        public int StudentDepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
