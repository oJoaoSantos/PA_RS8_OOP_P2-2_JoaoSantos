﻿using System;
using System.Linq;
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
                Code = code.ToUpper(),
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
            using (var context = new _DatabaseContext())
            {
                var readUser = context.User.Select(u => u).OrderBy(u => u.Code);
                readUser.ToList().ForEach(u => Console.WriteLine($" * Código: {u.Code} * ID: {u.UserID} * Perfil: {u.PermissionType} * Nome: {u.UserName} *"));
            }
        }
        #endregion

        #region Update Password
        public static void UpdateUserPassword(string pass, int id)
        {
            using (var context = new _DatabaseContext())
            {
                var userToUpdate = context.User.SingleOrDefault(p => p.UserID == id);

                if (userToUpdate != null)
                {
                    userToUpdate.PassWord = pass;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region New User
        public static User AskNewUser()
        {
            User user = new User();

            Console.Clear();
            Utilities.Basics.Title01("Criação de um Novo Utilizador");
            Utilities.Basics.BlockSeparator(1);
            Utilities.Basics.Title02("Lista de Colaboradores's");
            ReadUser();
            Utilities.Basics.BlockSeparator(1);

            string valid = "";

            #region Name
            string userName = "";
            do
            {
                userName = Utilities.Basics.AskData("Nome");
                valid = Utilities.Validations.ValidateName(userName);
            } while (valid == "Dados inválidos. Minimo 3 e máximo 100 caracteres alfabéticos.");
            user.UserName = userName;
            #endregion

            #region Code
            string code = "";
            do
            {
                code = Utilities.Basics.AskData("Código");
                valid = Utilities.Validations.ValidateCode(code);
            } while (valid == "Código inválido. 4 Caracteres obrigatórios, não pode ser repetido.");
            user.Code = code;
            #endregion

            #region Pass
            string pass = "";
            do
            {
                pass = Utilities.Basics.AskData("Palavra-passe");
                valid = Utilities.Validations.ValidatePass(pass);
            } while (valid == "Palavra-passe inválida. Minimo 8 e máximo 12 caracteres alfanuméricos.");
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
            
            return user;
        }
        #endregion

        #region New Pass
        public static User AskNewPass()
        {
            User user = new User();

            Console.Clear();
            Utilities.Basics.Title01("Alteração da Palavra-Pass de um Utilizador");
            Utilities.Basics.BlockSeparator(1);
            Utilities.Basics.Title02("Lista de Colaboradores");
            ReadUser();
            Utilities.Basics.BlockSeparator(1);

            string valid = "";

            #region ID
            string id = "";
            do
            {
                id = Utilities.Basics.AskData("ID do Utilizador a Alterar");
                valid = Utilities.Validations.ValidateID(id);
            } while (valid == "ID inválido.");
            user.UserID = int.Parse(valid);
            #endregion

            #region Pass
            string pass = "";
            do
            {
                pass = Utilities.Basics.AskData("Palavra-passe");
                valid = Utilities.Validations.ValidatePass(pass);
            } while (valid == "Palavra-passe inválida. Minimo 8 e máximo 12 caracteres alfanuméricos.");
            user.PassWord = pass;
            #endregion

            return user;
        }
        #endregion
    }
}
