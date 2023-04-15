using RSGymAdministrative_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymAdministrative_Client.Repository
{
    static class ZipCodeRepository
    {
        #region Create
        public static void CreateZipCode(string zip, string city)
        {
            ZipCode zipCode = new ZipCode()
            {
                Zip = zip,
                City = city
            };

            using (var context = new _DatabaseContext())
            {
                context.ZipCode.Add(zipCode);
                context.SaveChanges();
            }
        }
        #endregion

        #region Ask New Zip Code
        public static ZipCode AskNewZipCode()
        {
            ZipCode zipCode = new ZipCode();

            #region Zip
            string zip = "";
            string valid = "";

            do
            {
                zip = Utilities.Basics.AskData("Código Postal (Formato: xxxx-xxx)");
                valid = Utilities.Validations.ValidadeZipCode(zip);
            } while (valid == "Código-Postal inválido. Formato Correto: XXXX-XXX.");
            zipCode.Zip = zip;
            #endregion

            if (Utilities.Validations.FindZipCode(zip) == false)
            {
                #region City
                string city = "";
                do
                {
                    city = Utilities.Basics.AskData("Cidade");
                    valid = Utilities.Validations.ValidateName(city);
                } while (valid == "Dados inválidos. Minimo 3 e máximo 100 caracteres alfabéticos.");
                zipCode.City = city;
                #endregion
            }
            return zipCode;
        }
        #endregion
    }
}
