using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
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
            bool isValid = Regex.IsMatch(name, @"^[a-zA-Z]{3,100}$");

            if (isValid)
            {
                return name;
            }
            else
            {
                string message = "Dados inválidos. Minimo 3 e máximo 100 caracteres alfabéticos.";
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
            Regex number = new Regex(@"^\d{9}$");
            if (number.IsMatch(vatPhone))
            {
                return vatPhone;
            }
            else
            {
                string message = "Valor inválido. 9 Caracteres numéricos obrigatórios.";
                Console.WriteLine(message);
                return message;
            }
        }

        public static string ValidateMail(string mail)
        {
            Regex mailRe = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (mailRe.IsMatch(mail))
            {
                return mail;
            }
            else
            {
                string message = "Email inválido.";
                Console.WriteLine(message);
                return message;
            }
        }

        public static bool FindVatClient(string vat)
        {
            using (var db = new _DatabaseContext())
            {
                var queryVat = db.Client.Select(c => c.ClientVat).ToList();
                if (queryVat.Contains(vat))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool FindVatPt(string vat)
        {
            using (var db = new _DatabaseContext())
            {
                var queryPt = db.PersonalTrainer.Select(p => p.PtVat).ToList();
                if (queryPt.Contains(vat))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string ValidateAdress(string adress)
        {
            if (adress.Length > 3 || adress.Length <= 200)
            {
                return adress;
            }
            else
            {
                string message = "Mínimo 3 e máximo 200 caracteres.";
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

        public static string ValidateID(string id)
        {
            string message;
            bool valid = int.TryParse(id, out int idConverted);
            if (!valid)
            {
                message = "ID inválido.";
                Console.WriteLine(message);
            }
            else 
            {
                using (var context = new _DatabaseContext())
                {
                    var user = context.User.FirstOrDefault(u => u.UserID == idConverted);
                    if (user != null)
                    {
                        message = id;
                    }
                    else
                    {
                        message = "ID inválido.";
                        Console.WriteLine(message);
                    }
                }
            }
            return message;
        }

        public static string ValidadeZipCode(string zip)
        {
            Regex zipCode = new Regex(@"^\d{4}-\d{3}$");
            string message;

            if (zipCode.IsMatch(zip))
            {
                message = zip;
            }
            else
            {
                message = "Código-Postal inválido. Formato Correto: XXXX-XXX.";
                Console.WriteLine(message);
            }
            return message;
        }

        public static bool FindZipCode(string zip)
        {
            using (var db = new _DatabaseContext())
            {
                var queryZip = db.ZipCode.Select(z => z.Zip).ToList();
                if (queryZip.Contains(zip) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static int FindMaxIdZipCode()
        {
            using (var db = new _DatabaseContext())
            {
                return db.ZipCode.Max(z => z.ZipCodeID); 
            }
        }

        public static int FindIdZipCode(string zip)
        {
            using (var db = new _DatabaseContext())
            {
                int id = 0;
                var zipQuery = db.ZipCode.Where(z => z.Zip == zip).FirstOrDefault();
                if (zipQuery != null)
                {
                    id = zipQuery.ZipCodeID;
                }
                return id;            
            }
        }

    }
}
