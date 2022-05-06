using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate
{
     public class StudentRepository:BaseRepository<Student>,IStudentRepository
    {
        private readonly LessonRecordFormContext _context;
        public StudentRepository(LessonRecordFormContext context):base(context)
        {
            _context = context;
        }
        private LessonRecordFormContext Context
        {
            get { return _context as LessonRecordFormContext; }
        }
        public Student CombineStudentLessson(int id)
        {
            Student student = _context.Students
                .Where(x=>x.StudentId==id)
                .Include(x => x.StudentLessons)
                .ThenInclude(y => y.Lesson)
                .FirstOrDefault();
            return student;

            
        }
        

        
    }
}
