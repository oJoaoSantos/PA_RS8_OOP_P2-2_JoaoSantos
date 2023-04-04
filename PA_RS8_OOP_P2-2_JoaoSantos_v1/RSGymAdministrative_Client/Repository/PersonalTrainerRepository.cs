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
        public static void CreatePersonalTrainer(int zipID, string name, string vat, string phone, string mail, string adress)
        {
            PersonalTrainer personalTrainer = new PersonalTrainer()
            {
                ZipCodeID = zipID,
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

        #endregion

    }
}
