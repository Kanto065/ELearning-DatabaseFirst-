using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryRepo : IRepository<Category, int>
    {
        ELearningEntities db;
        public CategoryRepo(ELearningEntities db)
        {
            this.db = db;
        }
        public void Add(Category e)
        {
            db.Category.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Category.FirstOrDefault(x=>x.Id == id);
            db.Category.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Category e)
        {
            var d = db.Category.FirstOrDefault(x => x.Id == e.Id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Category> Get()
        {
            return db.Category.ToList();
            
        }

        public Category Get(int id)
        {
            return db.Category.FirstOrDefault(x=>x.Id==id);
        }
    }
}
