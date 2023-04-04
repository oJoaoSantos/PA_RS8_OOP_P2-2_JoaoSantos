using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSGymAdministrative_DAL.Model;

namespace Utilities
{
    public class Validations
    {
        public static string MenuOptionReaded(Dictionary<string, string> menu, string readed)
        {
            if (menu.ContainsKey(readed))
            {
                return readed;
            }
            else
            {
                return "Opção inválida. Tenta de novo, com uma opção da lista.";
            };
        }

        public static string ValidateLogIn(string code, string passWord)
        {
            using (var db = new _DatabaseContext())
            {
                var queryUser = db.User.Select(u => u).Where(u=> u.Code == code.ToUpper() && u.PassWord == passWord);
                queryUser.ToList().ForEach(u => Console.WriteLine($"\nBem vindo {u.UserName} - Utilizador do Tipo {u.PermissionType}"));
                if (queryUser.Select(u => u.PermissionType).ToList().Contains(User.EnumPermissionType.Colab))
                {
                    return "Colab";
                }
                else if (queryUser.Select(u => u.PermissionType).ToList().Contains(User.EnumPermissionType.Admin))
                {
                    return "Admin";
                }
                else 
                {
                    return "Credenciais Inválidas";
                }
            }
        }
    }
}
