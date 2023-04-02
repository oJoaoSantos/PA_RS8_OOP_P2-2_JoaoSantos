using RSGymAdministrative_Client.Repository;
using RSGymAdministrative_DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RSGymAdministrative_Client.Structure
{
    // ToDo JPS: Pensar se vale a pena criar uma calsse só de Creates para poder abrir a BD menos tempo ****
    public class Menus
    {
        #region Initial Menu
        public static string InitialMenu()
        {
            Dictionary<string, string> menu1 = Utilities.Menu01_Initial.Menu1Create();
            string validation;
            
            do
            {
                Utilities.Basics.ListMenu(menu1, "Menu Inicial");

                Console.Write("\nOpção: ");
                string readed = Console.ReadLine();
                validation = Utilities.Validations.MenuOptionReaded(menu1, readed);

                switch (validation)
                {
                    case "1":
                        Console.Clear();
                        break;
                    case "0":
                        Console.Clear();
                        //ToDo JPS: Mensagem final
                        break;
                    default:
                        Console.WriteLine(validation);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (validation == "Opção inválida. Tenta de novo, com uma opção da lista.");            
            return validation;
        }
        #endregion

        #region LogIn Menu
        public static List<User.EnumPermissionType> LogIn()
        {
            Utilities.Basics.Title01("RSGym Administration :: Menu de Credenciais");
                
            Console.Write("Código de Utilizador: ");
            string codeReaded = Console.ReadLine();
            Console.Write("Password: ");
            string passReaded = Console.ReadLine();

            List<User.EnumPermissionType> userType = Utilities.Validations.ValidateLogIn(codeReaded, passReaded);            
            return userType;
        }
        #endregion

    }
}
