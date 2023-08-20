using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepo: IRepository<User, int>, IAuth
    {
        ELearningEntities db;
        public UserRepo(ELearningEntities db)
        {
            this.db = db;
        }

        public bool Add(User e)
        {
            var s = db.User.FirstOrDefault(c => c.Email == e.Email);
            if (s != null)
            {
                return false;
            }
            db.User.Add(e);
            db.SaveChanges();
            return true;
        }

        public void Delete(int id)
        {
            var s = db.User.FirstOrDefault(e => e.Id == id);
            db.User.Remove(s);
            db.SaveChanges();
        }

        public void Edit(User e)
        {
            var s = db.User.FirstOrDefault(c => c.Id == e.Id);
            db.Entry(s).CurrentValues.SetValues(e);
            db.SaveChanges();

        }

        public List<User> Get()
        {
            return db.User.ToList();
        }

        public User Get(int id)
        {
            return db.User.FirstOrDefault(c => c.Id == id);
        }

        public Token Authenticate(User user)
        {
            var u = db.User.FirstOrDefault(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password));
            Token t = null;
            if(u != null)//authenticated
            {
                string token = Guid.NewGuid().ToString();
                t = new Token();
                t.UserId = u.Id;
                t.AccessToken = token;
                t.CreatedAt = DateTime.Now;
                db.Token.Add(t);
                db.SaveChanges();
            }
            return t;   
        }


        public bool IsAuthenticated(string token)
        {
            var rs = db.Token.Any(e=> e.AccessToken.Equals(token)&& e.ExpiredAt==null);
            return rs;
        }

        public bool IsRoleAuthenticated(string token)
        {
            var validToken = db.Token.FirstOrDefault(e => e.AccessToken.Equals(token) && e.ExpiredAt == null);
            if (validToken != null)
            {
                var user = db.User.FirstOrDefault(e => e.Id == validToken.UserId);
                if(user.RoleId == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Logout(string token)
        {
            var t = db.Token.FirstOrDefault(e => e.AccessToken.Equals(token));
            if(t != null)
            {
                t.ExpiredAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
