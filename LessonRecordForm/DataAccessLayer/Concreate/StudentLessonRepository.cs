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
    public class StudentLessonRepository:BaseRepository<StudentLesson>,IStudentlessonRepository
    {
        private readonly LessonRecordFormContext _conText;
        public StudentLessonRepository(LessonRecordFormContext context):base(context)
        {
            _conText = context;
        }
        private LessonRecordFormContext Context
        {
            get { return _context as LessonRecordFormContext; }
        }

       
    }
}
