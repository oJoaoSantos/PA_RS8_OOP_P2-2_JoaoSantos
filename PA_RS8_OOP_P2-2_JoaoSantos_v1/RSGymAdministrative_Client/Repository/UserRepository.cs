using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using RSGymAdministrative_Client.Structure;
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

        #region Read
        public static void ReadUser()
        {
            Console.Clear();
            Utilities.Basics.Title01("Consulta de Utilizadores");
            Utilities.Basics.BlockSeparator(1);

            using (var context = new _DatabaseContext())
            {
                var readUser = context.User.Select(u => u).OrderBy(u => u.Code);
                readUser.ToList().ForEach(u => Console.WriteLine($"Código: {u.Code} | ID: {u.UserID} | Perfil: {u.PermissionType} | Nome: {u.UserName}"));
            }
        }
        #endregion

        #region Update Password

        #endregion

        #region New User
        public static User AskNewUser()
        {
            User user = new User();

            Console.Clear();
            Utilities.Basics.Title01("Criação de um Novo Utilizador");
            Utilities.Basics.BlockSeparator(1);

            string valid = "";

            #region Name
            string userName = "";
            do
            {
                userName = Utilities.Basics.AskData("Nome");
                valid = Utilities.Validations.ValidateName(userName);
            } while (valid == "Nome inválido. Máximo 100 caracteres.");
            user.UserName = userName;
            #endregion

            #region Code
            string code = "";
            do
            {
                code = Utilities.Basics.AskData("Código");
                valid = Utilities.Validations.ValidateCode(code);
            } while (valid == "Código inválido. Minimo 4 e máximo 6 caracteres.");
            user.Code = code;
            #endregion

            #region Pass
            string pass = "";
            do
            {
                pass = Utilities.Basics.AskData("Palavra-passe");
                valid = Utilities.Validations.ValidatePass(pass);
            } while (valid == "Palavra-passe inválida. Minimo 8 e máximo 12 caracteres.");
            user.PassWord = pass;
            #endregion

            #region Type
            Console.WriteLine("Tipo de Utilizador:");
            string type = Menus.UserTypeMenu();
            switch (type)
            {
                case "1":
                    user.PermissionType = User.EnumPermissionType.Admin;
                    break;
                case "2":
                    user.PermissionType = User.EnumPermissionType.Colab;
                    break;
                default:
                    Console.WriteLine(type);
                    Console.ReadKey();
                    break;
            }
            #endregion
            //Console.WriteLine(user.UserName);
            //Console.WriteLine(user.Code);
            //Console.WriteLine(user.PassWord);
            //Console.WriteLine(user.PermissionType);
            //Console.ReadKey();
            return user;
        }
        #endregion
    }
}
