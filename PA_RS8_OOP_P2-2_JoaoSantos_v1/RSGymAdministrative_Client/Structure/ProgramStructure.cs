using RSGymAdministrative_Client.Repository;
using RSGymAdministrative_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymAdministrative_Client.Structure
{
    //ToDo JPS: Criar uma utility com o Wrong Choice
    public class ProgramStructure
    {
        public static void RunStructure()
        {
            string choiceMenu01 = "";
            do
            {
                #region Menu01 Initial
                choiceMenu01 = Menus.InitialMenu();
                #endregion

                if (choiceMenu01 == "1")
                {
                    #region LogIn
                    string userType = Menus.LogIn();
                    #endregion

                    #region Menu02 General Admin
                    if (userType == "Admin")
                    {
                        string choiceMenu02Admin = "";
                        do
                        {
                            choiceMenu02Admin = Menus.GeneralMenuAdmin();
                            switch (choiceMenu02Admin)
                            {
                                case "1":

                                    #region Menu03 User Administration
                                    string choiceMenu03UserAdministration = "";
                                    do
                                    {
                                        choiceMenu03UserAdministration = Menus.UserAdministrationMenu();
                                        switch (choiceMenu03UserAdministration)
                                        {
                                            case "1":

                                                #region Create
                                                User newUser = new User();
                                                newUser = UserRepository.AskNewUser();
                                                //UserRepository.CreateUser(newUser.PermissionType, newUser.UserName, newUser.Code, newUser.PassWord);
                                                Utilities.Basics.Message("\nNovo Utilizador Criado.");
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "2":

                                                #region Update
                                                Console.Clear(); // Alterar
                                                #endregion

                                                break;

                                            case "3":

                                                #region Read
                                                UserRepository.ReadUser();
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "0":

                                                #region Back
                                                Console.Clear(); // Voltar
                                                #endregion

                                                break;

                                            default:

                                                #region Wrong Choice
                                                Console.WriteLine(choiceMenu03UserAdministration);
                                                Console.ReadKey();
                                                Console.Clear();
                                                #endregion

                                                break;
                                        }
                                    } while (choiceMenu03UserAdministration != "0");
                                    #endregion

                                    break;

                                case "2":

                                    #region Menu04 Client Administration
                                    string choiceMenu04ClientAdministration = "";
                                    do
                                    {
                                        choiceMenu04ClientAdministration = Menus.ClientAdministrationMenu();
                                        switch (choiceMenu04ClientAdministration)
                                        {
                                            case "1":

                                                #region Create
                                                Client newClient = new Client();
                                                ZipCode newZipCode = new ZipCode();
                                                //create new zip
                                                newClient = ClientRepository.AskNewUser();
                                                //ClientRepository.CreateClient();
                                                Utilities.Basics.Message("\nNovo Cliente Criado.");
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "2":

                                                #region Update
                                                Console.Clear(); // Alterar
                                                #endregion

                                                break;
                                            case "3":

                                                #region Read
                                                ClientRepository.ReadClient();
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "4":

                                                #region Activate/Desactivate
                                                Console.Clear(); // Ativar/Desativar
                                                #endregion

                                                break;

                                            case "0":

                                                #region Back
                                                Console.Clear(); // Voltar
                                                #endregion

                                                break;

                                            default:

                                                #region Wrong Choice
                                                Console.WriteLine(choiceMenu04ClientAdministration);
                                                Console.ReadKey();
                                                Console.Clear();
                                                #endregion

                                                break;
                                        }
                                    } while (choiceMenu04ClientAdministration != "0");
                                    #endregion

                                    break;

                                case "3":

                                    #region Menu05 PT Administration
                                    string choiceMenu05_1PtAdministration = "";
                                    do
                                    {
                                        choiceMenu05_1PtAdministration = Menus.PtAdministrationMenu();
                                        switch (choiceMenu05_1PtAdministration)
                                        {
                                            case "1":

                                                #region Create
                                                PersonalTrainer newPt = new PersonalTrainer();
                                                ZipCode newZipCode = new ZipCode();
                                                //create new zip
                                                newPt = PersonalTrainerRepository.AskNewPersonalTrainer();
                                                //PersonalTrainerRepository.CreateClient();
                                                Utilities.Basics.Message("\nNovo Personal Trainer Criado.");
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "2":

                                                #region Read
                                                PersonalTrainerRepository.ReadPersonalTrainer();
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "0":

                                                #region Back
                                                Console.Clear(); // Voltar
                                                #endregion

                                                break;

                                            default:

                                                #region WrongChoice
                                                Console.WriteLine(choiceMenu05_1PtAdministration);
                                                Console.ReadKey();
                                                Console.Clear();
                                                #endregion

                                                break;
                                        }
                                    } while (choiceMenu05_1PtAdministration != "0");
                                    #endregion

                                    break;

                                case "4":

                                    #region Menu06 Request Administration
                                    string choiceMenu05_2RequestAdministration = "";
                                    do
                                    {
                                        choiceMenu05_2RequestAdministration = Menus.RequestAdministrationMenu();
                                        switch (choiceMenu05_2RequestAdministration)
                                        {
                                            case "1":

                                                #region Create
                                                Console.Clear(); // Criar
                                                #endregion

                                                break;

                                            case "2":

                                                #region Read
                                                RequestRepository.ReadRequest();
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "0":

                                                #region Back
                                                Console.Clear(); // Voltar
                                                #endregion

                                                break;

                                            default:

                                                #region WrongChoice
                                                Console.WriteLine(choiceMenu05_2RequestAdministration);
                                                Console.ReadKey();
                                                Console.Clear();
                                                #endregion

                                                break;
                                        }
                                    } while (choiceMenu05_2RequestAdministration != "0");
                                    #endregion

                                    break;

                                case "0":

                                    #region Back
                                    // ToDo JPS: Mensagem Final de Final de Sessão, Admin
                                    Console.Clear(); // Voltar
                                    #endregion

                                    break;

                                default:

                                    #region Wrong Choice
                                    Console.WriteLine(choiceMenu02Admin);
                                    Console.ReadKey();
                                    Console.Clear();
                                    #endregion

                                    break;
                            }
                        } while (choiceMenu02Admin != "0");
                    }
                    #endregion

                    #region Menu02 General Colab
                    else if (userType == "Colab")
                    {
                        string choiceMenu02Colab = "";
                        do
                        {
                            choiceMenu02Colab = Menus.GeneralMenuColab();
                            switch (choiceMenu02Colab)
                            {
                                case "1":

                                    #region Menu04 Client Administration
                                    string choiceMenu04ClientAdministration = "";
                                    do
                                    {
                                        choiceMenu04ClientAdministration = Menus.ClientAdministrationMenu();
                                        switch (choiceMenu04ClientAdministration)
                                        {
                                            case "1":

                                                #region Create
                                                Console.Clear(); // Criar
                                                #endregion

                                                break;

                                            case "2":

                                                #region Update
                                                Console.Clear(); // Alterar
                                                #endregion

                                                break;
                                            case "3":

                                                #region Read
                                                Console.Clear(); // Consultar
                                                #endregion

                                                break;

                                            case "4":

                                                #region Activate/Desactivate
                                                Console.Clear(); // Ativar/Desativar
                                                #endregion

                                                break;

                                            case "0":

                                                #region Back
                                                Console.Clear(); // Voltar
                                                #endregion

                                                break;

                                            default:

                                                #region Wrong Choice
                                                Console.WriteLine(choiceMenu04ClientAdministration);
                                                Console.ReadKey();
                                                Console.Clear();
                                                #endregion

                                                break;
                                        }
                                    } while (choiceMenu04ClientAdministration != "0");
                                    #endregion

                                    break;

                                case "2":

                                    #region Menu05 PT Administration
                                    string choiceMenu05_1PtAdministration = "";
                                    do
                                    {
                                        choiceMenu05_1PtAdministration = Menus.PtAdministrationMenu();
                                        switch (choiceMenu05_1PtAdministration)
                                        {
                                            case "1":

                                                #region Create
                                                Console.Clear(); // Criar
                                                #endregion

                                                break;

                                            case "2":

                                                #region Read
                                                Console.Clear(); // Listar
                                                #endregion

                                                break;

                                            case "0":

                                                #region Back
                                                Console.Clear(); // Voltar
                                                #endregion

                                                break;

                                            default:

                                                #region WrongChoice
                                                Console.WriteLine(choiceMenu05_1PtAdministration);
                                                Console.ReadKey();
                                                Console.Clear();
                                                #endregion

                                                break;
                                        }
                                    } while (choiceMenu05_1PtAdministration != "0");
                                    #endregion

                                    break;

                                case "3":

                                    #region Menu06 Request Administration
                                    string choiceMenu05_2RequestAdministration = "";
                                    do
                                    {
                                        choiceMenu05_2RequestAdministration = Menus.RequestAdministrationMenu();
                                        switch (choiceMenu05_2RequestAdministration)
                                        {
                                            case "1":

                                                #region Create
                                                Console.Clear(); // Criar
                                                #endregion

                                                break;

                                            case "2":

                                                #region Read
                                                Console.Clear(); // Listar
                                                #endregion

                                                break;

                                            case "0":

                                                #region Back
                                                Console.Clear(); // Voltar
                                                #endregion

                                                break;

                                            default:

                                                #region WrongChoice
                                                Console.WriteLine(choiceMenu05_2RequestAdministration);
                                                Console.ReadKey();
                                                Console.Clear();
                                                #endregion

                                                break;
                                        }
                                    } while (choiceMenu05_2RequestAdministration != "0");
                                    #endregion

                                    break;

                                case "0":

                                    #region Back
                                    // ToDo JPS: Mensagem Final de Final de Sessão, Admin
                                    Console.Clear(); // Voltar
                                    #endregion

                                    break;

                                default:

                                    #region Wrong Choice
                                    Console.WriteLine(choiceMenu02Colab);
                                    Console.ReadKey();
                                    Console.Clear();
                                    #endregion

                                    break;
                            }
                        } while (choiceMenu02Colab != "0");
                    }
                    #endregion

                    #region Wrong Credentials
                    else
                    {
                        Console.WriteLine($"{userType}! Pressiona qualquer tecla para voltares ao menu incial.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    #endregion
                }
            } while (choiceMenu01 != "0");
        }
    }
}
