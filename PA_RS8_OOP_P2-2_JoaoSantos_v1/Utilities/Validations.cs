﻿using System;
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

        public static string ValidateName(string name)
        {
            if (name.Length <= 100)
            {
                return name;
            }
            else
            {
                string message = "Nome inválido. Máximo 100 caracteres.";
                Console.WriteLine(message);
                return message;
            }
        }

        public static string ValidateCode(string code)
        {
            if (code.Length > 6 || code.Length < 4)
            {
                string message = "Código inválido. Minimo 4 e máximo 6 caracteres.";
                Console.WriteLine(message);
                return message;
            }
            else
            {
                return code;
            }
        }

        public static string ValidatePass(string pass)
        {
            if (pass.Length > 12 || pass.Length < 8)
            {
                string message = "Palavra-passe inválida. Minimo 8 e máximo 12 caracteres.";
                Console.WriteLine(message);
                return message;
            }
            else
            {
                return pass;
            }
        }

        public static DateTime ValidateBirthDate()
        {
            DateTime dateTime;
            bool valid;
            do
            {
                string birth = Utilities.Basics.AskData("Data de Nascimento (dd/mm/aaaa)");
                valid = DateTime.TryParse(birth, out dateTime);
                if (valid == false || dateTime >= DateTime.Today)
                {
                    Console.WriteLine("Data de nascimento inválida.");
                }

            } while (valid == false || dateTime >= DateTime.Today);
            
            return dateTime;

        }

        public static string ValidateVatAndPhone(string vatPhone)
        {
            //ToDo JPS: Aceita letras
            if (vatPhone.Length != 9 )
            {
                string message = "Valor inválido. 9 Caracteres numéricos obrigatórios.";
                Console.WriteLine(message);
                return message;
            }
            else
            {
                return vatPhone;
            }
        }

        public static string ValidateAdress(string adress)
        {
            if (adress.Length <= 200)
            {
                return adress;
            }
            else
            {
                string message = "Máximo 200 caracteres.";
                Console.WriteLine(message);
                return message;
            }
        }

        public static string ValidateObs(string obs)
        {
            if (obs.Length <= 255)
            {
                return obs;
            }
            else
            {
                string message = "Máximo 255 caracteres.";
                Console.WriteLine(message);
                return message;
            }
        }

        public static string ValidatePTCode(string code)
        {
            //ToDo JPS: Aceita letras
            if (code.Length != 4)
            {
                string message = "Código inválido. 4 Caracteres obrigatórios.";
                Console.WriteLine(message);
                return message;
            }
            else
            {
                return code;
            }
        }
    }
}
