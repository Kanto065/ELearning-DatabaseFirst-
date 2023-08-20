using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string UserName { get; set; }

        public virtual RoleModel Role { get; set; }
    }
}
