using RSGymAdministrative_DAL.Model;
using System;
using System.Linq;

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
                PtCode = code.ToUpper(),
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
                readClient.ToList().ForEach(p => Console.WriteLine($" * ID: {p.PersonalTrainerID} * Código: {p.PtCode} * NIF: {p.PtVat} * Nome: {p.PtName} * Telemóvel: {p.PtPhoneNumber} * Email: {p.PtEmail} * Morada: {p.PtAdress}, {p.Zip} - {p.City} *"));
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
            Utilities.Basics.Title02("Lista de PT's");
            ReadPersonalTrainer();
            Utilities.Basics.BlockSeparator(1);

            string valid = "";
            string vat = "";

            #region VAT
            do
            {
                vat = Utilities.Basics.AskData("NIF");
                valid = Utilities.Validations.ValidateVatAndPhone(vat);
            } while (valid == "Valor inválido. 9 Caracteres numéricos obrigatórios.");

            bool existingVat = Utilities.Validations.FindVatPt(vat);
            if (existingVat == true)
            {
                Utilities.Basics.Message("\nUtilizador já existente.");
                pt.PtVat = "0";
            }
            #endregion
            else
            {
                pt.PtVat = vat;

                #region Code
                string code = "";
                do
                {
                    code = Utilities.Basics.AskData("Código");
                    valid = Utilities.Validations.ValidatePTCode(code);
                } while (valid == "Código inválido. 4 Caracteres obrigatórios, não pode ser repetido.");
                pt.PtCode = code;
                #endregion

                #region Name
                string name = "";
                do
                {
                    name = Utilities.Basics.AskData("Nome");
                    valid = Utilities.Validations.ValidateName(name);
                } while (valid == "Dados inválidos. Minimo 3 e máximo 100 caracteres alfabéticos.");
                pt.PtName = name;
                #endregion

                #region Adress
                string adress = "";
                do
                {
                    adress = Utilities.Basics.AskData("Morada (Rua, Número/Bloco/Lote e Andar)");
                    valid = Utilities.Validations.ValidateAdress(adress);
                } while (valid == "Mínimo 3 e máximo 200 caracteres.");
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
                string mail = "";
                do
                {
                    mail = Utilities.Basics.AskData("Email");
                    valid = Utilities.Validations.ValidateMail(mail);
                } while (valid == "Email inválido.");
                pt.PtEmail = mail;
                #endregion
            }
            return pt;
        }
        #endregion
    }
}
