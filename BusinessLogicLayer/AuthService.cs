using AutoMapper;
using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class AuthService
    {
        static AuthService()
        {
            
        }
        public static TokenModel Authenticate(UserModel user)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
                c.CreateMap<UserModel, User>();
                c.CreateMap<Token, TokenModel>();
                c.CreateMap<TokenModel, Token>();
            });
            var mapper = new Mapper(config);

            var data = mapper.Map<User>(user);
            var result = DataAccessFactory.AuthDataAccess().Authenticate(data);

            var t = new TokenModel()
            {
                AccessToken = result.AccessToken,
                Id = result.Id,
                UserId = result.UserId,
                CreatedAt = result.CreatedAt,
                ExpiredAt = result.ExpiredAt,
            };

            //var token = mapper.Map<TokenModel>(result);

            return t;
        }
        public static bool IsAuthenticated(string token)
        {
            var rs = DataAccessFactory.AuthDataAccess().IsAuthenticated(token);
            return rs;
        }

        public static bool IsRoleAuthenticated(string token)
        {
            var rs = DataAccessFactory.AuthDataAccess().IsRoleAuthenticated(token);
            return rs;
        }

        public static bool Logout(string token)
        {
            return DataAccessFactory.AuthDataAccess().Logout(token);
        }

    }
}
