using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoleRepo : IRepository<Role, int>
    {
        ELearningEntities db;
        public RoleRepo(ELearningEntities db)
        {
            this.db = db;
        }
        public bool Add(Role e)
        {
            db.Role.Add(e);
            db.SaveChanges();
            return true;
        }

        public void Delete(int id)
        {
            var s = db.Role.FirstOrDefault(e => e.Id == id);
            db.Role.Remove(s);
            db.SaveChanges();
        }

        public void Edit(Role e)
        {
            var s = db.Role.FirstOrDefault(c => c.Id == e.Id);
            db.Entry(s).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Role> Get()
        {
            return db.Role.ToList();
        }

        public Role Get(int id)
        {
            return db.Role.FirstOrDefault(c => c.Id == id);
        }
    }
}
