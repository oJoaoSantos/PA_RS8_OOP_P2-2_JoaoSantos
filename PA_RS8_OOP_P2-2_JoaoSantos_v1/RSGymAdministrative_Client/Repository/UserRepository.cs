using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using RSGymAdministrative_DAL.Model;


namespace RSGymAdministrative_Client.Repository
{
    static class UserRepository
    {
        #region Create
        public static void CreateUser(User.EnumPermissionType type, string name, string code, string pass)
        {
            User user = new User()
            {
                UserName = name,
                Code = code,
                PassWord = pass,
                PermissionType = type
            };

            using (var context = new _DatabaseContext())
            {
                context.User.Add(user);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
