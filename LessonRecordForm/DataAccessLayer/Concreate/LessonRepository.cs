using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate
{
    public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(LessonRecordFormContext context):base(context)
        {

        }
        private LessonRecordFormContext Context
        {
            get { return _context as LessonRecordFormContext; }
        }

        
    }
}
