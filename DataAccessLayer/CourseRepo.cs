using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CourseRepo : IRepository<Course, int>
    {
        ELearningEntities db;
        public CourseRepo(ELearningEntities db)
        {
            this.db = db;
        }
        public void Add(Course e)
        {
            db.Course.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var s = db.Course.FirstOrDefault(e => e.Id == id);
            db.Course.Remove(s);
            db.SaveChanges();
        }

        public void Edit(Course e)
        {
            var s = db.Course.FirstOrDefault(c => c.Id == e.Id);
            db.Entry(s).CurrentValues.SetValues(e);
            db.SaveChanges();
            
        }

        public List<Course> Get()
        {
            return db.Course.ToList();
        }

        public Course Get(int id)
        {
            return db.Course.FirstOrDefault(c => c.Id == id);
        }
    }
}
