using AutoMapper;
using BusinessEntityLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class RegistrationService
    {
        public static bool Add(UserModel user)
        {
            var config = new MapperConfiguration(u =>
            {
                u.CreateMap<UserModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(user);
            var rs = DataAccessFactory.UserDataAccess().Add(data);
            return rs;
        }

        public static List<RoleModel> GetRole()
        {
            var config = new MapperConfiguration(r =>
            {
                r.CreateMap<Role, RoleModel>();
                r.CreateMap<RoleModel, Role>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.RoleDataAccess();
            var data = mapper.Map<List<RoleModel>>(da.Get());
            return data;
        }
    }
}
