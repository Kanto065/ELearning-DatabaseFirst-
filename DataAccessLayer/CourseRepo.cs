using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CourseRepo
    {
        static ELearningEntities db;
        static CourseRepo()
        {
            db = new ELearningEntities();
        }

        public static List<Course> Get()
        {   
            return db.Course.ToList();
        }

        public static Course Get(int id)
        {
            return db.Course.FirstOrDefault(x => x.Id == id);
        }

        public static void Edit(Course c)
        {
            var ds = db.Course.FirstOrDefault(x => x.Id == c.Id);
            db.Entry(ds).CurrentValues.SetValues(c);
            db.SaveChanges();
        }
        public static void Delete(int id)
        {
            var ds = db.Course.FirstOrDefault(x=> x.Id == id);
            db.Course.Remove(ds);
        }

        public static void Add(Course c)
        {
            db.Course.Add(c);
            db.SaveChanges();
        }

    }
}
