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
            Console.Clear();
            Utilities.Basics.Title01("Consulta de Clientes");
            Utilities.Basics.BlockSeparator(1);

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
                readClient.ToList().ForEach(c => Console.WriteLine($"ID: {c.ClientID} | Estado: {c.ActiveNow} | NIF: {c.ClientVat} | Data de Nascimento: {c.BirthDate.ToShortDateString()} | Nome: {c.ClientName}\t| Telemóvel: {c.ClientPhoneNumber}\t| Email: {c.ClientEmail}\t| Morada: {c.ClientAdress}, {c.Zip} - {c.City}"));
            }
        }
        #endregion

        #region Update

        #endregion

        #region ActiveNow Modification

        #endregion

        #region New Client
        public static Client AskNewUser()
        {
            Client client = new Client();

            Console.Clear();
            Utilities.Basics.Title01("Criação de um Novo Cliente");
            Utilities.Basics.BlockSeparator(1);

            string valid = "";

            #region Name
            string name = "";
            do
            {
                name = Utilities.Basics.AskData("Nome");
                valid = Utilities.Validations.ValidateName(name);
            } while (valid == "Nome inválido. Máximo 100 caracteres.");
            client.ClientName = name;
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
        #endregion
    }
}
