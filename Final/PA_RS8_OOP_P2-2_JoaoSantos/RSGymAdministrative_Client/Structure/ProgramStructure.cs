using RSGymAdministrative_Client.Repository;
using RSGymAdministrative_DAL.Model;
using System;

namespace RSGymAdministrative_Client.Structure
{
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
                                                User newUserCreate = new User();
                                                newUserCreate = UserRepository.AskNewUser();
                                                UserRepository.CreateUser(newUserCreate.PermissionType, newUserCreate.UserName, newUserCreate.Code, newUserCreate.PassWord);
                                                Utilities.Basics.Message("\nNovo Utilizador Criado.");
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "2":

                                                #region Update
                                                User newUserUpdate = new User();
                                                newUserUpdate = UserRepository.AskNewPass();
                                                UserRepository.UpdateUserPassword(newUserUpdate.PassWord, newUserUpdate.UserID);
                                                Utilities.Basics.Message("\nPalavra-Passe Alterada.");
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "3":

                                                #region Read
                                                Console.Clear();
                                                Utilities.Basics.Title01("Consulta de Utilizadores");
                                                Utilities.Basics.BlockSeparator(1);
                                                UserRepository.ReadUser();
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "0":

                                                #region Back
                                                Console.Clear();
                                                #endregion

                                                break;

                                            default:

                                                #region Wrong Choice
                                                Utilities.Basics.Voltar(choiceMenu03UserAdministration);
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
                                                newClient = ClientRepository.AskNewClient("Criação de um Novo Cliente", false);
                                                if (newClient.ClientVat == "0")
                                                {
                                                    Utilities.Basics.Voltar();
                                                }
                                                else
                                                {
                                                    newZipCode = ZipCodeRepository.AskNewZipCode();
                                                    if (Utilities.Validations.FindZipCode(newZipCode.Zip) == false)
                                                    {
                                                        ZipCodeRepository.CreateZipCode(newZipCode.Zip, newZipCode.City);
                                                        newClient.ZipCodeID = Utilities.Validations.FindMaxIdZipCode();
                                                        ClientRepository.CreateClient(newClient.ZipCodeID, newClient.ClientName, newClient.BirthDate, newClient.ClientVat, newClient.ClientPhoneNumber, newClient.ClientEmail, newClient.ClientAdress, newClient.ClientObservations);
                                                        Utilities.Basics.Message("\nNovo Cliente Criado.");
                                                        Utilities.Basics.Voltar();
                                                    }
                                                    else
                                                    {
                                                        newClient.ZipCodeID = Utilities.Validations.FindIdZipCode(newZipCode.Zip);
                                                        ClientRepository.CreateClient(newClient.ZipCodeID, newClient.ClientName, newClient.BirthDate, newClient.ClientVat, newClient.ClientPhoneNumber, newClient.ClientEmail, newClient.ClientAdress, newClient.ClientObservations);
                                                        Utilities.Basics.Message("\nNovo Cliente Criado.");
                                                        Utilities.Basics.Voltar();
                                                    }                                                    
                                                }
                                                #endregion

                                                break;

                                            case "2":

                                                #region Update
                                                Client newClientUpdate = new Client();
                                                ClientRepository.FindClient();
                                                newClientUpdate = ClientRepository.AskNewClient("Modificação de Dados de um Cliente", true);
                                                newZipCode = ZipCodeRepository.AskNewZipCode();
                                                if (Utilities.Validations.FindZipCode(newZipCode.Zip) == false)
                                                {
                                                    ZipCodeRepository.CreateZipCode(newZipCode.Zip, newZipCode.City);
                                                    newClientUpdate.ZipCodeID = Utilities.Validations.FindMaxIdZipCode();
                                                    ClientRepository.UpdateClientFull(newClientUpdate.ZipCodeID, newClientUpdate.ClientName, newClientUpdate.BirthDate, newClientUpdate.ClientPhoneNumber, newClientUpdate.ClientEmail, newClientUpdate.ClientAdress, newClientUpdate.ClientObservations, newClientUpdate.ClientID );
                                                    Utilities.Basics.Message("\nDados do Cliente Modificados.");
                                                    Utilities.Basics.Voltar();
                                                }
                                                else
                                                {
                                                    newClientUpdate.ZipCodeID = Utilities.Validations.FindIdZipCode(newZipCode.Zip);
                                                    ClientRepository.UpdateClientFull(newClientUpdate.ZipCodeID, newClientUpdate.ClientName, newClientUpdate.BirthDate, newClientUpdate.ClientPhoneNumber, newClientUpdate.ClientEmail, newClientUpdate.ClientAdress, newClientUpdate.ClientObservations, newClientUpdate.ClientID );
                                                    Utilities.Basics.Message("\nDados do Cliente Modificados.");
                                                    Utilities.Basics.Voltar();
                                                }
                                                #endregion

                                                break;
                                            case "3":

                                                #region Read
                                                Console.Clear();
                                                Utilities.Basics.Title01("Consulta de Clientes");
                                                Utilities.Basics.BlockSeparator(1);
                                                ClientRepository.ReadClient();
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "4":

                                                #region Activate/Desactivate
                                                Client newClientUpdateStatus = new Client();
                                                newClientUpdateStatus = ClientRepository.AskNewClientActiveNow("Ativar ou Desativar um Cliente");
                                                ClientRepository.UpdateActiveNow(newClientUpdateStatus.ActiveNow, newClientUpdateStatus.ClientID);
                                                Utilities.Basics.Message("\nEstado Alterado.");
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "0":

                                                #region Back
                                                Console.Clear();
                                                #endregion

                                                break;

                                            default:

                                                #region Wrong Choice
                                                Utilities.Basics.Voltar(choiceMenu04ClientAdministration);
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
                                                newPt = PersonalTrainerRepository.AskNewPersonalTrainer();
                                                if (newPt.PtVat == "0")
                                                {
                                                    Utilities.Basics.Voltar();
                                                }
                                                else
                                                {
                                                    newZipCode = ZipCodeRepository.AskNewZipCode();
                                                    if (Utilities.Validations.FindZipCode(newZipCode.Zip) == false)
                                                    {
                                                        ZipCodeRepository.CreateZipCode(newZipCode.Zip, newZipCode.City);
                                                        newPt.ZipCodeID = Utilities.Validations.FindMaxIdZipCode();
                                                        PersonalTrainerRepository.CreatePersonalTrainer(newPt.ZipCodeID, newPt.PtCode, newPt.PtName, newPt.PtVat, newPt.PtPhoneNumber, newPt.PtEmail, newPt.PtAdress);
                                                        Utilities.Basics.Message("\nNovo Pt Criado.");
                                                        Utilities.Basics.Voltar();
                                                    }
                                                    else
                                                    {
                                                        newPt.ZipCodeID = Utilities.Validations.FindIdZipCode(newZipCode.Zip);
                                                        PersonalTrainerRepository.CreatePersonalTrainer(newPt.ZipCodeID, newPt.PtCode, newPt.PtName, newPt.PtVat, newPt.PtPhoneNumber, newPt.PtEmail, newPt.PtAdress);
                                                        Utilities.Basics.Message("\nNovo Pt Criado.");
                                                        Utilities.Basics.Voltar();
                                                    }
                                                }
                                                #endregion

                                                break;

                                            case "2":

                                                #region Read
                                                Console.Clear();
                                                Utilities.Basics.Title01("Consulta de Personal Trainers");
                                                Utilities.Basics.BlockSeparator(1);
                                                PersonalTrainerRepository.ReadPersonalTrainer();
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "0":

                                                #region Back
                                                Console.Clear();
                                                #endregion

                                                break;

                                            default:

                                                #region WrongChoice
                                                Utilities.Basics.Voltar(choiceMenu05_1PtAdministration);
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
                                                Request newRequest = new Request();
                                                newRequest = RequestRepository.AskNewRequest();
                                                RequestRepository.CreateRequest(newRequest.ClientID, newRequest.PersonalTrainerID, newRequest.DateAndTime, newRequest.Status, newRequest.RequestObservations);
                                                Utilities.Basics.Message("\nNovo Pedido Criado.");
                                                Utilities.Basics.Voltar();
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
                                                Console.Clear();
                                                #endregion

                                                break;

                                            default:

                                                #region WrongChoice
                                                Utilities.Basics.Voltar(choiceMenu05_2RequestAdministration);
                                                #endregion

                                                break;
                                        }
                                    } while (choiceMenu05_2RequestAdministration != "0");
                                    #endregion

                                    break;

                                case "0":

                                    #region Back
                                    Console.Clear();
                                    Utilities.Basics.FinalMessage("Sessão Terminada. Prime qualquer tecla para voltar ao Menu Inicial.");
                                    Console.ReadKey();
                                    #endregion

                                    break;

                                default:

                                    #region Wrong Choice
                                    Utilities.Basics.Voltar(choiceMenu02Admin);
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
                                                Client newClient = new Client();
                                                ZipCode newZipCode = new ZipCode();
                                                newClient = ClientRepository.AskNewClient("Criação de um Novo Cliente", false);
                                                if (newClient.ClientVat == "0")
                                                {
                                                    Utilities.Basics.Voltar();
                                                }
                                                else
                                                {
                                                    newZipCode = ZipCodeRepository.AskNewZipCode();
                                                    if (Utilities.Validations.FindZipCode(newZipCode.Zip) == false)
                                                    {
                                                        ZipCodeRepository.CreateZipCode(newZipCode.Zip, newZipCode.City);
                                                        newClient.ZipCodeID = Utilities.Validations.FindMaxIdZipCode();
                                                        ClientRepository.CreateClient(newClient.ZipCodeID, newClient.ClientName, newClient.BirthDate, newClient.ClientVat, newClient.ClientPhoneNumber, newClient.ClientEmail, newClient.ClientAdress, newClient.ClientObservations);
                                                        Utilities.Basics.Message("\nNovo Cliente Criado.");
                                                        Utilities.Basics.Voltar();
                                                    }
                                                    else
                                                    {
                                                        newClient.ZipCodeID = Utilities.Validations.FindIdZipCode(newZipCode.Zip);
                                                        ClientRepository.CreateClient(newClient.ZipCodeID, newClient.ClientName, newClient.BirthDate, newClient.ClientVat, newClient.ClientPhoneNumber, newClient.ClientEmail, newClient.ClientAdress, newClient.ClientObservations);
                                                        Utilities.Basics.Message("\nNovo Cliente Criado.");
                                                        Utilities.Basics.Voltar();
                                                    }
                                                }
                                                #endregion

                                                break;

                                            case "2":

                                                #region Update
                                                Client newClientUpdate = new Client();
                                                ClientRepository.FindClient();
                                                newClientUpdate = ClientRepository.AskNewClient("Modificação de Dados de um Cliente", true);
                                                newZipCode = ZipCodeRepository.AskNewZipCode();
                                                if (Utilities.Validations.FindZipCode(newZipCode.Zip) == false)
                                                {
                                                    ZipCodeRepository.CreateZipCode(newZipCode.Zip, newZipCode.City);
                                                    newClientUpdate.ZipCodeID = Utilities.Validations.FindMaxIdZipCode();
                                                    ClientRepository.UpdateClientFull(newClientUpdate.ZipCodeID, newClientUpdate.ClientName, newClientUpdate.BirthDate, newClientUpdate.ClientPhoneNumber, newClientUpdate.ClientEmail, newClientUpdate.ClientAdress, newClientUpdate.ClientObservations, newClientUpdate.ClientID);
                                                    Utilities.Basics.Message("\nDados do Cliente Modificados.");
                                                    Utilities.Basics.Voltar();
                                                }
                                                else
                                                {
                                                    newClientUpdate.ZipCodeID = Utilities.Validations.FindIdZipCode(newZipCode.Zip);
                                                    ClientRepository.UpdateClientFull(newClientUpdate.ZipCodeID, newClientUpdate.ClientName, newClientUpdate.BirthDate, newClientUpdate.ClientPhoneNumber, newClientUpdate.ClientEmail, newClientUpdate.ClientAdress, newClientUpdate.ClientObservations, newClientUpdate.ClientID);
                                                    Utilities.Basics.Message("\nDados do Cliente Modificados.");
                                                    Utilities.Basics.Voltar();
                                                }
                                                #endregion

                                                break;
                                            case "3":

                                                #region Read
                                                Console.Clear();
                                                Utilities.Basics.Title01("Consulta de Clientes");
                                                Utilities.Basics.BlockSeparator(1);
                                                ClientRepository.ReadClient();
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "4":

                                                #region Activate/Desactivate
                                                Client newClientUpdateStatus = new Client();
                                                newClientUpdateStatus = ClientRepository.AskNewClientActiveNow("Ativar ou Desativar um Cliente");
                                                ClientRepository.UpdateActiveNow(newClientUpdateStatus.ActiveNow, newClientUpdateStatus.ClientID);
                                                Utilities.Basics.Message("\nEstado Alterado.");
                                                Utilities.Basics.Voltar();
                                                #endregion

                                                break;

                                            case "0":

                                                #region Back
                                                Console.Clear();
                                                #endregion

                                                break;

                                            default:

                                                #region Wrong Choice
                                                Utilities.Basics.Voltar(choiceMenu04ClientAdministration);
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
                                                PersonalTrainer newPt = new PersonalTrainer();
                                                ZipCode newZipCode = new ZipCode();
                                                newPt = PersonalTrainerRepository.AskNewPersonalTrainer();
                                                if (newPt.PtVat == "0")
                                                {
                                                    Utilities.Basics.Voltar();
                                                }
                                                else
                                                {
                                                    newZipCode = ZipCodeRepository.AskNewZipCode();
                                                    if (Utilities.Validations.FindZipCode(newZipCode.Zip) == false)
                                                    {
                                                        ZipCodeRepository.CreateZipCode(newZipCode.Zip, newZipCode.City);
                                                        newPt.ZipCodeID = Utilities.Validations.FindMaxIdZipCode();
                                                        PersonalTrainerRepository.CreatePersonalTrainer(newPt.ZipCodeID, newPt.PtCode, newPt.PtName, newPt.PtVat, newPt.PtPhoneNumber, newPt.PtEmail, newPt.PtAdress);
                                                        Utilities.Basics.Message("\nNovo Pt Criado.");
                                                        Utilities.Basics.Voltar();
                                                    }
                                                    else
                                                    {
                                                        newPt.ZipCodeID = Utilities.Validations.FindIdZipCode(newZipCode.Zip);
                                                        PersonalTrainerRepository.CreatePersonalTrainer(newPt.ZipCodeID, newPt.PtCode, newPt.PtName, newPt.PtVat, newPt.PtPhoneNumber, newPt.PtEmail, newPt.PtAdress);
                                                        Utilities.Basics.Message("\nNovo Pt Criado.");
                                                        Utilities.Basics.Voltar();
                                                    }
                                                }
                                                #endregion

                                                break;

                                            case "2":

                                                #region Read
                                                Console.Clear();
                                                Utilities.Basics.Title01("Consulta de Personal Trainers");
                                                Utilities.Basics.BlockSeparator(1);
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
                                                Utilities.Basics.Voltar(choiceMenu05_1PtAdministration);
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
                                                Request newRequest = new Request();
                                                newRequest = RequestRepository.AskNewRequest();
                                                RequestRepository.CreateRequest(newRequest.ClientID, newRequest.PersonalTrainerID, newRequest.DateAndTime, newRequest.Status, newRequest.RequestObservations);
                                                Utilities.Basics.Message("\nNovo Pedido Criado.");
                                                Utilities.Basics.Voltar();
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
                                                Console.Clear();
                                                #endregion

                                                break;

                                            default:

                                                #region WrongChoice
                                                Utilities.Basics.Voltar(choiceMenu05_2RequestAdministration);
                                                #endregion

                                                break;
                                        }
                                    } while (choiceMenu05_2RequestAdministration != "0");
                                    #endregion

                                    break;

                                case "0":

                                    #region Back
                                    Console.Clear();
                                    Utilities.Basics.FinalMessage("Sessão Terminada. Prime qualquer tecla para voltar ao Menu Inicial.");
                                    Console.ReadKey();
                                    #endregion

                                    break;

                                default:

                                    #region Wrong Choice
                                    Utilities.Basics.Voltar(choiceMenu02Colab);
                                    #endregion

                                    break;
                            }
                        } while (choiceMenu02Colab != "0");
                    }
                    #endregion

                    #region Wrong Credentials
                    else
                    {
                        Utilities.Basics.Voltar($"\n{userType}!\n\nPrime qualquer tecla para voltares ao menu incial.");
                    }
                    #endregion
                }
            } while (choiceMenu01 != "0");
        }
    }
}
