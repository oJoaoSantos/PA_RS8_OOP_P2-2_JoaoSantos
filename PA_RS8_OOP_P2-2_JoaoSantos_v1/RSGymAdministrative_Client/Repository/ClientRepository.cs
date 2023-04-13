using RSGymAdministrative_Client.Structure;
using RSGymAdministrative_DAL.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                                    .OrderBy(c => c.ClientName);
                // ToDo JPS: Ver o estado.
                // ToDo JPS: PAssar para method syntax
                readClient.ToList().ForEach(c => Console.WriteLine($"ID: {c.ClientID} | Estado: {c.ActiveNow} | NIF: {c.ClientVat} | Data de Nascimento: {c.BirthDate.ToShortDateString()} | Nome: {c.ClientName}\t| Telemóvel: {c.ClientPhoneNumber}\t| Email: {c.ClientEmail}\t| Morada: {c.ClientAdress}, {c.Zip} - {c.City}"));
            }
        }
        #endregion

        #region Update
        public static void UpdateClient(string name, DateTime birth, string vat, string phone, string mail, string adress, string obs, int id)
        {
            using (var context = new _DatabaseContext())
            {
                var clientToUpdate = context.Client.SingleOrDefault(p => p.ClientID == id);

                if (clientToUpdate != null)
                {
                    //clientToUpdate.ZipCodeID= zip;
                    clientToUpdate.ClientName = name;
                    clientToUpdate.BirthDate = birth;
                    clientToUpdate.ClientVat = vat;
                    clientToUpdate.ClientPhoneNumber = phone;
                    clientToUpdate.ClientEmail = mail;
                    clientToUpdate.ClientAdress = adress;
                    clientToUpdate.ClientObservations = obs;

                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region ActiveNow Modification

        #endregion

        #region New Client
        public static Client AskNewClient(string title, bool idBool)
        {
            Client client = new Client();
            string valid = "";

            if (idBool == false)
            {
                Console.Clear();
                Utilities.Basics.Title01(title);
                Utilities.Basics.BlockSeparator(1);
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

            #region Name
            string clientName = "";
            do
            {
                clientName = Utilities.Basics.AskData("Nome");
                valid = Utilities.Validations.ValidateName(clientName);
            } while (valid == "Nome inválido. Minimo 3 e máximo 100 caracteres.");
            client.ClientName = clientName;
            #endregion

            #region Birth
            client.BirthDate = Utilities.Validations.ValidateBirthDate();
            #endregion

            // ToDo JPS: Passar o VAT para primeiro e verificar se existe na bd, se sim não faz o resto
            #region VAT
            string vat = "";
            do
            {
                vat = Utilities.Basics.AskData("NIF");
                valid = Utilities.Validations.ValidateVatAndPhone(vat);
            } while (valid == "Valor inválido. 9 Caracteres numéricos obrigatórios.");
            client.ClientVat = vat;
            #endregion

            #region Adress
            string adress = "";
            do
            {
                adress = Utilities.Basics.AskData("Morada (Rua, Número/Bloco/Lote e Andar)");
                valid = Utilities.Validations.ValidateAdress(adress);
            } while (valid == "Máximo 200 caracteres.");
            client.ClientAdress = adress;
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
            //ToDo JPS: Validação mail
            string mail = Utilities.Basics.AskData("Email");
            client.ClientEmail = mail;
            #endregion

            #region Obs
            string obs = "";
            do
            {
                obs = Utilities.Basics.AskData("Observações (Opcional, enter para saltar).");
                valid = Utilities.Validations.ValidateObs(obs);
            } while (valid == "Máximo 255 caracteres.");
            client.ClientObservations = obs;
            #endregion

            client.ActiveNow = true;

            //ToDo JPS: No Cliente, ZipCode, procurar o maior e adicionar o novo Zip. 

            //Console.WriteLine(client.ClientName);
            //Console.WriteLine(client.BirthDate.ToString());
            //Console.WriteLine(client.ClientVat);
            //Console.WriteLine(client.ClientAdress);
            //Console.WriteLine(client.ClientPhoneNumber);
            //Console.WriteLine(client.ClientEmail);
            //Console.WriteLine(client.ClientObservations);
            
            return client;
        }

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

        #endregion
    }
}
