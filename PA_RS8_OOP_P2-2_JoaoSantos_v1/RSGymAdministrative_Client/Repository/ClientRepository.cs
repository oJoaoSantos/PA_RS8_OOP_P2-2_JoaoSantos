using RSGymAdministrative_Client.Structure;
using RSGymAdministrative_DAL.Model;
using System;
using System.Linq;

namespace RSGymAdministrative_Client.Repository
{
    static class ClientRepository
    {
        #region Create
        public static void CreateClient(int zipID, string name, DateTime birth, string vat, string phone, string mail, string adress, string obs = "", bool active = true)
        {
            Client client = new Client()
            {
                ZipCodeID = zipID,
                ClientName = name,
                BirthDate = birth,
                ClientVat = vat,
                ClientPhoneNumber = phone,
                ClientEmail = mail,
                ClientAdress = adress,
                ClientObservations = obs,
                ActiveNow = active
            };

            using (var context = new _DatabaseContext())
            {
                context.Client.Add(client);
                context.SaveChanges();
            }
        }
        #endregion

        #region Read
        public static void ReadClient()
        {
            using (var context = new _DatabaseContext())
            {
                var readClient = context.ZipCode.Join(context.Client,
                                                    z => z.ZipCodeID,
                                                    c => c.ZipCodeID,
                                                    (z, c) => new
                                                    {
                                                        c.ClientID,
                                                        c.ActiveNow,
                                                        c.ClientVat,
                                                        c.BirthDate,
                                                        c.ClientName,
                                                        c.ClientPhoneNumber,
                                                        c.ClientEmail,
                                                        c.ClientAdress,
                                                        z.Zip,
                                                        z.City
                                                    })
                                                    .OrderBy(c => c.ClientName)
                                                    .ToList();
                readClient.ToList().ForEach(c => Console.WriteLine($" * ID: {c.ClientID} * Estado: {(c.ActiveNow == true ? "Ativo" : "Inativo")} * NIF: {c.ClientVat} * Data de Nascimento: {c.BirthDate.ToShortDateString()} * Nome: {c.ClientName} * Telemóvel: {c.ClientPhoneNumber} * Email: {c.ClientEmail} * Morada: {c.ClientAdress}, {c.Zip} - {c.City} *"));                
            }
        }
        #endregion

        #region Update Full Client
        public static void UpdateClientFull(int zip, string name, DateTime birth, string phone, string mail, string adress, string obs, int id)
        {
            using (var context = new _DatabaseContext())
            {
                var clientToUpdate = context.Client.SingleOrDefault(p => p.ClientID == id);

                if (clientToUpdate != null)
                {
                    clientToUpdate.ZipCodeID= zip;
                    clientToUpdate.ClientName = name;
                    clientToUpdate.BirthDate = birth;
                    clientToUpdate.ClientPhoneNumber = phone;
                    clientToUpdate.ClientEmail = mail;
                    clientToUpdate.ClientAdress = adress;
                    clientToUpdate.ClientObservations = obs;

                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Update ActiveNow
        public static void UpdateActiveNow(bool active, int id)
        {
            using (var context = new _DatabaseContext())
            {
                var clientToUpdate = context.Client.SingleOrDefault(p => p.ClientID == id);

                if (clientToUpdate != null)
                {
                    clientToUpdate.ActiveNow = active;

                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region ActiveNow Modification
        public static Client AskNewClientActiveNow(string title)
        {
            Console.Clear();
            Utilities.Basics.Title01(title);
            Utilities.Basics.BlockSeparator(1);
            Utilities.Basics.Title02("Lista de Clientes");
            ReadClient();

            Client client = new Client();

            string id = "";
            string valid = "";

            do
            {
                Utilities.Basics.BlockSeparator(1);
                id = Utilities.Basics.AskData("ID do Cliente a Alterar");
                valid = Utilities.Validations.ValidateID(id);
            } while (valid == "ID inválido.");
            client.ClientID = int.Parse(id);

            Console.WriteLine("\nComo pretendes alterar?");
            string ativate = Menus.ClientActivateNowMenu();
            do
            {
                switch (ativate)
                {
                    case "1":
                        client.ActiveNow = true;
                        break;
                    case "0":
                        client.ActiveNow = false;
                        break;
                    default:
                        Console.WriteLine(ativate);
                        Console.ReadKey();
                        break;
                }
            } while (ativate == "Opção inválida. Tenta de novo, com uma opção da lista.");
            return client;
        }
        #endregion

        #region New Client
        public static Client AskNewClient(string title, bool idBool)
        {
            Client client = new Client();
            string valid = "";
            bool existingVat = false;

            if (idBool == false)
            {
                Console.Clear();
                Utilities.Basics.Title01(title);
                Utilities.Basics.BlockSeparator(1);

                #region VAT
                string vat = "";
                do
                {
                    vat = Utilities.Basics.AskData("NIF");
                    valid = Utilities.Validations.ValidateVatAndPhone(vat);
                } while (valid == "Valor inválido. 9 Caracteres numéricos obrigatórios.");

                existingVat = Utilities.Validations.FindVatClient(vat);
                if (existingVat == true)
                {
                    Utilities.Basics.Message("\nUtilizador já existente.");
                    client.ClientVat = "0";
                }
                else
                {
                    client.ClientVat = vat;
                }
                #endregion
            }

            #region ID
            if (idBool == true)
            {
                Utilities.Basics.BlockSeparator(1);
                string id = "";
                do
                {
                    id = Utilities.Basics.AskData("ID do Cliente a Alterar");
                    valid = Utilities.Validations.ValidateID(id);
                } while (valid == "ID inválido.");
                client.ClientID = int.Parse(valid);
            }
            #endregion

            if (existingVat == false)
            {
                #region Name
                string clientName = "";
                do
                {
                    clientName = Utilities.Basics.AskData("Nome");
                    valid = Utilities.Validations.ValidateName(clientName);
                } while (valid == "Dados inválidos. Minimo 3 e máximo 100 caracteres alfabéticos.");
                client.ClientName = clientName;
                #endregion

                #region Birth
                client.BirthDate = Utilities.Validations.ValidateBirthDate();
                #endregion

                #region Phone
                string phone = "";
                do
                {
                    phone = Utilities.Basics.AskData("Telemóvel");
                    valid = Utilities.Validations.ValidateVatAndPhone(phone);
                } while (valid == "Valor inválido. 9 Caracteres numéricos obrigatórios.");
                client.ClientPhoneNumber = phone;
                #endregion

                #region Mail
                string mail = "";
                do
                {
                    mail = Utilities.Basics.AskData("Email");
                    valid = Utilities.Validations.ValidateMail(mail);
                } while (valid == "Email inválido.");
                client.ClientEmail = mail;
                #endregion

                #region Obs
                string obs = "";
                do
                {
                    obs = Utilities.Basics.AskData("Observações (opcional, enter para saltar)");
                    valid = Utilities.Validations.ValidateObs(obs);
                } while (valid == "Máximo 255 caracteres.");
                client.ClientObservations = obs;
                #endregion

                #region Adress
                string adress = "";
                do
                {
                    adress = Utilities.Basics.AskData("Morada (Rua, Número/Bloco/Lote e Andar)");
                    valid = Utilities.Validations.ValidateAdress(adress);
                } while (valid == "Mínimo 3 e máximo 200 caracteres.");
                client.ClientAdress = adress;
                #endregion

                client.ActiveNow = true;
            }
            return client;
        }
        #endregion

        #region FindClient
        public static void FindClient()
        {
            bool again = false;
            do
            {
                Console.Clear();
                Utilities.Basics.Title01("Modificação de Dados de um Cliente");
                Utilities.Basics.BlockSeparator(1);

                string name = Utilities.Basics.AskData("Pesquisa o Nome do Cliente: ");
                using (var context = new _DatabaseContext())
                {
                    var findClient = context.Client.Select(c => c).Where(c => c.ClientName.ToLower().Contains(name.ToLower()));
                    Console.WriteLine("\nClientes Encontrados:");
                    findClient.ToList().ForEach(c => Console.WriteLine($"ID: {c.ClientID} - Nome: {c.ClientName}"));
                }

                Console.WriteLine("\nQueres pesquisar novamente?");
                string find = Menus.ClientFindMenu();
                switch (find)
                {
                    case "1":
                        again = true;
                        break;
                    case "0":
                        again = false;
                        break;
                    default:
                        Console.WriteLine(find);
                        Console.ReadKey();
                        break;
                }
            } while (again == true);
        }
        #endregion
    }
}
