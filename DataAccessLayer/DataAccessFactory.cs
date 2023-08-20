using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessFactory
    {
        static ELearningEntities db;
        static DataAccessFactory()
        {
            db = new ELearningEntities();
        }

        public static IRepository<Course, int> CourseDataAccess()
        {
            return new CourseRepo(db);
        }

        public static IRepository<Category, int> CategoryDataAccess()
        {
            return new CategoryRepo(db);
        }

        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }

        public static IRepository<Role, int> RoleDataAccess()
        {
            return new RoleRepo(db);
        }

        public static IAuth AuthDataAccess()
        {
            return new UserRepo(db);
        }
    }
}
