﻿using RSGymAdministrative_Client.Repository;
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

        //ToDo JPS: Corrigir o switch (desnecessário)
        #region LogIn Menu
        public static string LogIn()
        {
            Utilities.Basics.Title01("RSGym Administration :: Menu de Credenciais");
                
            Console.Write("Código de Utilizador: ");
            string codeReaded = Console.ReadLine();
            Console.Write("Password: ");
            string passReaded = Console.ReadLine();

            string userType = Utilities.Validations.ValidateLogIn(codeReaded, passReaded);

            //Console.WriteLine($"Entraste como {userType}");
            return userType;
        }
        #endregion

        //ToDo JPS: Corrigir o switch (desnecessário)
        #region General Menu
        #region Admin
        public static string GeneralMenuAdmin()
        {
            Dictionary<string, string> menu2Admin = Utilities.Menu02_General.Menu2AdminCreate();
            string validation;

            do
            {
                Utilities.Basics.ListMenu(menu2Admin, "Menu de Administração - Admin");

                Console.Write("\nOpção: ");
                string readed = Console.ReadLine();
                validation = Utilities.Validations.MenuOptionReaded(menu2Admin, readed);

                switch (validation)
                {
                    case "1":
                        Console.Clear(); // Colaboradores
                        break;
                    case "2":
                        Console.Clear(); // Clientes
                        break;
                    case "3":
                        Console.Clear(); // Personal Trainers
                        break;
                    case "4":
                        Console.Clear(); // Pedidos
                        break;
                    case "0":
                        // ToDo JPS: Mensagem Final de Final de Sessão, Admin
                        Console.Clear(); // Voltar
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

        #region Colab
        public static string GeneralMenuColab()
        {
            Dictionary<string, string> menu2Colab = Utilities.Menu02_General.Menu2ColabCreate();
            string validation;

            do
            {
                Utilities.Basics.ListMenu(menu2Colab, "Menu de Administração - Colab");

                Console.Write("\nOpção: ");
                string readed = Console.ReadLine();
                validation = Utilities.Validations.MenuOptionReaded(menu2Colab, readed);

                switch (validation)
                {
                    case "1":
                        Console.Clear(); // Clientes
                        break;
                    case "2":
                        Console.Clear(); // Personal Trainers
                        break;
                    case "3":
                        Console.Clear(); // Pedidos
                        break;
                    case "0":
                        // ToDo JPS: Mensagem Final de Final de Sessão, Colab
                        Console.Clear(); // Voltar
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
        #endregion

        #region User Administration Menu
        public static string UserAdministrationMenu()
        {
            Dictionary<string, string> menu3 = Utilities.Menu03_UserAdministration.Menu3Create();
            string validation;

            do
            {
                Utilities.Basics.ListMenu(menu3, "Menu de Utilizadores");

                Console.Write("\nOpção: ");
                string readed = Console.ReadLine();
                validation = Utilities.Validations.MenuOptionReaded(menu3, readed);

                switch (validation)
                {
                    case "1":
                        Console.Clear(); // Criar
                        break;
                    case "2":
                        Console.Clear(); // Alterar
                        break;
                    case "3":
                        Console.Clear(); // Consultar
                        break;
                    case "0":
                        Console.Clear(); // Voltar
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
    }
}
