using RSGymAdministrative_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymAdministrative_Client.Repository
{
    static class PersonalTrainerRepository
    {
        #region Create
        public static void CreatePersonalTrainer(int zipID, string code, string name, string vat, string phone, string mail, string adress)
        {
            PersonalTrainer personalTrainer = new PersonalTrainer()
            {
                ZipCodeID = zipID,
                PtCode = code,
                PtName = name,
                PtVat = vat,
                PtPhoneNumber = phone,
                PtEmail = mail,
                PtAdress = adress,
            };

            using (var context = new _DatabaseContext())
            {
                context.PersonalTrainer.Add(personalTrainer);
                context.SaveChanges();
            }
        }
        #endregion

        #region Read
        public static void ReadPersonalTrainer()
        {
            Console.Clear();
            Utilities.Basics.Title01("Consulta de Personal Trainers");
            Utilities.Basics.BlockSeparator(1);

            using (var context = new _DatabaseContext())
            {
                var readClient = context.ZipCode.Join(context.PersonalTrainer,
                                                    z => z.ZipCodeID,
                                                    p => p.ZipCodeID,
                                                    (z, p) => new
                                                    {
                                                        p.PersonalTrainerID,
                                                        p.PtCode,
                                                        p.PtName,
                                                        p.PtVat,
                                                        p.PtPhoneNumber,
                                                        p.PtEmail,
                                                        p.PtAdress,
                                                        z.Zip,
                                                        z.City
                                                    })
                                                    .OrderBy(p => p.PtName);
                readClient.ToList().ForEach(p => Console.WriteLine($"ID: {p.PersonalTrainerID} | Código: {p.PtCode} | NIF: {p.PtVat} | Nome: {p.PtName}\t| Telemóvel: {p.PtPhoneNumber}\t| Email: {p.PtEmail}\t| Morada: {p.PtAdress}, {p.Zip} - {p.City}"));
            }
        }
        #endregion

        #region New PT
        public static PersonalTrainer AskNewPersonalTrainer()
        {
            PersonalTrainer pt = new PersonalTrainer();

            Console.Clear();
            Utilities.Basics.Title01("Criação de um Novo Personal Trainer");
            Utilities.Basics.BlockSeparator(1);

            string valid = "";

            #region Code
            // ToDo JPS: PT -> Verificar se existe na bd, se sim, não deixa criar.
            string code = "";
            do
            {
                code = Utilities.Basics.AskData("Código");
                valid = Utilities.Validations.ValidatePTCode(code);
            } while (valid == "Nome inválido. Máximo 100 caracteres.");
            pt.PtCode = code;
            #endregion

            #region Name
            string name = "";
            do
            {
                name = Utilities.Basics.AskData("Nome");
                valid = Utilities.Validations.ValidateName(name);
            } while (valid == "Nome inválido. Máximo 100 caracteres.");
            pt.PtName = name;
            #endregion

            // ToDo JPS: Passar o VAT para primeiro e verificar se existe na bd, se sim não faz o resto
            #region VAT
            string vat = "";
            do
            {
                vat = Utilities.Basics.AskData("NIF");
                valid = Utilities.Validations.ValidateVatAndPhone(vat);
            } while (valid == "Valor inválido. 9 Caracteres numéricos obrigatórios.");
            pt.PtVat = vat;
            #endregion

            #region Adress
            string adress = "";
            do
            {
                adress = Utilities.Basics.AskData("Morada (Rua, Número/Bloco/Lote e Andar)");
                valid = Utilities.Validations.ValidateAdress(adress);
            } while (valid == "Máximo 200 caracteres.");
            pt.PtAdress = adress;
            #endregion

            #region Phone
            string phone = "";
            do
            {
                phone = Utilities.Basics.AskData("Telemóvel");
                valid = Utilities.Validations.ValidateVatAndPhone(phone);
            } while (valid == "Valor inválido. 9 Caracteres numéricos obrigatórios.");
            pt.PtPhoneNumber = phone;
            #endregion

            #region Mail
            //ToDo JPS: Validação mail
            string mail = Utilities.Basics.AskData("Email");
            pt.PtEmail = mail;
            #endregion

            //ToDo JPS: No PT, ZipCode, procurar o maior e adicionar o novo Zip. 

            //Console.WriteLine(client.ClientName);
            //Console.WriteLine(client.BirthDate.ToString());
            //Console.WriteLine(client.ClientVat);
            //Console.WriteLine(client.ClientAdress);
            //Console.WriteLine(client.ClientPhoneNumber);
            //Console.WriteLine(client.ClientEmail);
            //Console.WriteLine(client.ClientObservations);

            return pt;
        }
        #endregion
    }
}
