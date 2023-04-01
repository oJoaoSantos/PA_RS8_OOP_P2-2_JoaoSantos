using RSGymAdministrative_Client.Repository;
using RSGymAdministrative_DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace RSGymAdministrative_Client.Structure
{
    // ToDo JPS: Pensar se vale a pena criar uma calsse só de Creates para poder abrir a BD menos tempo ****
    public class Menus
    {
        #region Initial Menu
        public static void InitialMenu()
        {
            Dictionary<int, string> menu1 = Utilities.Menu01_Initial.Menu1Create();
            string validation;

            do
            {
                Utilities.Basics.ListMenu(menu1, "Menu Inicial");
                Console.Write("\nOpção: ");
                string readed = Console.ReadLine();
                validation = Utilities.Validations.MenuOptionReaded(menu1, readed);
                if (validation != "ok")
                {
                    Console.WriteLine(validation);
                }
                Console.ReadKey();
                Console.Clear();
            } while (validation != "ok");
        }
        #endregion

        #region LogIn Menu
        public static User.EnumPermissionType LogIn()
        {
            Utilities.Basics.Title01("RSGym Administration :: Menu de Credenciais");

            Console.Write("Código de Utilizador: ");
            string codeReaded = Console.ReadLine();
            Console.Write("Password: ");
            string passReaded = Console.ReadLine();

            //ToDo JPS: Validation
            User.EnumPermissionType userType = User.EnumPermissionType.Admin; // Default = Colab, mas é para tirar.

            Console.ReadKey();

            return userType;
        }
        #endregion

    }
}
